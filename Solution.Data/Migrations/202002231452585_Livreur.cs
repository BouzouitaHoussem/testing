namespace Solution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Livreur : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Livreurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Salary = c.Double(nullable: false),
                        Address = c.String(),
                        Age = c.Int(nullable: false),
                        

                })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Livreurs");
        }
    }
}
