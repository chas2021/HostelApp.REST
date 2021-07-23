namespace HostelApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_20210630_4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Guests", "Gender");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Guests", "Gender", c => c.String());
        }
    }
}
