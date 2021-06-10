using Microsoft.EntityFrameworkCore.Migrations;

namespace Todolist_App.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tarea",
                columns: table => new
                {
                    id_tarea = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion_tarea = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    estado_tarea = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tarea", x => x.id_tarea);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tarea");
        }
    }
}
