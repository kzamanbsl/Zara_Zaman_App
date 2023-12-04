using Microsoft.EntityFrameworkCore.Migrations;

namespace app.Infrastructure.SeedData.SpSeedModels
{
    public class SP_GetExpenseItemList
    {
        public static void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
            
                CREATE OR ALTER PROCEDURE SP_GetExpenseItemList
                    (
	                   @FromAmount decimal=0,
                       @ToAmount decimal=0    
                    )
                AS
                IF 1=0 
                 BEGIN						
                 SET FMTONLY OFF
                 END	
                BEGIN
                SELECT * FROM ExpenseItem AS ei
                WHERE UnitPrice>=ISNULL(@FromAmount,ei.UnitPrice) AND UnitPrice<=ISNULL(@ToAmount,ei.UnitPrice);
                END
                ---EXEC SP_GetExpenseItemList null, null;

            ");
        }

        public static void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"DROP PROCEDURE SP_GetExpenseItemList;");

        }
    }
}
