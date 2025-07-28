using System;
using Microsoft.EntityFrameworkCore;

namespace Bank_Managment_Api_1._2.Data;

public static class DataExtentions
{
    public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var DbContext = scope.ServiceProvider.GetRequiredService<BankAccountContext>();
        DbContext.Database.Migrate();
    }
}
