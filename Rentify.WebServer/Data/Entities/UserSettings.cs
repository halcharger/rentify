using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using NExtensions;
using Rentify.WebServer.Domain;

namespace Rentify.WebServer.Data.Entities
{
    public class UserSettings : TableEntity
    {
        public UserSettings() { }

        public UserSettings(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; set; }
        public string RentifySettingsJson { get; set; }

        public RentifySettings GetRentifySettings()
        {
            return RentifySettingsJson.HasValue()
                ? JsonConvert.DeserializeObject<RentifySettings>(RentifySettingsJson)
                : new RentifySettings();
        }

        public void SetRentitifySettings(RentifySettings settings)
        {
            RentifySettingsJson = JsonConvert.SerializeObject(settings);
        }

        public void SetPartionAndRowKeys()
        {
            PartitionKey = UserId;
            RowKey = UserId;
        }
    }
}