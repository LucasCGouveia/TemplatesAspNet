using Default_Template_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Default_Template_MVC.Context.Configuration
{
    internal class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            base.HasKey(x => x.IdUsuario);
            base.Property(x => x.Nome).HasMaxLength(500);
            base.HasRequired(x => x.Perfil)
                .WithMany(x => x.Usuario)
                .HasForeignKey(x => x.IdPerfil);
        }
    }
}