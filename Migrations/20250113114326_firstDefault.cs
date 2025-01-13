using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarieSkema.Migrations
{
    /// <inheritdoc />
    public partial class firstDefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fag",
                columns: table => new
                {
                    FagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FagNavn = table.Column<int>(type: "int", nullable: false),
                    FagTid = table.Column<float>(type: "real", nullable: false),
                    TPTid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fag", x => x.FagId);
                });

            migrationBuilder.CreateTable(
                name: "FagDages",
                columns: table => new
                {
                    FagDageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dag = table.Column<int>(type: "int", nullable: false),
                    dateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FagDages", x => x.FagDageId);
                });

            migrationBuilder.CreateTable(
                name: "Laerer",
                columns: table => new
                {
                    LaererId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LaererNavn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laerer", x => x.LaererId);
                });

            migrationBuilder.CreateTable(
                name: "FagFagDage",
                columns: table => new
                {
                    FagId = table.Column<int>(type: "int", nullable: false),
                    fagDagesesFagDageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FagFagDage", x => new { x.FagId, x.fagDagesesFagDageId });
                    table.ForeignKey(
                        name: "FK_FagFagDage_FagDages_fagDagesesFagDageId",
                        column: x => x.fagDagesesFagDageId,
                        principalTable: "FagDages",
                        principalColumn: "FagDageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FagFagDage_Fag_FagId",
                        column: x => x.FagId,
                        principalTable: "Fag",
                        principalColumn: "FagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FagLaerer",
                columns: table => new
                {
                    fagsFagId = table.Column<int>(type: "int", nullable: false),
                    laerersesLaererId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FagLaerer", x => new { x.fagsFagId, x.laerersesLaererId });
                    table.ForeignKey(
                        name: "FK_FagLaerer_Fag_fagsFagId",
                        column: x => x.fagsFagId,
                        principalTable: "Fag",
                        principalColumn: "FagId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FagLaerer_Laerer_laerersesLaererId",
                        column: x => x.laerersesLaererId,
                        principalTable: "Laerer",
                        principalColumn: "LaererId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LaererFagDage",
                columns: table => new
                {
                    fagsDageFagDageId = table.Column<int>(type: "int", nullable: false),
                    laerersLaererId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaererFagDage", x => new { x.fagsDageFagDageId, x.laerersLaererId });
                    table.ForeignKey(
                        name: "FK_LaererFagDage_FagDages_fagsDageFagDageId",
                        column: x => x.fagsDageFagDageId,
                        principalTable: "FagDages",
                        principalColumn: "FagDageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LaererFagDage_Laerer_laerersLaererId",
                        column: x => x.laerersLaererId,
                        principalTable: "Laerer",
                        principalColumn: "LaererId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FagFagDage_fagDagesesFagDageId",
                table: "FagFagDage",
                column: "fagDagesesFagDageId");

            migrationBuilder.CreateIndex(
                name: "IX_FagLaerer_laerersesLaererId",
                table: "FagLaerer",
                column: "laerersesLaererId");

            migrationBuilder.CreateIndex(
                name: "IX_LaererFagDage_laerersLaererId",
                table: "LaererFagDage",
                column: "laerersLaererId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FagFagDage");

            migrationBuilder.DropTable(
                name: "FagLaerer");

            migrationBuilder.DropTable(
                name: "LaererFagDage");

            migrationBuilder.DropTable(
                name: "Fag");

            migrationBuilder.DropTable(
                name: "FagDages");

            migrationBuilder.DropTable(
                name: "Laerer");
        }
    }
}
