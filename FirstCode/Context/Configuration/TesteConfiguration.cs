using Default_Template_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Default_Template_MVC.Context.Configuration
{
    internal class TesteConfiguration : EntityTypeConfiguration<Teste>
    {
        public TesteConfiguration()
        {
            base.HasKey(x => x.IdTeste);
        }
    }
}