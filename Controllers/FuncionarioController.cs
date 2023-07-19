using ApiTesteSQLServer.Model;
using ApiTesteSQLServer.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ApiTesteSQLServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionarioController : ControllerBase
    {
        RepositorioSqlServer _repositorioSqlServer;

        public FuncionarioController(RepositorioSqlServer repositorioSqlServer)
        {
            _repositorioSqlServer = repositorioSqlServer;
        }

        [HttpGet]
        public List<Funcionario> ObterTodos()
        {
            return _repositorioSqlServer.ObterTodos();
        }

        [HttpPost]
        public NoContentResult CadastrarNovo(Funcionario funcionario)
        {
            if (funcionario is null) 
                throw new Exception("Não foi possível realizar cadastro");

            _repositorioSqlServer.Criar(funcionario);
            return NoContent();
        }

        [HttpDelete]
        public NoContentResult Remover(List<Funcionario> funcionarios)
        {
            if (!funcionarios.Any()) 
                throw new Exception("Não foi possóvel realizar remoção");

            _repositorioSqlServer.Remover(funcionarios);
            return NoContent();
        }
    }
}
