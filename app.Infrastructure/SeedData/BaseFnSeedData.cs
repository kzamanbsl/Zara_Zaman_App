using app.Infrastructure.SeedData.FnSeedModels;
using Microsoft.EntityFrameworkCore.Migrations;

namespace app.Infrastructure.SeedData
{
    public class BaseFnSeedData
    {
        public static void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"{FnScripts.Fn_GetTest()}");
            migrationBuilder.Sql($@"{FnScripts.Fn_GetTest1()}");
        }

        public static void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"{GetFnDropScript(FnNameEnum.Fn_GetTest.ToString())}");
            migrationBuilder.Sql($@"{GetFnDropScript(FnNameEnum.Fn_GetTest1.ToString())}");
        }

        private static string GetFnDropScript(string fnName)
        {
            var query = $@"DROP FUNCTION IF EXISTS {fnName};";
            return query;
        }
    }
}
