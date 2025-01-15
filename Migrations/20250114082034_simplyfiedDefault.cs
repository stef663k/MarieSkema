using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarieSkema.Migrations
{
    /// <inheritdoc />
    public partial class simplyfiedDefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FagFagDage");

            migrationBuilder.DropTable(
                name: "FagLaerer");

            migrationBuilder.DropTable(
                name: "LaererFagDage");

            migrationBuilder.AddColumn<float>(
                name: "FagFagligeTimer",
                table: "FagDages",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "FagId",
                table: "FagDages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LaererId",
                table: "FagDages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "TPTimer",
                table: "FagDages",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateIndex(
                name: "IX_FagDages_FagId",
                table: "FagDages",
                column: "FagId");

            migrationBuilder.CreateIndex(
                name: "IX_FagDages_LaererId",
                table: "FagDages",
                column: "LaererId");

            migrationBuilder.AddForeignKey(
                name: "FK_FagDages_Fag_FagId",
                table: "FagDages",
                column: "FagId",
                principalTable: "Fag",
                principalColumn: "FagId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FagDages_Laerer_LaererId",
                table: "FagDages",
                column: "LaererId",
                principalTable: "Laerer",
                principalColumn: "LaererId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FagDages_Fag_FagId",
                table: "FagDages");

            migrationBuilder.DropForeignKey(
                name: "FK_FagDages_Laerer_LaererId",
                table: "FagDages");

            migrationBuilder.DropIndex(
                name: "IX_FagDages_FagId",
                table: "FagDages");

            migrationBuilder.DropIndex(
                name: "IX_FagDages_LaererId",
                table: "FagDages");

            migrationBuilder.DropColumn(
                name: "FagFagligeTimer",
                table: "FagDages");

            migrationBuilder.DropColumn(
                name: "FagId",
                table: "FagDages");

            migrationBuilder.DropColumn(
                name: "LaererId",
                table: "FagDages");

            migrationBuilder.DropColumn(
                name: "TPTimer",
                table: "FagDages");

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
    }
}
