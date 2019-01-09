namespace ExerciseCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompanyMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompanyViewModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        is_Active = c.Boolean(nullable: false),
                        company_name = c.String(),
                        create_date = c.DateTime(),
                        number_of_employees = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CompanyViewModels");
        }
    }
}
