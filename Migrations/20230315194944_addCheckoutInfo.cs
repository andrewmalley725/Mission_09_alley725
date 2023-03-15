using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission_09_alley725.Migrations
{
    public partial class addCheckoutInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CheckoutInfo",
                columns: table => new
                {
                    CheckoutId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckoutInfo", x => x.CheckoutId);
                });

            migrationBuilder.CreateTable(
                name: "LineItem",
                columns: table => new
                {
                    LineItemID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    quantity = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: true),
                    CheckoutId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineItem", x => x.LineItemID);
                    table.ForeignKey(
                        name: "FK_LineItem_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LineItem_CheckoutInfo_CheckoutId",
                        column: x => x.CheckoutId,
                        principalTable: "CheckoutInfo",
                        principalColumn: "CheckoutId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_BookId",
                table: "LineItem",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_CheckoutId",
                table: "LineItem",
                column: "CheckoutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LineItem");

            migrationBuilder.DropTable(
                name: "CheckoutInfo");
        }
    }
}
