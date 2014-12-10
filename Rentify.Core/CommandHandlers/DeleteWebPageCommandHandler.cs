using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Rentify.Core.Data;

namespace Rentify.Core.CommandHandlers
{
    public class DeleteWebPageCommandHandler : IAsyncRequestHandler<DeleteWebPageCommand, ICommandResult>
    {
        private readonly IRentifyDataFacade data;

        public DeleteWebPageCommandHandler(IRentifyDataFacade data)
        {
            this.data = data;
        }

        public async Task<ICommandResult> Handle(DeleteWebPageCommand message)
        {
            var userSettings = await data.RetrieveUserSettingsAsync(message.UserId);

            if (userSettings == null)
                return new FailureResult("There are no user settings for UserId: {0}", message.UserId);

            var settings = userSettings.GetRentifySettings();
            var site = settings.Sites.SingleOrDefault(s => s.UniqueId == message.SiteUniqueId);

            if (site == null)
                return new FailureResult("Could not find a site with the unique ID {0} for user {1}",
                        message.SiteUniqueId, message.UserId);

            var webpage = site.Pages.SingleOrDefault(p => p.Id == message.WebPageId);
            if (webpage == null)
                return new FailureResult("Could not find WebPage with Id {0} for site {1}", message.WebPageId,
                    message.SiteUniqueId);

            site.Pages.Remove(webpage);

            userSettings.SetRentitifySettings(settings);
            await data.UpdateUserSettingsAsync(userSettings);

            return new SuccessResult();
        }
    }
}