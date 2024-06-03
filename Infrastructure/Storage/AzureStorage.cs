using Microsoft.Extensions.Configuration;
using Azure.Storage.Blobs;
namespace Infrastructure.Storage
{
    public class AzureStorage
    {
        private readonly IConfiguration configuration;
        private readonly string connectionStrsing;
        private readonly string blobContainer;
        private readonly string severStorageUri;
        public AzureStorage(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionStrsing = this.configuration["BLOB_STORAGE_CONNECTION_STRING"] ?? string.Empty;
            blobContainer = this.configuration["BLOB_CONTAINER"] ?? string.Empty;
            severStorageUri = this.configuration["SERVER_BLOB_STORAGE_URI"] ?? string.Empty;
        }

        //public UploadFile(string path, )
    }
}
