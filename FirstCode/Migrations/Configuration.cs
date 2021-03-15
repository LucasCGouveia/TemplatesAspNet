
namespace Default_Template_MVC.Context.Migrations
{
    using Default_Template_MVC.Models;
    using Default_Template_MVC.Repository.Utils.Cryptography;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context context)
        {
            Perfil perfil = new Perfil()
            {
                Descricao = "Administrador",
                DataCriacao = DateTime.Now
            };
            context.Perfil.Add(perfil);

            Usuario user = new Usuario()
            {
                Nome = "Administrador",
                Senha = "Sis@1234".Encrypt(),
                Email = "administrador@sisconsultoria.com.br",
                DataNascimento = DateTime.Now,
                IdPerfil = 1,
                DataCriacao = DateTime.Now
            };
            context.Usuario.Add(user);

            base.Seed(context);
        }
    }
}