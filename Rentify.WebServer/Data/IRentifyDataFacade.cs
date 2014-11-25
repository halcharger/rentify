using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;
using Rentify.WebServer.Data.Entities;

namespace Rentify.WebServer.Data
{
    public interface IRentifyDataFacade
    {
        Task<UserSettings> RetrieveUserSettingsAsync(string userId);
        Task<SiteUniqueIdIndex> RetrieveSiteUniqueIdIndexAsync(string siteUniqueId);
        Task<TableResult> AddSiteUniqueIdIndexAsync(string siteUniqueId, string userId);
        Task<TableResult> DeleteSiteUniqueIdIndexAsync(string siteUniqueId);
        Task<TableResult> UpdateUserSettingsAsync(UserSettings userSettings);
    }
}