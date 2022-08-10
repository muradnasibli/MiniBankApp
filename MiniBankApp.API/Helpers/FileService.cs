using MiniBankApp.API.Helpers.Base;

namespace MiniBankApp.API.Helpers;

public class FileService : IFileService
{
    private readonly IConfiguration _configuration;

    public FileService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    // Get path of json data from appSettings with key.
    public string ReadFileFromAppSettings(string configurationKey)
    {
        var path = _configuration.GetValue<string>(configurationKey);
        return File.ReadAllText(path);
    }
}