using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaMenuTest.Migrations
{
    /// <inheritdoc />
    public partial class Updated_PizzaIngriients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PizzaIngridient",
                table: "PizzaIngridient");

            migrationBuilder.DropIndex(
                name: "IX_PizzaIngridient_PizzaId",
                table: "PizzaIngridient");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PizzaIngridient");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PizzaIngridient",
                table: "PizzaIngridient",
                columns: new[] { "PizzaId", "IngridientId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PizzaIngridient",
                table: "PizzaIngridient");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PizzaIngridient",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PizzaIngridient",
                table: "PizzaIngridient",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaIngridient_PizzaId",
                table: "PizzaIngridient",
                column: "PizzaId");
        }
    }
}
