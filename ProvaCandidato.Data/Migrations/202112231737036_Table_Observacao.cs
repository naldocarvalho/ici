namespace ProvaCandidato.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Table_Observacao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClienteObservacao",
                c => new
                    {
                        codigo = c.Int(nullable: false, identity: true),
                        observacao = c.String(maxLength: 100),
                        ClienteId_Codigo = c.Int(),
                    })
                .PrimaryKey(t => t.codigo)
                .ForeignKey("dbo.Cliente", t => t.ClienteId_Codigo)
                .Index(t => t.ClienteId_Codigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClienteObservacao", "ClienteId_Codigo", "dbo.Cliente");
            DropIndex("dbo.ClienteObservacao", new[] { "ClienteId_Codigo" });
            DropTable("dbo.ClienteObservacao");
        }
    }
}
