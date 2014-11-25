using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Rentify.WebServer.Data;
using Rentify.WebServer.Data.Entities;

namespace Rentify.WebServer.CommandHandlers
{
    public class DeleteSiteCommandHandler : IAsyncRequestHandler<DeleteSiteCommand, ICommandResult>
    {
        private readonly IRentifyDataFacade data;

        public DeleteSiteCommandHandler(IRentifyDataFacade data)
        {
            this.data = data;
        }

        public async Task<ICommandResult> Handle(DeleteSiteCommand message)
        {
            var userSettings = await data.RetrieveUserSettingsAsync(message.UserId);

            if (userSettings == null)
            {
                userSettings = new UserSettings(message.UserId);
                userSettings.SetPartionAndRowKeys();
            }

            var settings = userSettings.GetRentifySettings();
            settings.Sites.Remove(settings.Sites.SingleOrDefault(s => s.UniqueId == message.SiteUniqueId));
            userSettings.SetRentitifySettings(settings);

            var result1 = await data.UpdateUserSettingsAsync(userSettings);
            var result2 = await data.DeleteSiteUniqueIdIndexAsync(message.SiteUniqueId);

            return new SuccessResult();
        }
    }
}