using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Default_Template_MVC.Models
{
    public class Usuario : EntityBase
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Senha { get; set; }
        public int IdPerfil { get; set; }
        public virtual Perfil Perfil { get; set; }
    }
}