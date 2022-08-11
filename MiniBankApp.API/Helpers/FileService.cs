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

    public string ReadJsonFromLocalVariable()
    {
        string json = "{\"client\":\"MuradNasibli\",\"clientId\":\"1NJ2TDV\",\"accountNumber\":\"4012D0023124\"," +
                      "\"statements\":[{\"transactionDate\":\"08-07-2022 14:26:45\",\"description\":\"VAT,AIRALOE-SIM\",\"amount\":255,\"income\":false}," +
                      "{\"transactionDate\":\"10-07-2022 22:26:45\",\"description\":\"\",\"amount\":42,\"income\":false},{\"transactionDate\":\"18-07-2022 10:26:45\"," +
                      "\"description\":\"\",\"amount\":55,\"income\":false},{\"transactionDate\":\"22-07-2022 10:26:45\",\"description\":\"\",\"amount\":505,\"income\":true},{\"transactionDate\":" +
                      "\"25-07-2022 10:26:45\",\"description\":\"\",\"amount\":213.64,\"income\":true},{\"transactionDate\":\"29-07-2022 10:26:45\",\"description\":\"\",\"amount\":32.53,\"income\":false}," +
                      "{\"transactionDate\":\"30-07-2022 10:26:45\",\"description\":\"\",\"amount\":82.23,\"income\":false},{\"transactionDate\":\"31-07-2022 10:26:45\",\"description\":\"\",\"amount\":0.84," +
                      "\"income\":false},{\"transactionDate\":\"01-08-2022  10:26:45\",\"description\":\"Terminal\",\"amount\":1500.24,\"income\":true},{\"transactionDate\":\"07-08-2022 10:26:45\",\"description\"" +
                      ":\"\",\"amount\":923.24,\"income\":false}]}";
        return json;
    }
}