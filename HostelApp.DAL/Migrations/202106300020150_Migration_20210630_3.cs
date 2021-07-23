namespace HostelApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_20210630_3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Guests", "Gender", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Guests", "Gender");
        }
    }
}
