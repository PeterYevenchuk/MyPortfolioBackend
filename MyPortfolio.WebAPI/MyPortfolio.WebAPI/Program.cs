using Microsoft.EntityFrameworkCore;
using MyPortfolio.Core;
using MyPortfolio.Core.Context;

namespace MyPortfolio.WebAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<MyPortfolioDbContext>(
            d => d.UseNpgsql(builder.Configuration.GetConnectionString("SqlConnectionString")));

        CoreServiceConfiguration.ConfigureServices(builder.Services);

        builder.Services.AddControllers();

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

        app.Run();
    }
}