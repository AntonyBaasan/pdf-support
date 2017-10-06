namespace FileManager.Service
{
    public interface IFileManagerService
    {
        bool SaveFile(string fileName, byte[] content);
    }
}