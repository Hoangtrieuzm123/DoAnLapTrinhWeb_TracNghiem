using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nhom6_DoAnMonHoc.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeThis",
                columns: table => new
                {
                    Madt = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tendt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Thoigianthi = table.Column<int>(type: "int", nullable: false),
                    Soluongcauhoi = table.Column<int>(type: "int", maxLength: 200, nullable: false),
                    Mota = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeThis", x => x.Madt);
                });

            migrationBuilder.CreateTable(
                name: "CauHois",
                columns: table => new
                {
                    Mach = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Madt = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    Cauhoi = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DapanA = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DapanB = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DapanC = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DapanD = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Dapan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeThiMadt = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CauHois", x => x.Mach);
                    table.ForeignKey(
                        name: "FK_CauHois_DeThis_DeThiMadt",
                        column: x => x.DeThiMadt,
                        principalTable: "DeThis",
                        principalColumn: "Madt");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CauHois_DeThiMadt",
                table: "CauHois",
                column: "DeThiMadt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CauHois");

            migrationBuilder.DropTable(
                name: "DeThis");
        }
    }
}
