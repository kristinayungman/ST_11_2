using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TRPO12_2.Migrations
{
    /// <inheritdoc />
    public partial class AddTableUserProfileAndHasOneRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passports_Polzovat_PolzovatId",
                table: "Passports");

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

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PolzovatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_Polzovats_PolzovatId",
                        column: x => x.PolzovatId,
                        principalTable: "Polzovats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_PolzovatId",
                table: "UserProfiles",
                column: "PolzovatId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Passports_Polzovats_PolzovatId",
                table: "Passports",
                column: "PolzovatId",
                principalTable: "Polzovats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passports_Polzovats_PolzovatId",
                table: "Passports");

            migrationBuilder.DropTable(
                name: "UserProfiles");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Passports_Polzovat_PolzovatId",
                table: "Passports",
                column: "PolzovatId",
                principalTable: "Polzovat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
