namespace WebMVCPrueba.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Municipios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoMunicipio = c.String(maxLength: 8),
                        NombreMunicipio = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MunicipioTramites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MunicipioId = c.Int(nullable: false),
                        TramiteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Municipios", t => t.MunicipioId, cascadeDelete: true)
                .ForeignKey("dbo.Tramites", t => t.TramiteId, cascadeDelete: true)
                .Index(t => t.MunicipioId)
                .Index(t => t.TramiteId);
            
            CreateTable(
                "dbo.Tramites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoTramite = c.String(maxLength: 20),
                        NombreTramite = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MunicipioTramites", "TramiteId", "dbo.Tramites");
            DropForeignKey("dbo.MunicipioTramites", "MunicipioId", "dbo.Municipios");
            DropIndex("dbo.MunicipioTramites", new[] { "TramiteId" });
            DropIndex("dbo.MunicipioTramites", new[] { "MunicipioId" });
            DropTable("dbo.Tramites");
            DropTable("dbo.MunicipioTramites");
            DropTable("dbo.Municipios");
        }
    }
}
