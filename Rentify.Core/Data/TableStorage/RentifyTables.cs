using System.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace Rentify.Core.Data.TableStorage
{
    public class RentifyTables
    {
        public const string UserSettingsTableName = "UserSetting";
        public const string SiteUniqueIdIndexTableName = "SiteUniqueIdIndex";

        public RentifyTables() : this("UserStore-ConnectionString") { }
        public RentifyTables(string connectionStringName)
        {
            var connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            var storageAccount = CloudStorageAccount.Parse(connectionString);
            var tableClient = storageAccount.CreateCloudTableClient();

            UserSettingsTable = tableClient.GetTableReference(UserSettingsTableName);
            SiteUniqueIdIndexTable = tableClient.GetTableReference(SiteUniqueIdIndexTableName);

            UserSettingsTable.CreateIfNotExists();
            SiteUniqueIdIndexTable.CreateIfNotExists();
        }

        public CloudTable UserSettingsTable { get; private set; }
        public CloudTable SiteUniqueIdIndexTable { get; set; }
    }
}