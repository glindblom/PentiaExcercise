using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PentiaEcercise.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    Color = table.Column<string>(nullable: true),
                    Extras = table.Column<string>(nullable: true),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    RecommendedPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    Address = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "SalesPersons",
                columns: table => new
                {
                    SalesPersonId = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    Address = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Salary = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPersons", x => x.SalesPersonId);
                });

            migrationBuilder.CreateTable(
                name: "CarPurchases",
                columns: table => new
                {
                    CarPurchaseId = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    CarId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    PricePaid = table.Column<decimal>(nullable: false),
                    SalesPersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarPurchases", x => x.CarPurchaseId);
                    table.ForeignKey(
                        name: "FK_CarPurchases_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarPurchases_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarPurchases_SalesPersons_SalesPersonId",
                        column: x => x.SalesPersonId,
                        principalTable: "SalesPersons",
                        principalColumn: "SalesPersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarPurchases_CarId",
                table: "CarPurchases",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarPurchases_CustomerId",
                table: "CarPurchases",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CarPurchases_SalesPersonId",
                table: "CarPurchases",
                column: "SalesPersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarPurchases");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "SalesPersons");
        }
    }
}
