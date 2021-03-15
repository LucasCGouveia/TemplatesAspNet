using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Default_Template_MVC.Context.Configuration;
using Default_Template_MVC.Models;

namespace Default_Template_MVC.Context
{
    public class Context : DbContext
    {
        public Context() : base("SISProjeto")
        {

            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;

            var objectContext = (this as IObjectContextAdapter).ObjectContext;
            objectContext.CommandTimeout = 500;
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Teste> Teste { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Remove as convenções do entity framework
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //Mapeia a chave primária dinamicamente
            modelBuilder.Properties()
                        .Where(x => x.Name == "Id" + x.ReflectedType.Name)
                        .Configure(x => x.IsKey());

            modelBuilder.Properties<string>().Configure(x => x.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(x => x.HasMaxLength(100));

            modelBuilder.Properties<string>()
                .Where(x => x.Name.ToLower() == "mensagem")
                .Configure(x => x.HasMaxLength(8000));



            //Adiciona as configurações das tabelas
            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new PerfilConfiguration());
            modelBuilder.Configurations.Add(new TesteConfiguration());


            Database.SetInitializer<Context>(new DBInitializer());
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(x => x.Entity.GetType().GetProperty("DataCriacao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCriacao").CurrentValue = DateTime.Now;
                }
            }
            return
                base.SaveChanges();
        }
    }
}