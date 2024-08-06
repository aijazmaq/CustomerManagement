using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Service.Implementation;
using Service.Interface;
using Infrastructure.Helper;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IServiceCollection services = builder.Services;

//connection string to make connection with db 
builder.Services.AddDbContext<DataBaseContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection")));

//services.AddDbContext<DataBaseContext>(o=> o.UseInMemoryDatabase("TestDB"));
services.AddScoped<ICustomerService, CustomerService>();
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
