namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tarefas",
                c => new
                    {
                        idTarefa = c.Int(nullable: false, identity: true),
                        nmTarefa = c.String(),
                        dtTarefa = c.DateTime(nullable: false),
                        icConcluido = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idTarefa);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tarefas");
        }
    }
}
