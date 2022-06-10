using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Azox.XTradeBot.Data.Migrations
{
    public partial class V100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastUpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Extended = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exchange",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastUpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Extended = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exchange", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExchangePair",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastUpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExchangeId = table.Column<int>(type: "int", nullable: true),
                    BaseAssetId = table.Column<int>(type: "int", nullable: true),
                    QuoteAssetId = table.Column<int>(type: "int", nullable: true),
                    PairType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangePair", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExchangePair_Currency_BaseAssetId",
                        column: x => x.BaseAssetId,
                        principalTable: "Currency",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExchangePair_Currency_QuoteAssetId",
                        column: x => x.QuoteAssetId,
                        principalTable: "Currency",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExchangePair_Exchange_ExchangeId",
                        column: x => x.ExchangeId,
                        principalTable: "Exchange",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Currency_Code",
                table: "Currency",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Currency_CreationTime",
                table: "Currency",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_Exchange_Code",
                table: "Exchange",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exchange_CreationTime",
                table: "Exchange",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangePair_BaseAssetId",
                table: "ExchangePair",
                column: "BaseAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangePair_CreationTime",
                table: "ExchangePair",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangePair_ExchangeId",
                table: "ExchangePair",
                column: "ExchangeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangePair_QuoteAssetId",
                table: "ExchangePair",
                column: "QuoteAssetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExchangePair");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "Exchange");
        }
    }
}
