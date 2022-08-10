using MiniBankApp.API.Helpers;
using MiniBankApp.API.Helpers.Base;
using MiniBankApp.API.Models;
using MiniBankApp.API.Services;
using MiniBankApp.API.Services.Base;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IConvert<AccountInformation>, JsonConverterService<AccountInformation>>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IDateTimeConvert, DateTimeConvertService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();