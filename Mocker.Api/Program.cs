
using Microsoft.OpenApi.Models;

namespace Mocker.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.UseSwagger(options =>
        {
            options.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
            {

                swaggerDoc.Servers = new List<OpenApiServer>
                {
                    // You can add as many OpenApiServer instances as you want by creating them like below
                    new OpenApiServer
                    {
                        // You can set the Url from the default http request data or by hard coding it
                        Url = $"{httpReq.Scheme}://{httpReq.Host.Value}",
                        Description = "Open Weather Map"
                    },
                                new OpenApiServer
                    {
                        // You can set the Url from the default http request data or by hard coding it
                        Url = $"{httpReq.Scheme}://localhost:82",
                        Description = "Open Weather Map2"
                    }

                };
                //swaggerDoc.Paths.First().Value.Servers = new() { }
            });
        });
        app.UseSwaggerUI();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
