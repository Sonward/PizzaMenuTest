using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaMenuTest.Migrations
{
    /// <inheritdoc />
    public partial class AddDbSet_MtmPizzaIngrindient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PizzaIngridient_Ingriddients_IngridientId",
                table: "PizzaIngridient");

            migrationBuilder.DropForeignKey(
                name: "FK_PizzaIngridient_Pizzas_PizzaId",
                table: "PizzaIngridient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PizzaIngridient",
                table: "PizzaIngridient");

            migrationBuilder.RenameTable(
                name: "PizzaIngridient",
                newName: "MtmPizzaIngrindient");

            migrationBuilder.RenameIndex(
                name: "IX_PizzaIngridient_IngridientId",
                table: "MtmPizzaIngrindient",
                newName: "IX_MtmPizzaIngrindient_IngridientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MtmPizzaIngrindient",
                table: "MtmPizzaIngrindient",
                columns: new[] { "PizzaId", "IngridientId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MtmPizzaIngrindient_Ingriddients_IngridientId",
                table: "MtmPizzaIngrindient",
                column: "IngridientId",
                principalTable: "Ingriddients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MtmPizzaIngrindient_Pizzas_PizzaId",
                table: "MtmPizzaIngrindient",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MtmPizzaIngrindient_Ingriddients_IngridientId",
                table: "MtmPizzaIngrindient");

            migrationBuilder.DropForeignKey(
                name: "FK_MtmPizzaIngrindient_Pizzas_PizzaId",
                table: "MtmPizzaIngrindient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MtmPizzaIngrindient",
                table: "MtmPizzaIngrindient");

            migrationBuilder.RenameTable(
                name: "MtmPizzaIngrindient",
                newName: "PizzaIngridient");

            migrationBuilder.RenameIndex(
                name: "IX_MtmPizzaIngrindient_IngridientId",
                table: "PizzaIngridient",
                newName: "IX_PizzaIngridient_IngridientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PizzaIngridient",
                table: "PizzaIngridient",
                columns: new[] { "PizzaId", "IngridientId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaIngridient_Ingriddients_IngridientId",
                table: "PizzaIngridient",
                column: "IngridientId",
                principalTable: "Ingriddients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaIngridient_Pizzas_PizzaId",
                table: "PizzaIngridient",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
