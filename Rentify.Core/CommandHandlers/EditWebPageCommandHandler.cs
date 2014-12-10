using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Rentify.Core.Data;

namespace Rentify.Core.CommandHandlers
{
    public class EditWebPageCommandHandler : IAsyncRequestHandler<EditWebPageCommand, ICommandResult>
    {
        private readonly IRentifyDataFacade data;

        public EditWebPageCommandHandler(IRentifyDataFacade data)
        {
            this.data = data;
        }

        public async Task<ICommandResult> Handle(EditWebPageCommand message)
        {
            var userSettings = await data.RetrieveUserSettingsAsync(message.UserId);

            if (userSettings == null)
                return new FailureResult("There are no user settings for UserId: {0}", message.UserId);

            var settings = userSettings.GetRentifySettings();
            var site = settings.Sites.SingleOrDefault(s => s.UniqueId == message.SiteUniqueId);

            if (site == null)
                return new FailureResult("Could not find a site with the unique ID {0} for user {1}",
                        message.SiteUniqueId, message.UserId);

            var webpage = site.Pages.SingleOrDefault(p => p.Id == message.WebPage.Id);
            if (webpage == null)
                return new FailureResult("Could not find WebPage with Id {0} for site {1}", message.WebPage.Id,
                    message.SiteUniqueId);

            site.Pages.Remove(webpage);//remove the old
            site.Pages.Add(message.WebPage);//add the new

            userSettings.SetRentitifySettings(settings);
            await data.UpdateUserSettingsAsync(userSettings);

            return new SuccessResult();
            
        }
    }
}