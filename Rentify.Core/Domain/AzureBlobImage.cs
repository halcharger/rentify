namespace Rentify.Core.Domain
{
    public class AzureBlobImage
    {
        public AzureBlobImage() { }

        public AzureBlobImage(string containerName, string blobName)
        {
            ContainerName = containerName;
            BlobName = blobName;
        }

        public string ContainerName { get; set; }
        public string BlobName { get; set; }

        public string GetAzureImageUrl()
        {
            return string.Format("http://{0}.blob.core.windows.net/{1}/{2}", RentifyConfig.RentifyAzureStorageConnectionStringAccountName, ContainerName, BlobName);
        }

        public string GetImageResizerUrl()
        {
            return string.Format("/cloud/{0}/{1}", ContainerName, BlobName);
        }

    }
}