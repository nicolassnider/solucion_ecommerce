using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.Persistence.Database.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Catalog");

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Catalog",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                schema: "Catalog",
                columns: table => new
                {
                    ProductInStockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.ProductInStockId);
                    table.ForeignKey(
                        name: "FK_Stocks_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Catalog",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Description for product 1", "Product 1", 331m },
                    { 73, "Description for product 73", "Product 73", 156m },
                    { 72, "Description for product 72", "Product 72", 417m },
                    { 71, "Description for product 71", "Product 71", 126m },
                    { 70, "Description for product 70", "Product 70", 817m },
                    { 69, "Description for product 69", "Product 69", 267m },
                    { 68, "Description for product 68", "Product 68", 835m },
                    { 67, "Description for product 67", "Product 67", 503m },
                    { 66, "Description for product 66", "Product 66", 690m },
                    { 65, "Description for product 65", "Product 65", 941m },
                    { 64, "Description for product 64", "Product 64", 443m },
                    { 63, "Description for product 63", "Product 63", 409m },
                    { 62, "Description for product 62", "Product 62", 475m },
                    { 61, "Description for product 61", "Product 61", 392m },
                    { 60, "Description for product 60", "Product 60", 550m },
                    { 59, "Description for product 59", "Product 59", 868m },
                    { 58, "Description for product 58", "Product 58", 588m },
                    { 57, "Description for product 57", "Product 57", 230m },
                    { 56, "Description for product 56", "Product 56", 246m },
                    { 55, "Description for product 55", "Product 55", 797m },
                    { 54, "Description for product 54", "Product 54", 305m },
                    { 53, "Description for product 53", "Product 53", 726m },
                    { 74, "Description for product 74", "Product 74", 694m },
                    { 52, "Description for product 52", "Product 52", 113m },
                    { 75, "Description for product 75", "Product 75", 310m },
                    { 77, "Description for product 77", "Product 77", 167m },
                    { 98, "Description for product 98", "Product 98", 675m },
                    { 97, "Description for product 97", "Product 97", 686m },
                    { 96, "Description for product 96", "Product 96", 181m },
                    { 95, "Description for product 95", "Product 95", 586m },
                    { 94, "Description for product 94", "Product 94", 858m },
                    { 93, "Description for product 93", "Product 93", 509m },
                    { 92, "Description for product 92", "Product 92", 640m },
                    { 91, "Description for product 91", "Product 91", 720m },
                    { 90, "Description for product 90", "Product 90", 584m },
                    { 89, "Description for product 89", "Product 89", 613m },
                    { 88, "Description for product 88", "Product 88", 621m },
                    { 87, "Description for product 87", "Product 87", 794m },
                    { 86, "Description for product 86", "Product 86", 645m },
                    { 85, "Description for product 85", "Product 85", 371m },
                    { 84, "Description for product 84", "Product 84", 203m },
                    { 83, "Description for product 83", "Product 83", 173m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 82, "Description for product 82", "Product 82", 570m },
                    { 81, "Description for product 81", "Product 81", 845m },
                    { 80, "Description for product 80", "Product 80", 233m },
                    { 79, "Description for product 79", "Product 79", 560m },
                    { 78, "Description for product 78", "Product 78", 965m },
                    { 76, "Description for product 76", "Product 76", 366m },
                    { 51, "Description for product 51", "Product 51", 569m },
                    { 50, "Description for product 50", "Product 50", 235m },
                    { 49, "Description for product 49", "Product 49", 643m },
                    { 22, "Description for product 22", "Product 22", 185m },
                    { 21, "Description for product 21", "Product 21", 362m },
                    { 20, "Description for product 20", "Product 20", 766m },
                    { 19, "Description for product 19", "Product 19", 573m },
                    { 18, "Description for product 18", "Product 18", 465m },
                    { 17, "Description for product 17", "Product 17", 696m },
                    { 16, "Description for product 16", "Product 16", 256m },
                    { 15, "Description for product 15", "Product 15", 669m },
                    { 14, "Description for product 14", "Product 14", 898m },
                    { 13, "Description for product 13", "Product 13", 245m },
                    { 12, "Description for product 12", "Product 12", 330m },
                    { 11, "Description for product 11", "Product 11", 211m },
                    { 10, "Description for product 10", "Product 10", 600m },
                    { 9, "Description for product 9", "Product 9", 285m },
                    { 8, "Description for product 8", "Product 8", 649m },
                    { 7, "Description for product 7", "Product 7", 191m },
                    { 6, "Description for product 6", "Product 6", 162m },
                    { 5, "Description for product 5", "Product 5", 705m },
                    { 4, "Description for product 4", "Product 4", 445m },
                    { 3, "Description for product 3", "Product 3", 851m },
                    { 2, "Description for product 2", "Product 2", 718m },
                    { 23, "Description for product 23", "Product 23", 587m },
                    { 24, "Description for product 24", "Product 24", 363m },
                    { 25, "Description for product 25", "Product 25", 576m },
                    { 26, "Description for product 26", "Product 26", 254m },
                    { 48, "Description for product 48", "Product 48", 298m },
                    { 47, "Description for product 47", "Product 47", 409m },
                    { 46, "Description for product 46", "Product 46", 443m },
                    { 45, "Description for product 45", "Product 45", 802m },
                    { 44, "Description for product 44", "Product 44", 622m },
                    { 43, "Description for product 43", "Product 43", 118m },
                    { 42, "Description for product 42", "Product 42", 996m },
                    { 41, "Description for product 41", "Product 41", 556m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 40, "Description for product 40", "Product 40", 878m },
                    { 39, "Description for product 39", "Product 39", 408m },
                    { 99, "Description for product 99", "Product 99", 681m },
                    { 38, "Description for product 38", "Product 38", 378m },
                    { 36, "Description for product 36", "Product 36", 851m },
                    { 35, "Description for product 35", "Product 35", 730m },
                    { 34, "Description for product 34", "Product 34", 410m },
                    { 33, "Description for product 33", "Product 33", 826m },
                    { 32, "Description for product 32", "Product 32", 520m },
                    { 31, "Description for product 31", "Product 31", 658m },
                    { 30, "Description for product 30", "Product 30", 841m },
                    { 29, "Description for product 29", "Product 29", 339m },
                    { 28, "Description for product 28", "Product 28", 716m },
                    { 27, "Description for product 27", "Product 27", 769m },
                    { 37, "Description for product 37", "Product 37", 229m },
                    { 100, "Description for product 100", "Product 100", 212m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Stocks",
                columns: new[] { "ProductInStockId", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 1, 1, 12 },
                    { 73, 73, 3 },
                    { 72, 72, 6 },
                    { 71, 71, 15 },
                    { 70, 70, 15 },
                    { 69, 69, 7 },
                    { 68, 68, 10 },
                    { 67, 67, 4 },
                    { 66, 66, 15 },
                    { 65, 65, 7 },
                    { 64, 64, 13 },
                    { 63, 63, 17 },
                    { 62, 62, 0 },
                    { 61, 61, 9 },
                    { 60, 60, 0 },
                    { 59, 59, 0 },
                    { 58, 58, 13 },
                    { 57, 57, 16 },
                    { 56, 56, 14 },
                    { 55, 55, 3 },
                    { 54, 54, 13 },
                    { 53, 53, 5 },
                    { 74, 74, 14 },
                    { 52, 52, 18 },
                    { 75, 75, 15 },
                    { 77, 77, 18 },
                    { 98, 98, 7 },
                    { 97, 97, 12 },
                    { 96, 96, 5 },
                    { 95, 95, 12 },
                    { 94, 94, 7 },
                    { 93, 93, 19 },
                    { 92, 92, 9 },
                    { 91, 91, 8 },
                    { 90, 90, 9 },
                    { 89, 89, 3 },
                    { 88, 88, 1 },
                    { 87, 87, 15 },
                    { 86, 86, 0 },
                    { 85, 85, 5 },
                    { 84, 84, 2 },
                    { 83, 83, 16 }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Stocks",
                columns: new[] { "ProductInStockId", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 82, 82, 6 },
                    { 81, 81, 14 },
                    { 80, 80, 10 },
                    { 79, 79, 18 },
                    { 78, 78, 0 },
                    { 76, 76, 2 },
                    { 51, 51, 1 },
                    { 50, 50, 9 },
                    { 49, 49, 16 },
                    { 22, 22, 18 },
                    { 21, 21, 12 },
                    { 20, 20, 1 },
                    { 19, 19, 17 },
                    { 18, 18, 12 },
                    { 17, 17, 6 },
                    { 16, 16, 18 },
                    { 15, 15, 19 },
                    { 14, 14, 10 },
                    { 13, 13, 17 },
                    { 12, 12, 0 },
                    { 11, 11, 16 },
                    { 10, 10, 6 },
                    { 9, 9, 0 },
                    { 8, 8, 8 },
                    { 7, 7, 12 },
                    { 6, 6, 12 },
                    { 5, 5, 19 },
                    { 4, 4, 13 },
                    { 3, 3, 15 },
                    { 2, 2, 7 },
                    { 23, 23, 10 },
                    { 24, 24, 2 },
                    { 25, 25, 12 },
                    { 26, 26, 19 },
                    { 48, 48, 17 },
                    { 47, 47, 4 },
                    { 46, 46, 1 },
                    { 45, 45, 3 },
                    { 44, 44, 9 },
                    { 43, 43, 0 },
                    { 42, 42, 9 },
                    { 41, 41, 5 }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Stocks",
                columns: new[] { "ProductInStockId", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 40, 40, 2 },
                    { 39, 39, 8 },
                    { 99, 99, 2 },
                    { 38, 38, 0 },
                    { 36, 36, 4 },
                    { 35, 35, 3 },
                    { 34, 34, 6 },
                    { 33, 33, 15 },
                    { 32, 32, 0 },
                    { 31, 31, 18 },
                    { 30, 30, 6 },
                    { 29, 29, 11 },
                    { 28, 28, 12 },
                    { 27, 27, 3 },
                    { 37, 37, 2 },
                    { 100, 100, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId",
                schema: "Catalog",
                table: "Stocks",
                column: "ProductId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Catalog");
        }
    }
}
