namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tarefas", "image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tarefas", "image");
        }
    }
}
