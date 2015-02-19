using System.Threading.Tasks;
using MediatR;
using Rentify.Core.Data;
using Rentify.Core.Data.Entities;
using Rentify.Core.Domain;
using Rentify.Core.Results;

namespace Rentify.Core.CommandHandlers
{
    public class AddSiteCommandHandler : IAsyncRequestHandler<AddSiteCommand, IResult>
    {
        private readonly IRentifyDataFacade data;

        public AddSiteCommandHandler(IRentifyDataFacade data)
        {
            this.data = data;
        }

        public async Task<IResult> Handle(AddSiteCommand message)
        {
            var siteUniqueIdIndex = await data.RetrieveSiteUniqueIdIndexAsync(message.UniqueId);

            if (siteUniqueIdIndex != null)
                return SimpleResult.Failure("A site with this Unique ID already is in use in the system.");

            var userSettings = await data.RetrieveUserSettingsAsync(message.UserId);

            if (userSettings == null)
            {
                userSettings = new UserSettings(message.UserId);
                userSettings.SetPartionAndRowKeys();                
            }

            var settings = userSettings.GetRentifySettings();
            settings.Sites.Add(new RentifySite{UniqueId = message.UniqueId, Name = message.Name});
            userSettings.SetRentitifySettings(settings);

            await data.AddSiteUniqueIdIndexAsync(message.UniqueId, message.UserId);
            await data.UpdateUserSettingsAsync(userSettings);

            return SimpleResult.Success();
        }
    }
}