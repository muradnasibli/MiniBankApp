using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MiniBankApp.API.Helpers;
using MiniBankApp.API.Models;
using MiniBankApp.API.Services;
using Xunit;

namespace MiniBankApp.Test;

public class AccountServiceTest
{
    List<AccountStatement> statements = new List<AccountStatement>()
    {
        new AccountStatement()
        {
            Amount = 255,
            Description = "VAT, AIRALO E-SIM",
            Income = true,
            TransactionDate = "08-07-2022",
        },
        new AccountStatement()
        {
            Amount = 25,
            Description = "",
            Income = false,
            TransactionDate = "10-07-2022",
        },
        new AccountStatement()
        {
            Amount = 35,
            Description = "",
            Income = true,
            TransactionDate = "18-07-2022",
        },
        new AccountStatement()
        {
            Amount = 65,
            Description = "",
            Income = false,
            TransactionDate = "22-07-2022",
        }
    };
    
    List<AccountStatement> expectedStatements = new List<AccountStatement>()
    {
        new AccountStatement()
        {
            Amount = 5,
            Description = "",
            Income = true,
            TransactionDate = "01-07-2022",
        },
        new AccountStatement()
        {
            Amount = 25,
            Description = "",
            Income = false,
            TransactionDate = "02-07-2022",
        },
        new AccountStatement()
        {
            Amount = 35,
            Description = "",
            Income = true,
            TransactionDate = "03-07-2022",
        }
    };
    
    [Fact]
    public void GetAccountReport_InputList_Returns_Income()
    {
        // Arrange
        var accountService = new AccountService(new FileService(new ConfigurationManager()),
            new JsonConverterService<AccountInformation>(), new DateTimeConvertService());

        // Act
        var result = accountService.GetAccountReport(statements);
        const decimal income = 290;
        
        // Assert
        Assert.Equal(income, result.Income);
    }

    [Fact]
    public void GetAccountReport_InputList_Returns_Outcome()
    {
        // Arrange
        var accountService = new AccountService(new FileService(new ConfigurationManager()),
            new JsonConverterService<AccountInformation>(), new DateTimeConvertService());

        // Act
        var result = accountService.GetAccountReport(statements);
        
        // Assert
        Assert.Equal(90, result.Outcome);
    }
    
    [Fact]
    public void GetAccountReport_InputList_Returns_CurrentBalance()
    {
        // Arrange
        var accountService = new AccountService(new FileService(new ConfigurationManager()),
            new JsonConverterService<AccountInformation>(), new DateTimeConvertService());
        
        // Act
        var result = accountService.GetAccountReport(statements);
        const decimal expectedValue = 200;
        // Assert
        Assert.Equal(expectedValue, result.CurrentBalance);
    }

    [Fact]
    public void GetStatementsByDate_InputStr_FromDate_ToDate_Returns_Statement_NotNull()
    {
        // Arrange
        var accountService = new AccountService(new FileService(new ConfigurationManager()),
            new JsonConverterService<AccountInformation>(), new DateTimeConvertService());
        
        // Act
        var result = accountService.GetStatementsByDate("01/07/2022", "10/07/2022");

        // Assert
        Assert.NotNull(result);
    }
    
    [Theory]
    [InlineData("01/07/2022", "10/07/2022")]
    [InlineData("01-07-2022", "10-7-2022")]
    [InlineData("01.07.2022", "10.07.2022")]
    [InlineData("07.01.2022", "07.10.2022")]
    [InlineData("2022-07-01", "2022-07-01")]
    [InlineData("07-2022-01", "07-2022-10")]
    public void GetStatementByDate_InputStr_Right_DateFormat(string fromDate, string toDate)
    {
        // Arrange
        var accountService = new AccountService(new FileService(new ConfigurationManager()),
            new JsonConverterService<AccountInformation>(), new DateTimeConvertService());
        
        // Act
        var result = accountService.GetStatementsByDate(fromDate, toDate);

        // Assert
        Assert.NotNull(result);
    }
    
    [Fact]
    public void GetAccountInformation()
    {
        // Arrange
        var accountService = new AccountService(new FileService(new ConfigurationManager()),
            new JsonConverterService<AccountInformation>(), new DateTimeConvertService());

        // Act
        var result = accountService.GetAccountInformation();
        
        // Assert
        Assert.NotNull(result);
    }
}