namespace MiniBankApp.API.Helpers.Base;

public interface IFileService
{
    string ReadFileFromAppSettings(string configurationKey);
}