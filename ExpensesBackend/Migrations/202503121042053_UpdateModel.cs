namespace ExpensesBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Entries", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Entries", "Date");
        }
    }
}
