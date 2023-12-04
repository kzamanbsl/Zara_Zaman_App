using Microsoft.EntityFrameworkCore.Migrations;

namespace app.Infrastructure.SeedData.AppSeedModels
{
    public class GenderSeedData
    {
        public static void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
           
            ");
        }

        public static void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"DELETE FROM Table WHERE ...");
           
        }
    }
}

