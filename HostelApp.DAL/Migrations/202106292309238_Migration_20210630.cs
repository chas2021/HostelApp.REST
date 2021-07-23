namespace HostelApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_20210630 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Guests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        DtBirth = c.DateTime(),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReservationCode = c.String(nullable: false, maxLength: 10),
                        DtInsert = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DtCheckIn = c.DateTime(nullable: false),
                        DtDeparture = c.DateTime(nullable: false),
                        Сurrency = c.String(nullable: false),
                        Commission = c.Decimal(precision: 18, scale: 2),
                        Source = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReservationGuests",
                c => new
                    {
                        Reservation_Id = c.Int(nullable: false),
                        Guest_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Reservation_Id, t.Guest_Id })
                .ForeignKey("dbo.Reservations", t => t.Reservation_Id, cascadeDelete: true)
                .ForeignKey("dbo.Guests", t => t.Guest_Id, cascadeDelete: true)
                .Index(t => t.Reservation_Id)
                .Index(t => t.Guest_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReservationGuests", "Guest_Id", "dbo.Guests");
            DropForeignKey("dbo.ReservationGuests", "Reservation_Id", "dbo.Reservations");
            DropIndex("dbo.ReservationGuests", new[] { "Guest_Id" });
            DropIndex("dbo.ReservationGuests", new[] { "Reservation_Id" });
            DropTable("dbo.ReservationGuests");
            DropTable("dbo.Reservations");
            DropTable("dbo.Guests");
        }
    }
}
