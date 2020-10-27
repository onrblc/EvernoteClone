namespace EvernoteClone.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emailKarakterSayisiDegistirildi : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 15));
        }
    }
}
