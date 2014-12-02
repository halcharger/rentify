using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;
using Rentify.Core.Data.Entities;
using Rentify.Core.Data.TableStorage;

namespace Rentify.Core.Data
{
    public class RentifyDataFacade : IRentifyDataFacade
    {
        private readonly RentifyTables _tables;

        public RentifyDataFacade(RentifyTables tables)
        {
            _tables = tables;
        }

        public UserSettings RetrieveUserSettings(string userId)
        {
            return Retrieve<UserSettings>(_tables.UserSettingsTable, userId, userId);
        }

        public SiteUniqueIdIndex RetrieveSiteUniqueIdIndex(string siteUniqueId)
        {
            return Retrieve<SiteUniqueIdIndex>(_tables.SiteUniqueIdIndexTable, siteUniqueId, siteUniqueId);
        }

        public async Task<UserSettings> RetrieveUserSettingsAsync(string userId)
        {
            return await RetrieveAsync<UserSettings>(_tables.UserSettingsTable, userId, userId);
        }

        public async Task<SiteUniqueIdIndex> RetrieveSiteUniqueIdIndexAsync(string siteUniqueId)
        {
            return await RetrieveAsync<SiteUniqueIdIndex>(_tables.SiteUniqueIdIndexTable, siteUniqueId, siteUniqueId);
        }

        public async Task<TableResult> AddSiteUniqueIdIndexAsync(string siteUniqueId, string userId)
        {
            return await InsertOrReplaceAsync(_tables.SiteUniqueIdIndexTable, new SiteUniqueIdIndex(siteUniqueId, userId));
        }

        public async Task<TableResult> DeleteSiteUniqueIdIndexAsync(string siteUniqueId)
        {
            return await DeleteAsync(_tables.SiteUniqueIdIndexTable, new SiteUniqueIdIndex(siteUniqueId));
        }

        public async Task<TableResult> UpdateUserSettingsAsync(UserSettings userSettings)
        {
            return await InsertOrReplaceAsync(_tables.UserSettingsTable, userSettings);
        }

        private async Task<T> RetrieveAsync<T>(CloudTable table, string partitionKey, string rowKey) where T : ITableEntity
        {
            var retrieveOperation = TableOperation.Retrieve<T>(partitionKey, rowKey);
            var result = await table.ExecuteAsync(retrieveOperation);
            return (T)result.Result;
        }

        private T Retrieve<T>(CloudTable table, string partitionKey, string rowKey) where T : ITableEntity
        {
            var retrieveOperation = TableOperation.Retrieve<T>(partitionKey, rowKey);
            var result = table.Execute(retrieveOperation);
            return (T)result.Result;
        }

        private Task<TableResult> InsertAsync(CloudTable table, ITableEntity entity)
        {
            var insertOperation = TableOperation.Insert(entity);
            return table.ExecuteAsync(insertOperation);
        }

        private Task<TableResult> InsertOrReplaceAsync(CloudTable table, ITableEntity entity)
        {
            var insertOrReplaceOperation = TableOperation.InsertOrReplace(entity);
            return table.ExecuteAsync(insertOrReplaceOperation);
        }

        private Task<TableResult> DeleteAsync(CloudTable table, ITableEntity entity)
        {
            entity.ETag = "*";
            var deleteOperation = TableOperation.Delete(entity);
            return table.ExecuteAsync(deleteOperation);
        }

        private Task<TableResult> ReplaceAsync(CloudTable table, ITableEntity entity)
        {
            entity.ETag = "*";
            var replaceOperation = TableOperation.Replace(entity);
            return table.ExecuteAsync(replaceOperation);
        }

    }
}