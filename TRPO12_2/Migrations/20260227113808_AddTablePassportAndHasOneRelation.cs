using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TRPO12_2.Migrations
{
    /// <inheritdoc />
    public partial class AddTablePassportAndHasOneRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Polzovats",
                table: "Polzovats");

            migrationBuilder.RenameTable(
                name: "Polzovats",
                newName: "Polzovat");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Polzovat",
                table: "Polzovat",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Passports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Series = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    PolzovatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passports_Polzovat_PolzovatId",
                        column: x => x.PolzovatId,
                        principalTable: "Polzovat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Passports_PolzovatId",
                table: "Passports",
                column: "PolzovatId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Polzovat",
                table: "Polzovat");

            migrationBuilder.RenameTable(
                name: "Polzovat",
                newName: "Polzovats");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Polzovats",
                table: "Polzovats",
                column: "Id");
        }
    }
}
