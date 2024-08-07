using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Service.Implementation;
using Service.Interface;
using Infrastructure.Helper;
using FluentValidation.AspNetCore;
using System.Reflection;
using FluentValidation;
using Infrastructure.DataModel;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
    //.AddFluentValidation(v =>
    //{
    //    v.ImplicitlyValidateChildProperties = true;
    //    v.ImplicitlyValidateRootCollectionElements = true;
    //    v.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    //});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IServiceCollection services = builder.Services;

//connection string to make connection with db 
builder.Services.AddDbContext<DataBaseContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection")));

//services.AddDbContext<DataBaseContext>(o=> o.UseInMemoryDatabase("TestDB"));
services.AddScoped<ICustomerService, CustomerService>();
//services.AddScoped<IValidationRule,CustomerRequestValidtion(CustomerRequest) > ();
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
