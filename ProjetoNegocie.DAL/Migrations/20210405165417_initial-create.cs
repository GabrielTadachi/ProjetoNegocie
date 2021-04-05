using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ProjetoNegocie.DAL.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "app_negocie_endereco",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cep = table.Column<string>(type: "text", nullable: true),
                    logradouro = table.Column<string>(type: "text", nullable: true),
                    complemento = table.Column<string>(type: "text", nullable: true),
                    bairro = table.Column<string>(type: "text", nullable: true),
                    localidade = table.Column<string>(type: "text", nullable: true),
                    uf = table.Column<string>(type: "text", nullable: true),
                    ibge = table.Column<string>(type: "text", nullable: true),
                    gia = table.Column<string>(type: "text", nullable: true),
                    ddd = table.Column<int>(type: "integer", nullable: false),
                    siafi = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_app_negocie_endereco", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "app_negocie_endereco");
        }
    }
}
