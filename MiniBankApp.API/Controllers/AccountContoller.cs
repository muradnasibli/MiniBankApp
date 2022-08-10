using Microsoft.AspNetCore.Mvc;
using MiniBankApp.API.Models;
using MiniBankApp.API.Services.Base;

namespace MiniBankApp.API.Controllers;

[ApiController]
[Route("api/account")]
public class AccountContoller : Controller
{
    private readonly IAccountService _accountService;
    public AccountContoller(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet]
    public IActionResult GetAccountInformation()
    {
        try
        {
            var accInfo = _accountService.GetAccountInformation();
            if (accInfo == null)
            {
                return NotFound();
            }
            return Ok(accInfo);
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
    
    [HttpGet("/GetAccountReportyByDate")]
    public IActionResult GetAccountReportByDate(string fromDate, string toDate)
    {
        try
        {
            var statements = _accountService.GetStatementsByDate(fromDate, toDate);
            
            if (statements.Any() == false)
            {
                return NotFound();
            }

            var accBalance = _accountService.GetAccountReport(statements);
            
            if (accBalance == null)
            {
                return NotFound();
            }

            return Ok(accBalance);
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
}