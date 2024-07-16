namespace mvcvalid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblregistrations",
                c => new
                    {
                        rid = c.Int(nullable: false, identity: true),
                        rname = c.String(nullable: false),
                        remail = c.String(nullable: false),
                        rpassword = c.String(nullable: false),
                        rimg = c.String(),
                    })
                .PrimaryKey(t => t.rid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblregistrations");
        }
    }
}
