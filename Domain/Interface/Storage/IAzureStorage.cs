namespace Domain.Interface.Storage;

public interface IAzureStorage
{
    void UploadFile(string path, Stream file);

    Uri? GetBlobSas(string path);
}