namespace trabFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FornecedorModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FornecedorModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Empresa = c.String(nullable: false),
                        Cartegoria = c.String(nullable: false),
                        Endereco = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProdutoModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Produto = c.String(nullable: false),
                        Descricao = c.String(),
                        fornEmpre_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FornecedorModels", t => t.fornEmpre_Id)
                .Index(t => t.fornEmpre_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProdutoModels", "fornEmpre_Id", "dbo.FornecedorModels");
            DropIndex("dbo.ProdutoModels", new[] { "fornEmpre_Id" });
            DropTable("dbo.ProdutoModels");
            DropTable("dbo.FornecedorModels");
        }
    }
}
