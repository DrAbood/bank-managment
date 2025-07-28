using Bank_Managment_API.Data;
using Bank_Managment_API.Endpoints;
var builder = WebApplication.CreateBuilder(args);


//There is an error here solve it 
var connString = builder.Configuration.GetConnectionString("BankAccount");
builder.Services.AddSqlite<BankAccountContext>(connString);

var app = builder.Build();

app.MapBankAccountEndpoints();

app.MigrateDb();
app.Run();
