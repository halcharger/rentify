using System.IO;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Rentify.Core.Data.BlobStorage
{
    public interface IRentifyBlobStorageFacade
    {
        Task UploadCustomMapImageBlob(string siteUniqueId, FileStream file);
        Task UploadGalleryImageBlob(string siteUniqueId, string fileName, FileStream file);
    }

    public class RentifyBlobStorageFacade : IRentifyBlobStorageFacade
    {
        private readonly CloudBlobClient blobClient;

        public RentifyBlobStorageFacade()
        {
            var connectionString = RentifyConfig.RentifyAzureStorageConnectionString;
            var storageAccount = CloudStorageAccount.Parse(connectionString);
            blobClient = storageAccount.CreateCloudBlobClient();
        }

        public async Task UploadCustomMapImageBlob(string siteUniqueId, FileStream file)
        {
            await UploadBlob(siteUniqueId, "custommapimage", file);
        }

        public async Task UploadGalleryImageBlob(string siteUniqueId, string fileName, FileStream file)
        {
            await UploadBlob(siteUniqueId, fileName, file);
        }

        protected async Task UploadBlob(string container, string blobname, FileStream file)
        {
            var blobContainer = blobClient.GetContainerReference(container);

            await blobContainer.CreateIfNotExistsAsync();
            blobContainer.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

            var blob = blobContainer.GetBlockBlobReference(blobname);

            blob.UploadFromStream(file);
        }
    }
}