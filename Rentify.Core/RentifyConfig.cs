using System.Configuration;
using System.Linq;

namespace Rentify.Core
{
    public static class RentifyConfig
    {
        public static string RentifyAzureStorageConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["UserStore-ConnectionString"].ConnectionString; }
        }

        public static string RentifyAzureStorageConnectionStringAccountName
        {
            get
            {
                var cn = RentifyAzureStorageConnectionString;
                var items = cn.Split(';');
                var item = items.Single(i => i.Contains("AccountName"));
                return item.Split('=')[1];
            }
        }
    }
}