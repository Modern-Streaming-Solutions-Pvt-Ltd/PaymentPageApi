//namespace PlanPaymentPage.Middleware
//{
//    public class ApiKeyMiddleware
//    {
//    }
//}


using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PlanPaymentPage.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string APIKEYNAME = "ApiKey";
        private string[] byPassPaths = { };
        private readonly IConfiguration _configuration;

        //SaveJobWebhhookLogs


        public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            context.Response.Headers.Add("Access-Control-Allow-Headers", new[] { "*" });
            context.Response.Headers.Add("Access-Control-Allow-Methods", new[] { "GET, POST, PUT, DELETE, OPTIONS" });
            context.Response.Headers.Add("Access-Control-Allow-Credentials", new[] { "true" });
            if (context.Request.Method == "OPTIONS")
            {

                context.Response.StatusCode = 200;
                return;// context.Response.WriteAsync("OK");
            }
            if (context.Request.Path != null && byPassPaths.Any(context.Request.Path.Value.Contains))
            {
                //Console.WriteLine(context.Request.Path);
                await _next(context);
            }
            else
            {

                if (!context.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Api Key was not provided.");
                    return;
                }

                var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();

                var apiKey = appSettings.GetValue<string>(APIKEYNAME);

                if (!apiKey.Equals(extractedApiKey))
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Unauthorized client.");
                    return;
                }
                await _next(context);
            }
        }
    }
}
