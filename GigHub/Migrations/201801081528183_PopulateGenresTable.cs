namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenresTable : DbMigration
    {
        public override void Up()
        {
            //sql method to execute any script
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'JAZZ')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Blues')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Rock')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Country')");


        }

        // method called when we downgrade a database
        public override void Down()
        {

            Sql("DELETE FROM Genres WHERE Id IN (1,2,3,4)");

        }
    }
}
