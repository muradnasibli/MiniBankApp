namespace MiniBankApp.API.Models;

public class AccountStatement
{
    public string TransactionDate { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public bool Income { get; set; }
}