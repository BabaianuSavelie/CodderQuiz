using Application;
using Carter;
using Infrastructure;

namespace Presentation;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();


        // Add Services
        builder.Services.AddApplicationServices()
                        .AddInfrastructureServices(builder.Configuration)
                        .AddPresentationServices();


        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseCors("CORSPolicy");
        app.UseAuthorization();

        app.MapCarter();
        

        app.Run();
    }
}
