namespace MiniBankApp.API.Models;

public class AccountInformation
{
    public string Client { get; set; }
    public string ClientId { get; set; }
    public string AccountNumber { get; set; }
    public List<AccountStatement> Statements { get; set; }
}