using MiniBankApp.API.Models;

namespace MiniBankApp.API.Services.Base;

public interface IAccountService
{
    AccountInformation GetAccountInformation();
    List<AccountStatement> GetMonthlyIncome();
    List<AccountStatement> GetMonthlyOutcome();
}