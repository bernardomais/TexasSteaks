using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TexasSteaks.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSteakChangeInStockColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Steaks SET InStock = 1 WHERE Id = 1");
            migrationBuilder.Sql("UPDATE Steaks SET InStock = 1 WHERE Id = 2");
            migrationBuilder.Sql("UPDATE Steaks SET InStock = 1 WHERE Id = 3");
            migrationBuilder.Sql("UPDATE Steaks SET InStock = 1 WHERE Id = 4");
            migrationBuilder.Sql("UPDATE Steaks SET InStock = 0 WHERE Id = 5");
            migrationBuilder.Sql("UPDATE Steaks SET InStock = 1 WHERE Id = 6");
            migrationBuilder.Sql("UPDATE Steaks SET InStock = 1 WHERE Id = 7");
            migrationBuilder.Sql("UPDATE Steaks SET InStock = 0 WHERE Id = 8");
            migrationBuilder.Sql("UPDATE Steaks SET InStock = 1 WHERE Id = 9");
            migrationBuilder.Sql("UPDATE Steaks SET InStock = 1 WHERE Id = 10");
            migrationBuilder.Sql("UPDATE Steaks SET InStock = 1 WHERE Id = 11");
            migrationBuilder.Sql("UPDATE Steaks SET InStock = 1 WHERE Id = 12");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Steaks SET InStock = 0");
        }
    }
}
