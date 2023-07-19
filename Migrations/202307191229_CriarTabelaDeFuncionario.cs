using FluentMigrator;

namespace ApiTesteSQLServer.Migrations
{
    [Migration(202307191229)]
    public class _202307191229_CriarTabelaDeFuncionario : Migration
    {
        public override void Up()
        {
            Create.Table("Funcionario")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Nome").AsString().NotNullable()
                .WithColumn("Cargo").AsString().NotNullable();
        }
        public override void Down()
        {
            Delete.Table("Funcionario");
        }
    }
}
