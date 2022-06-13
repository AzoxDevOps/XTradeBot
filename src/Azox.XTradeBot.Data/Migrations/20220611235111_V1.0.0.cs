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
                name: "SystemUserGroup",
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
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUserGroup", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "SystemUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastUpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserGroupId = table.Column<int>(type: "int", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    PasswordHashed = table.Column<bool>(type: "bit", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
                    FailedLoginAttemptCount = table.Column<int>(type: "int", nullable: false),
                    LastLockTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastLoginTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Extended = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemUser_SystemUserGroup_UserGroupId",
                        column: x => x.UserGroupId,
                        principalTable: "SystemUserGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SystemUserExchange",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastUpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    ExchangeId = table.Column<int>(type: "int", nullable: true),
                    ApiKey = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    ApiSecretKey = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUserExchange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemUserExchange_Exchange_ExchangeId",
                        column: x => x.ExchangeId,
                        principalTable: "Exchange",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SystemUserExchange_SystemUser_UserId",
                        column: x => x.UserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SystemUserCurrency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastUpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserExchangeId = table.Column<int>(type: "int", nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: true),
                    Available = table.Column<decimal>(type: "decimal(36,18)", precision: 36, scale: 18, nullable: false),
                    Locked = table.Column<decimal>(type: "decimal(36,18)", precision: 36, scale: 18, nullable: false),
                    SoftLocked = table.Column<decimal>(type: "decimal(36,18)", precision: 36, scale: 18, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUserCurrency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemUserCurrency_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SystemUserCurrency_SystemUserExchange_UserExchangeId",
                        column: x => x.UserExchangeId,
                        principalTable: "SystemUserExchange",
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

            migrationBuilder.CreateIndex(
                name: "IX_SystemUser_CreationTime",
                table: "SystemUser",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUser_UserGroupId",
                table: "SystemUser",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUser_Username",
                table: "SystemUser",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserCurrency_CreationTime",
                table: "SystemUserCurrency",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserCurrency_CurrencyId",
                table: "SystemUserCurrency",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserCurrency_UserExchangeId",
                table: "SystemUserCurrency",
                column: "UserExchangeId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserExchange_CreationTime",
                table: "SystemUserExchange",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserExchange_ExchangeId",
                table: "SystemUserExchange",
                column: "ExchangeId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserExchange_UserId",
                table: "SystemUserExchange",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserGroup_Code",
                table: "SystemUserGroup",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserGroup_CreationTime",
                table: "SystemUserGroup",
                column: "CreationTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExchangePair");

            migrationBuilder.DropTable(
                name: "SystemUserCurrency");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "SystemUserExchange");

            migrationBuilder.DropTable(
                name: "Exchange");

            migrationBuilder.DropTable(
                name: "SystemUser");

            migrationBuilder.DropTable(
                name: "SystemUserGroup");
        }
    }
}
