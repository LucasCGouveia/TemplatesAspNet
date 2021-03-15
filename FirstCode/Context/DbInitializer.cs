using Default_Template_MVC.Models;
using Default_Template_MVC.Repository.Utils.Cryptography;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Default_Template_MVC.Context
{
    public class DBInitializer : CreateDatabaseIfNotExists<Context>
    {
        protected override void Seed(Context context)
        {
            Context objContext = new Context();
            Perfil perfil = new Perfil()
            {
                Descricao = "Administrador",
                DataCriacao = DateTime.Now
            };
            objContext.Perfil.Add(perfil);

            Usuario user = new Usuario()
            {
                Nome = "Administrador",
                Senha = "Sis@1234".Encrypt(),
                Email = "administrador@sisconsultoria.com.br",
                DataNascimento = DateTime.Now,
                IdPerfil = 1,
                DataCriacao = DateTime.Now
            };
            objContext.Usuario.Add(user);

            base.Seed(context);
        }
    }
}