using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Default_Template_MVC.Models
{
    public class Perfil : EntityBase
    {
        public int IdPerfil { get; set; }
        public string Descricao { get; set; }
        public virtual List<Usuario> Usuario { get; set; }
    }
}