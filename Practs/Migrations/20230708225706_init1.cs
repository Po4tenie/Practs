using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Practs.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T001",
                columns: table => new
                {
                    BURKS = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    BUTXT = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ZINMM_SOF_LOT_H",
                columns: table => new
                {
                    LOT_ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KONKURS_ID = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    LOT_NR = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    LOT_NAME = table.Column<string>(type: "character varying(132)", maxLength: 132, nullable: true),
                    EKORG = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    FINAN_LIMIT_WVAT = table.Column<decimal>(type: "numeric", nullable: false),
                    FINAN_LIMIT_WOVAT = table.Column<decimal>(type: "numeric", nullable: false),
                    VAT_RATE = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    CALC_NDS = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZINMM_SOF_LOT_H", x => x.LOT_ID);
                });

            migrationBuilder.CreateTable(
                name: "ZTINMM_TK_H",
                columns: table => new
                {
                    KONKURS_ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KONKURS_NR = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    KONKURS_NAME = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    BURKS = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    ORG_KEY = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    STAT = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    CRT_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CRT_TIME = table.Column<TimeSpan>(type: "interval", nullable: false),
                    CRT_USER = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZTINMM_TK_H", x => x.KONKURS_ID);
                });

            migrationBuilder.CreateTable(
                name: "ZTINMM_TK_OFR",
                columns: table => new
                {
                    KONKURS_ID = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    LOT_ID = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    TABIX = table.Column<int>(type: "integer", maxLength: 5, nullable: false),
                    LIFNR = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    LIFNR_NAME = table.Column<string>(type: "character varying(132)", maxLength: 132, nullable: true),
                    OFR_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OFR_TIME = table.Column<TimeSpan>(type: "interval", nullable: false),
                    PRICE_NDS = table.Column<decimal>(type: "numeric", nullable: false),
                    PRICE_S_NDS = table.Column<decimal>(type: "numeric", nullable: false),
                    DELIVER_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DELIVER_TIME = table.Column<TimeSpan>(type: "interval", nullable: false),
                    WIN_FLG = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T001");

            migrationBuilder.DropTable(
                name: "ZINMM_SOF_LOT_H");

            migrationBuilder.DropTable(
                name: "ZTINMM_TK_H");

            migrationBuilder.DropTable(
                name: "ZTINMM_TK_OFR");
        }
    }
}
