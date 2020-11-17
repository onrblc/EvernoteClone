namespace EvernoteClone.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DenemeAnnotationDegistirdim2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false, maxLength: 15));
        }
    }
}
