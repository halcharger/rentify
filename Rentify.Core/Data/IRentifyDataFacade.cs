using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;
using Rentify.Core.Data.Entities;

namespace Rentify.Core.Data
{
    public interface IRentifyDataFacade
    {
        UserSettings RetrieveUserSettings(string userId);
        SiteUniqueIdIndex RetrieveSiteUniqueIdIndex(string siteUniqueId);

        Task<UserSettings> RetrieveUserSettingsAsync(string userId);
        Task<SiteUniqueIdIndex> RetrieveSiteUniqueIdIndexAsync(string siteUniqueId);
        Task<TableResult> AddSiteUniqueIdIndexAsync(string siteUniqueId, string userId);
        Task<TableResult> DeleteSiteUniqueIdIndexAsync(string siteUniqueId);
        Task<TableResult> UpdateUserSettingsAsync(UserSettings userSettings);
    }
}