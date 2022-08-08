namespace MiniBankApp.API.Models;

public class AccountInformation
{
    public string Client { get; set; }
    public string ClientId { get; set; }
    public string AccountNumber { get; set; }
    public List<AccountStatement> Statements { get; set; }
    public decimal CurrentAccBalance { get; set; }
    public decimal TotalIncome { get; set; }
    public decimal TotalOutcome { get; set; }
}