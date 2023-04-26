using System.ComponentModel.DataAnnotations;

namespace WebAPIinSQLServer.Entities.Models
{
    public class UsuarioUpdateModel
    {


        [Required(ErrorMessage = "Informe o nome completo ")]
        public string NomeCompleto { get; set; }
        public string id { get; set; }

    }
}