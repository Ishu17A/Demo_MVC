namespace Demo_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "Guid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Guid", c => c.Guid(nullable: false));
        }
    }
}
