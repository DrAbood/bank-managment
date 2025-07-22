using Bank_Managment_Api_1._2.Data;
using Bank_Managment_Api_1._2.Entities;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// builder.Services.AddDbContext<BankAccountContext>(opt =>
//     opt.UseInMemoryDatabase("BankAccount"));
// builder.Services.AddDbContext<BankAccountContext>(options =>
// options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var connString = builder.Configuration.GetConnectionString("BankAccount");
builder.Services.AddSqlite<BankAccountContext>(connString);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MigrateDb();




app.Run();
