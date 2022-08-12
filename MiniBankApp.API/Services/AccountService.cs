using MiniBankApp.API.Helpers.Base;
using MiniBankApp.API.Models;
using MiniBankApp.API.Services.Base;

namespace MiniBankApp.API.Services;

public class AccountService: IAccountService
{
    private readonly IFileService _fileService;
    private readonly IConvert<AccountInformation> _convert;
    private readonly IDateTimeConvert _convertDateTime;
    public AccountService(IFileService fileService, IConvert<AccountInformation> convert, IDateTimeConvert convertDateTime)
    {
        _fileService = fileService;
        _convert = convert;
        _convertDateTime = convertDateTime;
    }
    
    /// <summary>
    /// Read file path from appSettingsDevelopment, and after finding start to deserialize.
    /// </summary>
    /// <returns>AccountInformation</returns>
    public AccountInformation GetAccountInformation()
    {
        //var data = _fileService.ReadFileFromAppSettings("jsonData");
        string data = _fileService.ReadJsonFromLocalVariable();
        return _convert.Deserialize(data);
    }
    
    /// <summary>
    /// Get Statements by given date (from, to)
    /// </summary>
    /// <param name="fromDate"></param>
    /// <param name="toDate"></param>
    /// <returns></returns>
    public List<AccountStatement> GetStatementsByDate(string fromDate, string toDate)
    {
        List<AccountStatement> statements = new List<AccountStatement>();
        var accountInformation = GetAccountInformation();
        
        if (accountInformation == null)
        {
            return null;
        }

        statements = accountInformation.Statements;
            
        if (statements == null)
        {
            return null;
        }
        
        var accountStatements = statements.FindAll(acc =>
            _convertDateTime.GetDateTime(fromDate) <= _convertDateTime.GetDateTime(acc.TransactionDate) &&
            _convertDateTime.GetDateTime(toDate) >= _convertDateTime.GetDateTime(acc.TransactionDate));

        return accountStatements;
    }
    
    /// <summary>
    /// Get Account Report with Income, Outcome, Balance and statements.
    /// </summary>
    /// <param name="statements">List of statements</param>
    /// <returns>AccountReport object with income, outcome, curBalance</returns>
    public AccountReport GetAccountReport(List<AccountStatement> statements)
    {
        if (statements == null)
        {
            return new AccountReport()
            {
                CurrentBalance = 0,
                Income = 0,
                Outcome = 0,
                Statements = new List<AccountStatement>()
            };
        }

        var income = statements.FindAll(x => x.Income).Sum(x => x.Amount);
        var outcome = statements.FindAll(x => !x.Income).Sum(x => x.Amount);
        var currentBalance = income - outcome;

        var accReport = new AccountReport()
        {
            CurrentBalance = currentBalance,
            Income = income,
            Outcome = outcome,
            Statements = statements
        };

        return accReport;
    }
}