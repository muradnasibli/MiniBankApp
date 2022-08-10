namespace MiniBankApp.API.Models;

public class AccountReport
{
    public decimal CurrentBalance { get; set; }
    public decimal Income { get; set; }
    public decimal Outcome { get; set; }
    public List<AccountStatement> Statements { get; set; }
}