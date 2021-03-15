namespace Default_Template_MVC.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstbase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Perfil",
                c => new
                    {
                        IdPerfil = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 100, unicode: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataExclusao = c.DateTime(),
                    })
                .PrimaryKey(t => t.IdPerfil);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        IdUsuario = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 500, unicode: false),
                        Email = c.String(maxLength: 100, unicode: false),
                        DataNascimento = c.DateTime(nullable: false),
                        Senha = c.String(maxLength: 100, unicode: false),
                        IdPerfil = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataExclusao = c.DateTime(),
                    })
                .PrimaryKey(t => t.IdUsuario)
                .ForeignKey("dbo.Perfil", t => t.IdPerfil)
                .Index(t => t.IdPerfil);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuario", "IdPerfil", "dbo.Perfil");
            DropIndex("dbo.Usuario", new[] { "IdPerfil" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Perfil");
        }
    }
}
