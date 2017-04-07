namespace SixNations2017.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Position = c.Int(nullable: false),
                        InternationalTeam = c.Int(nullable: false),
                        TriesScored = c.Int(nullable: false),
                        ConversionScored = c.Int(nullable: false),
                        Penalties = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Players");
        }
    }
}
