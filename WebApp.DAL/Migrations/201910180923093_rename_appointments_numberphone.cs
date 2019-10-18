namespace WebApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rename_appointments_numberphone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "PhoneNumber", c => c.String());
            DropColumn("dbo.Appointments", "NumberPhone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "NumberPhone", c => c.String());
            DropColumn("dbo.Appointments", "PhoneNumber");
        }
    }
}
