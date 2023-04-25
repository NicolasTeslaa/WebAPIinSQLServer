using System.ComponentModel.DataAnnotations;

namespace WebAPIinSQLServer.Entities.Models
{
    public class UsuarioCreateModel
    {


        [Required(ErrorMessage = "Informe o nome completo ")]
        public string NomeCompleto { get; set; }

    }
}