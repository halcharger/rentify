using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Rentify.Core.Data;
using Rentify.Core.Domain;

namespace Rentify.Core.CommandHandlers
{
    public class SaveWebPageCommandHandler : IAsyncRequestHandler<SaveWebPageCommand, ICommandResult>
    {
        private readonly IRentifyDataFacade data;

        public SaveWebPageCommandHandler(IRentifyDataFacade data)
        {
            this.data = data;
        }

        public async Task<ICommandResult> Handle(SaveWebPageCommand message)
        {
            var userSettings = await data.RetrieveUserSettingsAsync(message.UserId);

            if (userSettings == null)
                return new FailureResult("There are no user settings for UserId: {0}", message.UserId);

            var settings = userSettings.GetRentifySettings();
            var site = settings.Sites.SingleOrDefault(s => s.UniqueId == message.SiteUniqueId);

            if (site == null)
                return new FailureResult("Could not find a site with the unique ID {0} for user {1}",
                        message.SiteUniqueId, message.UserId);

            if (message.WebPage.Id == 0)
            {
                //add a brand new web page, need to give it a new unique ID
                message.WebPage.Id = site.Pages.Any() 
                    ? site.Pages.Max(p => p.Id) + 1
                    : 1;                
            }
            else
            {
                //edit scenario, updating existing web page
                var webpage = site.Pages.SingleOrDefault(p => p.Id == message.WebPage.Id);
                if (webpage == null)
                    return new FailureResult("Could not find WebPage with Id {0} for site {1}", message.WebPage.Id,
                        message.SiteUniqueId);

                site.Pages.Remove(webpage);//remove the old
            }

            site.Pages.Add(message.WebPage);//add the new

            userSettings.SetRentitifySettings(settings);
            await data.UpdateUserSettingsAsync(userSettings);

            return new SuccessResult(message.WebPage);
        }
    }
}