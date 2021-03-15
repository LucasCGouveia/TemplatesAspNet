namespace Default_Template_MVC.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testetable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teste",
                c => new
                    {
                        IdTeste = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 100, unicode: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataExclusao = c.DateTime(),
                    })
                .PrimaryKey(t => t.IdTeste);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Teste");
        }
    }
}
