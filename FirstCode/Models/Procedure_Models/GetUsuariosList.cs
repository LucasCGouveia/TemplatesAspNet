using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Default_Template_MVC.Models.Procedure_Models
{
    public class GetUsuariosList : EntityBase
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Senha { get; set; }
        public string PerfilDescricao { get; set; }
    }
}