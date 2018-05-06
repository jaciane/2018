namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ACCESS",
                c => new
                    {
                        ID_PROFILE = c.Int(nullable: false),
                        ID_PERMISSION = c.Int(nullable: false),
                        ID_USER = c.Int(),
                    })
                .PrimaryKey(t => new { t.ID_PROFILE, t.ID_PERMISSION })
                .ForeignKey("dbo.PERMISSION", t => t.ID_PERMISSION)
                .ForeignKey("dbo.PROFILE", t => t.ID_PROFILE)
                .Index(t => t.ID_PROFILE)
                .Index(t => t.ID_PERMISSION);
            
            CreateTable(
                "dbo.PERMISSION",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ID_USER = c.Int(),
                        CLAIMTYPE = c.String(maxLength: 100, storeType: "nvarchar"),
                        CLAIMVALUE = c.String(maxLength: 100, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PROFILE",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NAME = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        ACTIVE = c.String(nullable: false, maxLength: 1, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.USER",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ID_PROFILE = c.Int(nullable: false),
                        CPF = c.String(nullable: false, maxLength: 11, storeType: "nvarchar"),
                        NAME = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        EMAIL = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        ACTIVE = c.String(nullable: false, maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        USERNAME = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        EMAILCONFIRMED = c.Boolean(nullable: false),
                        PASSWORDHASH = c.String(nullable: false, unicode: false),
                        SECURITYSTAMP = c.String(unicode: false),
                        PHONENUMBER = c.String(maxLength: 50, storeType: "nvarchar"),
                        PHONENUMBERCONFIRMED = c.Boolean(nullable: false),
                        TWOFACTORENABLED = c.Boolean(nullable: false),
                        LOCKOUTENDDATEUTC = c.DateTime(precision: 6, storeType: "timestamp"),
                        LOCKOUTENABLED = c.Boolean(nullable: false),
                        RECIEVENOTIFICATION = c.Boolean(nullable: false),
                        ACCESSFAILEDCOUNT = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PROFILE", t => t.ID_PROFILE)
                .Index(t => t.ID_PROFILE);
            
            CreateTable(
                "dbo.USERLOGIN",
                c => new
                    {
                        ID_USER = c.Int(nullable: false),
                        LOGINPROVIDER = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        PROVIDERKEY = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.ID_USER, t.LOGINPROVIDER, t.PROVIDERKEY })
                .ForeignKey("dbo.USER", t => t.ID_USER)
                .Index(t => t.ID_USER);
            
            CreateTable(
                "dbo.PARAMETER",
                c => new
                    {
                        NAME = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        VALUE = c.String(nullable: false, unicode: false),
                        TYPE = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.NAME);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ACCESS", "ID_PROFILE", "dbo.PROFILE");
            DropForeignKey("dbo.USERLOGIN", "ID_USER", "dbo.USER");
            DropForeignKey("dbo.USER", "ID_PROFILE", "dbo.PROFILE");
            DropForeignKey("dbo.ACCESS", "ID_PERMISSION", "dbo.PERMISSION");
            DropIndex("dbo.USERLOGIN", new[] { "ID_USER" });
            DropIndex("dbo.USER", new[] { "ID_PROFILE" });
            DropIndex("dbo.ACCESS", new[] { "ID_PERMISSION" });
            DropIndex("dbo.ACCESS", new[] { "ID_PROFILE" });
            DropTable("dbo.PARAMETER");
            DropTable("dbo.USERLOGIN");
            DropTable("dbo.USER");
            DropTable("dbo.PROFILE");
            DropTable("dbo.PERMISSION");
            DropTable("dbo.ACCESS");
        }
    }
}
