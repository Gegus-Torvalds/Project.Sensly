using Sensly.Models;
using Sensly.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Http.HttpResults;
using Sensly.Infrastructure.StartupExtension;
using Scalar.AspNetCore;


namespace Sensly
{
    public class Program
    {
        public static void Main(string[] args)
        {




            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSignalR();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("EnableLiveServer", policy =>
                {
                    policy.WithOrigins("http://localhost:8080", "http://127.0.0.1:8080")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();
                });
            });

            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddControllers();
            builder.Services.AddOpenApi(); 
            var app = builder.Build();





            app.MapOpenApi();
            app.MapScalarApiReference();
            app.MapControllers();





            app.UseCors("EnableLiveServer");
            app.MapHub<ClickHub>("/ClickHub");

            /*
             app.MapGet("/api/click", (HttpContext context) =>
            {
                var method = context.Request.Method;
                return $"Hello ClicK World! - {method}";

            });


             app.MapPost("/api/click",async (ClickData clkData, IHubContext<ClickHub> clickHubContext)=>
            {

                await clickHubContext.Clients.All.SendAsync("OnClick", clkData.NumberOfClicks);

                return Results.Ok(new { message = "Sent to frontend succesfully" });

            } );
            */

            app.Run();
        }

       
    }
}
