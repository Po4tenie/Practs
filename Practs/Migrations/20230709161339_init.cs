using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Practs.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ZTINMM_TK_OFR",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "T001",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ZTINMM_TK_OFR",
                table: "ZTINMM_TK_OFR",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_T001",
                table: "T001",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ZTINMM_TK_OFR",
                table: "ZTINMM_TK_OFR");

            migrationBuilder.DropPrimaryKey(
                name: "PK_T001",
                table: "T001");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ZTINMM_TK_OFR");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "T001");
        }
    }
}
