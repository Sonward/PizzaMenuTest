using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaMenuTest.Migrations
{
    /// <inheritdoc />
    public partial class IngrindientPizzaConnectionV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingriddients_PizzaIngridient_PizzaIngridientId",
                table: "Ingriddients");

            migrationBuilder.DropTable(
                name: "PizzaIngridient");

            migrationBuilder.DropIndex(
                name: "IX_Ingriddients_PizzaIngridientId",
                table: "Ingriddients");

            migrationBuilder.DropColumn(
                name: "PizzaIngridientId",
                table: "Ingriddients");

            migrationBuilder.CreateTable(
                name: "PizzaIngridients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PizzaId = table.Column<int>(type: "int", nullable: false),
                    IngridientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaIngridients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PizzaIngridients_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PizzaIngridients_PizzaId",
                table: "PizzaIngridients",
                column: "PizzaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaIngridients");

            migrationBuilder.AddColumn<int>(
                name: "PizzaIngridientId",
                table: "Ingriddients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PizzaIngridient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PizzaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaIngridient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PizzaIngridient_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingriddients_PizzaIngridientId",
                table: "Ingriddients",
                column: "PizzaIngridientId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaIngridient_PizzaId",
                table: "PizzaIngridient",
                column: "PizzaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingriddients_PizzaIngridient_PizzaIngridientId",
                table: "Ingriddients",
                column: "PizzaIngridientId",
                principalTable: "PizzaIngridient",
                principalColumn: "Id");
        }
    }
}
