using System;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
// using Bank_Managment_Api_1._2.LoggerFolder;
namespace Bank_Managment_Api_1._2.Excepetion_Handler;

public static class GlobalExceptionHandler
{
    // private readonly ILogger<GlobalExceptionHandler> _logger;


    //     public  GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    // {
    //     _logger = logger;
    // }

    // public ValueTask<bool> TryHandleAsync(
    //     HttpContext httpContext,
    //     Exception exception,
    //     CancellationToken cancellationToken)
    // {
    //     var exceptionMessage = exception.Message;
    // _logger.LogInformation(
    //     "Error Message: {exceptionMessage}, Time of occurrence {time}",
    //     exceptionMessage, DateTime.UtcNow);


    //     // Return false to continue with the default behavior
    // // - or - return true to signal that this exception is handled
    // return ValueTask.FromResult(false);
    // }
    // private static readonly ILogger _logger;

    public static void AddExceptionHandler(this IApplicationBuilder app)
    {
    app.UseExceptionHandler(error =>
    {
        error.Run(async context =>
        {

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
            if (contextFeature != null)
            {
                string message = "Internal server error";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(message));
            }
        });
    });
    }
    // private readonly RequestDelegate _next;
    // private readonly ILogger<GlobalExceptionHandler> _Logger;

    // public GlobalExceptionHandler(RequestDelegate next, ILogger<GlobalExceptionHandler> logger)
    // {
    //     _next = next;
    //     _Logger = logger;
    // }

    // public async Task InvokAsync(HttpContext context)
    // {
    //     try
    //     {
    //         await _next(context);
    //     }
    //     catch (Exception ex)
    //     {
    //         await HandleExceptionAsync(context, ex);
    //     }
    // }

    // private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    // {
    //     context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
    //     context.Response.ContentType = "application/json";
    //             return context.Response.WriteAsync("");
    // }
}


