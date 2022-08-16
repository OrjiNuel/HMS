namespace HMSII.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HMSUsers", "Fullname", c => c.String());
            AddColumn("dbo.HMSUsers", "Country", c => c.String());
            AddColumn("dbo.HMSUsers", "City", c => c.String());
            AddColumn("dbo.HMSUsers", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HMSUsers", "Address");
            DropColumn("dbo.HMSUsers", "City");
            DropColumn("dbo.HMSUsers", "Country");
            DropColumn("dbo.HMSUsers", "Fullname");
        }
    }
}
