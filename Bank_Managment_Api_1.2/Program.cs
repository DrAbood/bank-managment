using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Bank_Managment_Api_1._2.Data;
using Bank_Managment_Api_1._2.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;

// using Bank_Managment_Api_1._2.Module.BankManagmentModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// builder.Services.AddDbContext<BankAccountContext>(opt =>
//     opt.UseInMemoryDatabase("BankAccount"));
// builder.Services.AddDbContext<BankAccountContext>(options =>
// options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var connString = builder.Configuration.GetConnectionString("BankAccount");
builder.Services.AddSqlite<BankAccountContext>(connString);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "JWT Authntication", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http, 
        Scheme = "bearer",              
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter your JWT token"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference 
                { 
                    Type = ReferenceType.SecurityScheme, 
                    Id = "Bearer" 
                }
            },
            Array.Empty<string>()
        }
    });
});

// builder.Services.AddScoped<IBankManagementFunctions,BankManagmentFunctions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Events = new JwtBearerEvents
        {
                OnTokenValidated = async context =>
            {
                var jti = context.Principal?.FindFirstValue(JwtRegisteredClaimNames.Jti);
                if (jti == null) return;

                var dbContext = context.HttpContext.RequestServices.GetRequiredService<BankAccountContext>();
                var isBlacklisted = await dbContext.tokenblacklist.AnyAsync(t => t.Jiti == jti);

                if (isBlacklisted)
                {
                    context.Fail("Token is blacklisted");
                }
            }
        };
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "localHost",
            ValidAudience = "audience",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("some-key-that-will-change-eventually"))
        };
    });

// builder.Services.AddScoped<IHelpfulFunctions,HelpfulFunctions>();
builder.Services.AddAuthorization();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MigrateDb();




app.Run();
