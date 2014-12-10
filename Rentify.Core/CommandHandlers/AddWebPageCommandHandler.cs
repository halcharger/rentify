using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Rentify.Core.Data;

namespace Rentify.Core.CommandHandlers
{
    public class AddWebPageCommandHandler : IAsyncRequestHandler<AddWebPageCommand, ICommandResult>
    {
        private readonly IRentifyDataFacade data;

        public AddWebPageCommandHandler(IRentifyDataFacade data)
        {
            this.data = data;
        }

        public async Task<ICommandResult> Handle(AddWebPageCommand message)
        {
            var userSettings = await data.RetrieveUserSettingsAsync(message.UserId);

            if (userSettings == null)
                return new FailureResult("There are no user settings for UserId: {0}", message.UserId);

            var settings = userSettings.GetRentifySettings();
            var site = settings.Sites.SingleOrDefault(s => s.UniqueId == message.SiteUniqueId);

            if (site == null)
                return new FailureResult("Could not find a site with the unique ID {0} for user {1}",
                        message.SiteUniqueId, message.UserId);

            message.WebPage.Id = site.Pages.Max(p => p.Id) + 1;
            site.Pages.Add(message.WebPage);

            userSettings.SetRentitifySettings(settings);
            await data.UpdateUserSettingsAsync(userSettings);

            return new SuccessResult();
        }
    }
}