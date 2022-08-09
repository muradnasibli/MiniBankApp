using Microsoft.AspNetCore.Mvc;
using MiniBankApp.API.Models;
using MiniBankApp.API.Services.Base;

namespace MiniBankApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountContoller : Controller
{
    private readonly IAccountService _accountService;
    // GET
    public AccountContoller(IAccountService accountService)
    {
        _accountService = accountService;
    }
    
    [HttpGet("/GetAccountInformation")]
    public AccountInformation GetAccountInformation()
    {
        return _accountService.GetAccountInformation();
    }

    // [HttpGet]
    // public void GetMonthlyIncome(string fromDate, string toDate)
    // {
    //     _accountService.GetMonthlyIncome();
    // }
    //
    // [HttpGet]
    // public void GetMontylyOutcome(string fromDate, string toDate)
    // {
    //     _accountService.GetMonthlyOutcome();
    // }
}