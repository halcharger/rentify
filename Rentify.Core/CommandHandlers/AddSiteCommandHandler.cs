using System.Threading.Tasks;
using MediatR;
using Rentify.Core.Data;
using Rentify.Core.Data.Entities;

namespace Rentify.Core.CommandHandlers
{
    public class AddSiteCommandHandler : IAsyncRequestHandler<AddSiteCommand, ICommandResult>
    {
        private readonly IRentifyDataFacade data;

        public AddSiteCommandHandler(IRentifyDataFacade data)
        {
            this.data = data;
        }

        public async Task<ICommandResult> Handle(AddSiteCommand message)
        {
            var siteUniqueIdIndex = await data.RetrieveSiteUniqueIdIndexAsync(message.Site.UniqueId);

            if (siteUniqueIdIndex != null)
                return new FailureResult("A site with this Unique ID already is in use in the system.");

            var userSettings = await data.RetrieveUserSettingsAsync(message.UserId);

            if (userSettings == null)
            {
                userSettings = new UserSettings(message.UserId);
                userSettings.SetPartionAndRowKeys();                
            }

            var settings = userSettings.GetRentifySettings();
            settings.Sites.Add(message.Site);
            userSettings.SetRentitifySettings(settings);

            await data.AddSiteUniqueIdIndexAsync(message.Site.UniqueId, message.UserId);
            await data.UpdateUserSettingsAsync(userSettings);

            return new SuccessResult();
        }
    }
}