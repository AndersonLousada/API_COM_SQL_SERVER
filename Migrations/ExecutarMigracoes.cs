using ApiTesteSQLServer.Repositorio;
using FluentMigrator.Runner;

namespace ApiTesteSQLServer.Migrations
{
    public static class ExecutarMigracoes
    {
        public static ServiceProvider CreateServices()
        {
            var repositorio = new RepositorioSqlServer();
            string connectionString = repositorio.ObterStringDeConexao();
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb.AddSqlServer()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(typeof(_202307191229_CriarTabelaDeFuncionario).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        public static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }
    }
}
