using MiniBankApp.API.Helpers.Base;
using MiniBankApp.API.Models;
using MiniBankApp.API.Services.Base;

namespace MiniBankApp.API.Services;

public class AccountService: IAccountService
{
    private readonly IFileService _fileService;
    private readonly IConvert<AccountInformation> _convert;
    
    public AccountService(IFileService fileService, IConvert<AccountInformation> convert)
    {
        _fileService = fileService;
        _convert = convert;
    }

    public AccountInformation GetAccountInformation()
    {
        var data = _fileService.ReadFileFromAppSettings("jsonData");
        return _convert.Deserialize(data);
    }

    public List<AccountStatement> GetMonthlyIncome()
    {
        throw new NotImplementedException();
    }

    public List<AccountStatement> GetMonthlyOutcome()
    {
        throw new NotImplementedException();
    }
}