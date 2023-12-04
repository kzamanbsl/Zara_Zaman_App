using app.Infrastructure.SeedData.AppSeedModels;
using Microsoft.EntityFrameworkCore.Migrations;

namespace app.Infrastructure.SeedData
{
    public class BaseAppSeedData
    {
        public static void Up(MigrationBuilder migrationBuilder)
        {
            
            #region Enum Seed Data
            GenderSeedData.Up(migrationBuilder);
            #endregion

        }

        public static void Down(MigrationBuilder migrationBuilder)
        {
            #region Seed Data
            GenderSeedData.Down(migrationBuilder);
            #endregion

        }
    }
}
