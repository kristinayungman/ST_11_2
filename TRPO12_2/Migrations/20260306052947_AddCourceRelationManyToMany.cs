using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TRPO12_2.Migrations
{
    /// <inheritdoc />
    public partial class AddCourceRelationManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InterestGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InterestGroupPolzovat",
                columns: table => new
                {
                    InterestGroupsId = table.Column<int>(type: "int", nullable: false),
                    PolzovatsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestGroupPolzovat", x => new { x.InterestGroupsId, x.PolzovatsId });
                    table.ForeignKey(
                        name: "FK_InterestGroupPolzovat_InterestGroups_InterestGroupsId",
                        column: x => x.InterestGroupsId,
                        principalTable: "InterestGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterestGroupPolzovat_Polzovats_PolzovatsId",
                        column: x => x.PolzovatsId,
                        principalTable: "Polzovats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInterestGroups",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    InterestGroupId = table.Column<int>(type: "int", nullable: false),
                    JoinedAt = table.Column<DateOnly>(type: "date", nullable: false),
                    IsModerator = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInterestGroups", x => new { x.UserId, x.InterestGroupId });
                    table.ForeignKey(
                        name: "FK_UserInterestGroups_InterestGroups_InterestGroupId",
                        column: x => x.InterestGroupId,
                        principalTable: "InterestGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserInterestGroups_Polzovats_UserId",
                        column: x => x.UserId,
                        principalTable: "Polzovats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InterestGroupPolzovat_PolzovatsId",
                table: "InterestGroupPolzovat",
                column: "PolzovatsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInterestGroups_InterestGroupId",
                table: "UserInterestGroups",
                column: "InterestGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterestGroupPolzovat");

            migrationBuilder.DropTable(
                name: "UserInterestGroups");

            migrationBuilder.DropTable(
                name: "InterestGroups");
        }
    }
}
