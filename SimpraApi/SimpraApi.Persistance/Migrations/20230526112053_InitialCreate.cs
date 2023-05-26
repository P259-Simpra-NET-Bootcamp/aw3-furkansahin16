using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpraApi.Persistance.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "dbo",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Category",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Name", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 26, 11, 20, 53, 411, DateTimeKind.Utc).AddTicks(3924), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Beauty", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, new DateTime(2023, 5, 26, 11, 20, 53, 411, DateTimeKind.Utc).AddTicks(4369), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Automotive", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, new DateTime(2023, 5, 26, 11, 20, 53, 411, DateTimeKind.Utc).AddTicks(4388), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Computers", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, new DateTime(2023, 5, 26, 11, 20, 53, 411, DateTimeKind.Utc).AddTicks(4400), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Outdoors", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 5, new DateTime(2023, 5, 26, 11, 20, 53, 411, DateTimeKind.Utc).AddTicks(4408), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Clothing", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 6, new DateTime(2023, 5, 26, 11, 20, 53, 411, DateTimeKind.Utc).AddTicks(4419), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Grocery", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 7, new DateTime(2023, 5, 26, 11, 20, 53, 411, DateTimeKind.Utc).AddTicks(4427), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tools", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 8, new DateTime(2023, 5, 26, 11, 20, 53, 411, DateTimeKind.Utc).AddTicks(4434), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Baby", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 9, new DateTime(2023, 5, 26, 11, 20, 53, 411, DateTimeKind.Utc).AddTicks(4443), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Electronics", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 10, new DateTime(2023, 5, 26, 11, 20, 53, 411, DateTimeKind.Utc).AddTicks(4451), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Movies", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Product",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Name", "Status", "Tag", "UpdatedAt", "UpdatedBy", "Url" },
                values: new object[,]
                {
                    { 1, 6, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(4362), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Small Soft Car", 1, "3397256128365", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://kaylin.net" },
                    { 2, 5, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(5434), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Small Soft Hat", 1, "9385976234903", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://dominique.biz" },
                    { 3, 4, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(5626), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Fantastic Cotton Towels", 1, "8576297255857", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://lennie.biz" },
                    { 4, 3, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(5719), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Practical Cotton Shoes", 1, "4296933998880", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://stanford.net" },
                    { 5, 8, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(5807), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Handmade Metal Sausages", 1, "6666526365227", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://jamison.com" },
                    { 6, 1, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(5978), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Licensed Fresh Tuna", 1, "2298615802418", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://bianka.name" },
                    { 7, 10, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(6060), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tasty Rubber Car", 1, "9056339729793", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://larissa.biz" },
                    { 8, 2, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(6128), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Rustic Plastic Car", 1, "2884994063788", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://betty.com" },
                    { 9, 6, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(6194), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sleek Concrete Cheese", 1, "8270243350657", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://jadyn.com" },
                    { 10, 8, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(6340), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Incredible Metal Mouse", 1, "1154888150049", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://gerda.com" },
                    { 11, 1, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(6412), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Handcrafted Fresh Cheese", 1, "8149081437038", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://demetris.biz" },
                    { 12, 8, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(6485), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Practical Metal Bike", 1, "5036553233324", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://eryn.biz" },
                    { 13, 4, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(6559), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Handmade Soft Salad", 1, "8124039616710", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://jamison.info" },
                    { 14, 10, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(6631), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Handmade Concrete Chicken", 1, "2457507569642", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://magali.com" },
                    { 15, 6, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(6705), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Fantastic Rubber Shirt", 1, "6579135857574", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://verona.com" },
                    { 16, 9, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(6855), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Handmade Plastic Gloves", 1, "0404826081326", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://elsa.net" },
                    { 17, 3, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(6936), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Handcrafted Soft Fish", 1, "7526020772534", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://wiley.com" },
                    { 18, 2, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(7010), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Handmade Granite Mouse", 1, "9353944583100", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://jayson.net" },
                    { 19, 5, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(7084), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Handmade Metal Pizza", 1, "4135751632791", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://agnes.com" },
                    { 20, 7, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(7159), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Unbranded Fresh Keyboard", 1, "7521621165242", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://rodolfo.info" },
                    { 21, 10, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(7246), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Refined Plastic Chips", 1, "2669397506526", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://jules.name" },
                    { 22, 2, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(7323), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Incredible Concrete Chicken", 1, "3810294704525", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://lue.biz" },
                    { 23, 4, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(7466), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Unbranded Steel Pizza", 1, "9513442714899", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://kade.name" },
                    { 24, 4, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(7540), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Unbranded Steel Shoes", 1, "7286931584571", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://garth.name" },
                    { 25, 2, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(7617), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sleek Plastic Pants", 1, "2129638855559", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://lea.name" },
                    { 26, 3, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(7734), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Generic Frozen Fish", 1, "2185745934266", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://angelica.name" },
                    { 27, 3, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(7808), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Fantastic Soft Soap", 1, "1022677915172", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://ımogene.com" },
                    { 28, 10, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(7883), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Refined Wooden Soap", 1, "5733886097066", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://baby.info" },
                    { 29, 2, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(8057), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gorgeous Fresh Chicken", 1, "2406010631452", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://cydney.biz" },
                    { 30, 10, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(8144), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Awesome Plastic Fish", 1, "7837435766972", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://deondre.org" },
                    { 31, 4, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(8220), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Handmade Wooden Chips", 1, "2366092005254", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://adell.com" },
                    { 32, 3, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(8297), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Awesome Metal Cheese", 1, "0268273766058", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://ıgnacio.net" },
                    { 33, 3, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(8374), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Fantastic Steel Computer", 1, "6279472631355", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://archibald.biz" },
                    { 34, 8, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(8452), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Small Metal Car", 1, "5335129572516", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://margarete.biz" },
                    { 35, 4, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(8525), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Handcrafted Cotton Ball", 1, "3460475293135", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://gladys.com" },
                    { 36, 6, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(8713), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Refined Granite Sausages", 1, "8491568929629", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://viviane.org" },
                    { 37, 1, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(8795), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gorgeous Fresh Bike", 1, "3064004553211", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://chasity.biz" },
                    { 38, 8, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(8872), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Handcrafted Granite Hat", 1, "0835191505924", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://laury.biz" },
                    { 39, 1, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(8950), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tasty Plastic Tuna", 1, "5649667742349", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://scarlett.info" },
                    { 40, 8, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(9027), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Small Granite Salad", 1, "5560518585772", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://fritz.com" },
                    { 41, 3, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(9107), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tasty Frozen Computer", 1, "4827555820114", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://greta.info" },
                    { 42, 4, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(9338), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Rustic Rubber Chair", 1, "6457580266113", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://cristina.org" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Product",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Name", "Status", "Tag", "UpdatedAt", "UpdatedBy", "Url" },
                values: new object[,]
                {
                    { 43, 2, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(9442), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Refined Fresh Table", 1, "3623632357310", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://flavie.org" },
                    { 44, 2, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(9519), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gorgeous Concrete Computer", 1, "6431031656265", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://nichole.name" },
                    { 45, 8, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(9602), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Awesome Plastic Sausages", 1, "3140256753729", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://bartholome.net" },
                    { 46, 3, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(9682), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Refined Plastic Salad", 1, "7963135450924", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://lavinia.org" },
                    { 47, 2, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(9758), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Handmade Soft Tuna", 1, "6918598608994", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://jamaal.biz" },
                    { 48, 10, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(9892), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Intelligent Concrete Bike", 1, "7698975687185", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://ashton.org" },
                    { 49, 1, new DateTime(2023, 5, 26, 11, 20, 53, 415, DateTimeKind.Utc).AddTicks(9983), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Fantastic Plastic Computer", 1, "4029006220553", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://dakota.name" },
                    { 50, 2, new DateTime(2023, 5, 26, 11, 20, 53, 416, DateTimeKind.Utc).AddTicks(63), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Practical Rubber Bike", 1, "8665147278334", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://mina.org" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_Id",
                schema: "dbo",
                table: "Category",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_Name",
                schema: "dbo",
                table: "Category",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                schema: "dbo",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Id",
                schema: "dbo",
                table: "Product",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_Name",
                schema: "dbo",
                table: "Product",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "dbo");
        }
    }
}
