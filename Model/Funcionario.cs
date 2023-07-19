using LinqToDB.Mapping;
using System.Xml.Linq;

namespace ApiTesteSQLServer.Model
{
    [Table(Name = "Funcionario")]
    public class Funcionario
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }

        [Column(Name = "Nome")]
        public string Nome { get; set; }

        [Column(Name = "Cargo")]
        public string Cargo { get; set; }
    }
}
