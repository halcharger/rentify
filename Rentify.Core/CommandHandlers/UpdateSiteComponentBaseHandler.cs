using System;
using System.Threading.Tasks;
using MediatR;
using NExtensions;
using Rentify.Core.Data;
using Rentify.Core.Data.Entities;
using Rentify.Core.Domain;
using Rentify.Core.Results;

namespace Rentify.Core.CommandHandlers
{
    public abstract class UpdateSiteComponentBaseHandler<TCommand> : IAsyncRequestHandler<TCommand, IResult> 
        where TCommand : UpdateSiteComponentBaseCommand 
    {
        protected readonly IRentifyDataFacade data;
        protected UserSettings userSettings;
        protected RentifySettings settings;
        protected RentifySite site;
        protected IResult result = SimpleResult.Success();

        protected UpdateSiteComponentBaseHandler(IRentifyDataFacade data)
        {
            this.data = data;
        }

        public abstract Task<IResult> InnerHandle(TCommand message);

        protected async Task SetSiteAsync(string userId, string siteUniqueId)
        {
            userSettings = await data.RetrieveUserSettingsAsync(userId);

            if (userSettings == null)
                result = SimpleResult.Failure("There are no user settings for UserId: {0}".FormatWith(userId));

            settings = userSettings.GetRentifySettings();
            site = settings.GetSiteByUniqueId(siteUniqueId);

            if (site == null)
                result = SimpleResult.Failure("Could not find a site with the unique ID {0} for user {1}".FormatWith(siteUniqueId, userId));
        }

        protected async Task<IResult>  SaveAsync()
        {
            if (result.IsFailure) return result;

            userSettings.SetRentitifySettings(settings);
            var updateResult = await data.UpdateUserSettingsAsync(userSettings);

            if (updateResult.HttpStatusCode >= 200 && updateResult.HttpStatusCode < 300)
                return SimpleResult.Success();

            return SimpleResult.Failure("Received HttpStatusCode: {0} when saving site data.".FormatWith(updateResult.HttpStatusCode));
        }

        public async Task<IResult> Handle(TCommand message)
        {
            await SetSiteAsync(message.UserId, message.SiteUniqueId);

            if (result.IsFailure) return result;

            result = await InnerHandle(message);
            
            if (result.IsFailure) return result;

            return await SaveAsync();
        }
    }
}