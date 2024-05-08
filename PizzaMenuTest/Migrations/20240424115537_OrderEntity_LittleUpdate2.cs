using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaMenuTest.Migrations
{
    /// <inheritdoc />
    public partial class OrderEntity_LittleUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_MtmOrerPizza_OrderPizzaOrderId_OrderPizzaPizzaId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Orders_OrderId",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_OrderId",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderPizzaOrderId_OrderPizzaPizzaId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "OrderPizzaOrderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderPizzaPizzaId",
                table: "Orders");

            migrationBuilder.CreateTable(
                name: "OrderOrderPizza",
                columns: table => new
                {
                    OrdersId = table.Column<int>(type: "int", nullable: false),
                    PizzasOrderId = table.Column<int>(type: "int", nullable: false),
                    PizzasPizzaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderOrderPizza", x => new { x.OrdersId, x.PizzasOrderId, x.PizzasPizzaId });
                    table.ForeignKey(
                        name: "FK_OrderOrderPizza_MtmOrerPizza_PizzasOrderId_PizzasPizzaId",
                        columns: x => new { x.PizzasOrderId, x.PizzasPizzaId },
                        principalTable: "MtmOrerPizza",
                        principalColumns: new[] { "OrderId", "PizzaId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderOrderPizza_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderOrderPizza_PizzasOrderId_PizzasPizzaId",
                table: "OrderOrderPizza",
                columns: new[] { "PizzasOrderId", "PizzasPizzaId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderOrderPizza");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
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

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_OrderId",
                table: "Pizzas",
                column: "OrderId");

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
                name: "FK_Pizzas_Orders_OrderId",
                table: "Pizzas",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
