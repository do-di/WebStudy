using Microsoft.Extensions.Configuration;
using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using Domain.Interface.Storage;

namespace Infrastructure.Storage
{
    public class AzureStorage : IAzureStorage
    {
        private readonly IConfiguration configuration;
        private readonly string blobContainer;
        private readonly BlobContainerClient containerClient;

        public AzureStorage(IConfiguration configuration)
        {
            this.configuration = configuration;
            var connectionString = this.configuration["BlobStorageConnectionString"] ?? string.Empty;
            ArgumentException.ThrowIfNullOrEmpty(connectionString);
            blobContainer = this.configuration["BlobContainer"] ?? string.Empty;
            ArgumentException.ThrowIfNullOrEmpty(blobContainer);
            containerClient = new BlobContainerClient(connectionString, blobContainer);
        }

        public void UploadFile(string path, Stream file)
        {
            containerClient.UploadBlob(path, file);
        }

        public Uri? GetBlobSas(string path)
        {
            var blobClient = containerClient.GetBlobClient(path);
            if (!blobClient.CanGenerateSasUri)
                return null;
            return blobClient.GenerateSasUri(BlobSasPermissions.Read, DateTimeOffset.UtcNow.AddHours(1));
        }
    }
}
