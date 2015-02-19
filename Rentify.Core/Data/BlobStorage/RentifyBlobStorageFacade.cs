using System.IO;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Rentify.Core.Data.BlobStorage
{
    public interface IRentifyBlobStorageFacade
    {
        Task UploadImageBlob(string containerName, string blobName, FileStream file);
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

        public async Task UploadImageBlob(string containerName, string blobName, FileStream file)
        {
            var blobContainer = blobClient.GetContainerReference(containerName);

            await blobContainer.CreateIfNotExistsAsync();
            blobContainer.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

            var blob = blobContainer.GetBlockBlobReference(blobName);

            blob.UploadFromStream(file);
        }
    }
}