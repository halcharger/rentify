using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Rentify.Core.Data;
using Rentify.Core.Data.Entities;
using Rentify.Core.Results;

namespace Rentify.Core.CommandHandlers
{
    public class DeleteSiteCommandHandler : IAsyncRequestHandler<DeleteSiteCommand, IResult>
    {
        private readonly IRentifyDataFacade data;

        public DeleteSiteCommandHandler(IRentifyDataFacade data)
        {
            this.data = data;
        }

        public async Task<IResult> Handle(DeleteSiteCommand message)
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

            //TODO: need to check result1 and result2 for success

            return SimpleResult.Success();
        }
    }
}