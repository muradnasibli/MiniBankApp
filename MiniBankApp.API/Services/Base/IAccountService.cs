using MiniBankApp.API.Models;

namespace MiniBankApp.API.Services.Base;

public interface IAccountService
{
    AccountInformation GetAccountInformation();
    List<AccountStatement> GetStatementsByDate(string fromDate, string toDate);
    AccountReport GetAccountReport(List<AccountStatement> statements);
}