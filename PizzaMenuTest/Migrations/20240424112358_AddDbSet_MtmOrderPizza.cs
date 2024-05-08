using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaMenuTest.Migrations
{
    /// <inheritdoc />
    public partial class AddDbSet_MtmOrderPizza : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderPizzaOrderId",
                table: "Pizzas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderPizzaPizzaId",
                table: "Pizzas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderPizzaOrderId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderPizzaPizzaId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MtmOrerPizza",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    PizzaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MtmOrerPizza", x => new { x.OrderId, x.PizzaId });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_OrderPizzaOrderId_OrderPizzaPizzaId",
                table: "Pizzas",
                columns: new[] { "OrderPizzaOrderId", "OrderPizzaPizzaId" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderPizzaOrderId_OrderPizzaPizzaId",
                table: "Orders",
                columns: new[] { "OrderPizzaOrderId", "OrderPizzaPizzaId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_MtmOrerPizza_OrderPizzaOrderId_OrderPizzaPizzaId",
                table: "Orders",
                columns: new[] { "OrderPizzaOrderId", "OrderPizzaPizzaId" },
                principalTable: "MtmOrerPizza",
                principalColumns: new[] { "OrderId", "PizzaId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_MtmOrerPizza_OrderPizzaOrderId_OrderPizzaPizzaId",
                table: "Pizzas",
                columns: new[] { "OrderPizzaOrderId", "OrderPizzaPizzaId" },
                principalTable: "MtmOrerPizza",
                principalColumns: new[] { "OrderId", "PizzaId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_MtmOrerPizza_OrderPizzaOrderId_OrderPizzaPizzaId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_MtmOrerPizza_OrderPizzaOrderId_OrderPizzaPizzaId",
                table: "Pizzas");

            migrationBuilder.DropTable(
                name: "MtmOrerPizza");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_OrderPizzaOrderId_OrderPizzaPizzaId",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderPizzaOrderId_OrderPizzaPizzaId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderPizzaOrderId",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "OrderPizzaPizzaId",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "OrderPizzaOrderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderPizzaPizzaId",
                table: "Orders");
        }
    }
}
