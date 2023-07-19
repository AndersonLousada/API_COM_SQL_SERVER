using ApiTesteSQLServer.Migrations;
using ApiTesteSQLServer.Repositorio;
using FluentMigrator.Runner;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<RepositorioSqlServer>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        using (var serviceProvider = ExecutarMigracoes.CreateServices())
        using (var scope = serviceProvider.CreateScope())
        {
            ExecutarMigracoes.UpdateDatabase(scope.ServiceProvider);
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();

        
    }
}