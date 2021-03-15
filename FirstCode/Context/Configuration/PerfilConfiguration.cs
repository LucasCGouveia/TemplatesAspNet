using Default_Template_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Default_Template_MVC.Context.Configuration
{
    internal class PerfilConfiguration : EntityTypeConfiguration<Perfil>
    {
        public PerfilConfiguration()
        {
            base.HasKey(x => x.IdPerfil);
        }
    }
}