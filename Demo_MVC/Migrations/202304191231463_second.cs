namespace Demo_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "PostedBy", c => c.Guid(nullable: false));
            AddColumn("dbo.Products", "Guid", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Guid");
            DropColumn("dbo.Products", "PostedBy");
        }
    }
}
