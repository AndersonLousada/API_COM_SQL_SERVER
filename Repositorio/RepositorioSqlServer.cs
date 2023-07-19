using ApiTesteSQLServer.Model;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.DataProvider.SqlServer;
using System.ComponentModel;

namespace ApiTesteSQLServer.Repositorio
{
    public class RepositorioSqlServer
    {
        public DataConnection Conexao()
        {
            string connectionString = ObterStringDeConexao();
            DataConnection conexao = SqlServerTools.CreateDataConnection(connectionString);
            return conexao;
        }

        public string ObterStringDeConexao()
        {
            var configuracao = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            return configuracao.GetConnectionString("DefaultConnection");
        }

        public void Criar(Funcionario funcionario)
        {
            var conexao = Conexao();
            conexao.Insert(funcionario);
        }

        public List<Funcionario> ObterTodos()
        {
            var conexao = Conexao();
            var funcionarios = conexao.GetTable<Funcionario>().ToList();
            return new List<Funcionario>(funcionarios);
        }

        public void Remover(List<Funcionario> funcionarios)
        {
            var conexao = Conexao();

            var todos = conexao.GetTable<Funcionario>();

            foreach (var funcionario in funcionarios)
            {
                todos.Delete(func => func.Id == funcionario.Id);
            }
        }
    }
}
