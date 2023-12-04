using app.Infrastructure.SeedData.SpSeedModels;
using Microsoft.EntityFrameworkCore.Migrations;

namespace app.Infrastructure.SeedData;

public class BaseSpSeedData
{
    public static void Up(MigrationBuilder migrationBuilder)
    {
        #region Expense
        SP_GetExpenseItemList.Up(migrationBuilder);
        #endregion

    }

    public static void Down(MigrationBuilder migrationBuilder)
    {

        #region Expense
        SP_GetExpenseItemList.Down(migrationBuilder);
        #endregion

    }
}