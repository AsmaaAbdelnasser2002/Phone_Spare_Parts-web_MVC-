using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication6.Migrations
{
    /// <inheritdoc />
    public partial class Initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    B_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    B_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Country = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Photo = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Brands__4B26EFE62DB619A0", x => x.B_ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    U_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    F_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    L_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    E_mail = table.Column<string>(type: "varchar(100)", nullable: false),
                    Pass = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Addres = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    Pank_Code = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true),
                    Photo = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__5A2040DB6E9AAF88", x => x.U_ID);
                });

            migrationBuilder.CreateTable(
                name: "Catagories",
                columns: table => new
                {
                    C_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    C_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    B_ID = table.Column<int>(type: "int", nullable: true),
                    Photo = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Catagori__A9FDEC1242B3CA69", x => x.C_ID);
                    table.ForeignKey(
                        name: "FK__Catagories__B_ID__4BAC3F29",
                        column: x => x.B_ID,
                        principalTable: "Brands",
                        principalColumn: "B_ID");
                });

            migrationBuilder.CreateTable(
                name: "SPARE_PARTS",
                columns: table => new
                {
                    S_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    S_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    describtion = table.Column<string>(type: "text", nullable: true),
                    C_ID = table.Column<int>(type: "int", nullable: true),
                    Photo = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SPARE_PA__A3DFF16DAF32E7DA", x => x.S_ID);
                    table.ForeignKey(
                        name: "FK__SPARE_PART__C_ID__4E88ABD4",
                        column: x => x.C_ID,
                        principalTable: "Catagories",
                        principalColumn: "C_ID");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    O_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    S_ID = table.Column<int>(type: "int", nullable: true),
                    U_ID = table.Column<int>(type: "int", nullable: true),
                    O_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Orders__5AAB0C184C810E8A", x => x.O_ID);
                    table.ForeignKey(
                        name: "FK__Orders__S_ID__76969D2E",
                        column: x => x.S_ID,
                        principalTable: "SPARE_PARTS",
                        principalColumn: "S_ID");
                    table.ForeignKey(
                        name: "FK__Orders__U_ID__75A278F5",
                        column: x => x.U_ID,
                        principalTable: "Users",
                        principalColumn: "U_ID");
                });

          

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    P_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    P_Method = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    P_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Total_Price = table.Column<double>(type: "float", nullable: true),
                    O_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Payments__A3420A77BE9739B9", x => x.P_ID);
                    table.ForeignKey(
                        name: "FK__Payments__O_ID__797309D9",
                        column: x => x.O_ID,
                        principalTable: "Orders",
                        principalColumn: "O_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catagories_B_ID",
                table: "Catagories",
                column: "B_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_S_ID",
                table: "Orders",
                column: "S_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_U_ID",
                table: "Orders",
                column: "U_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_O_ID",
                table: "Payments",
                column: "O_ID");

         
            migrationBuilder.CreateIndex(
                name: "IX_SPARE_PARTS_C_ID",
                table: "SPARE_PARTS",
                column: "C_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "SPARE_PARTS");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Catagories");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
