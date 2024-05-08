using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaMenuTest.Migrations
{
    /// <inheritdoc />
    public partial class IngrindientPizzaConnection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingriddients_Pizzas_PizzaId",
                table: "Ingriddients");

            migrationBuilder.RenameColumn(
                name: "PizzaId",
                table: "Ingriddients",
                newName: "PizzaIngridientId");

            migrationBuilder.RenameIndex(
                name: "IX_Ingriddients_PizzaId",
                table: "Ingriddients",
                newName: "IX_Ingriddients_PizzaIngridientId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingriddients_PizzaIngridient_PizzaIngridientId",
                table: "Ingriddients");

            migrationBuilder.DropTable(
                name: "PizzaIngridient");

            migrationBuilder.RenameColumn(
                name: "PizzaIngridientId",
                table: "Ingriddients",
                newName: "PizzaId");

            migrationBuilder.RenameIndex(
                name: "IX_Ingriddients_PizzaIngridientId",
                table: "Ingriddients",
                newName: "IX_Ingriddients_PizzaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingriddients_Pizzas_PizzaId",
                table: "Ingriddients",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id");
        }
    }
}
