namespace trabFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProdutoModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProdutoModels", "FornecedorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProdutoModels", "FornecedorId", c => c.Int());
        }
    }
}
