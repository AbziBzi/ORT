using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Orienteering.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(254) CHARACTER SET utf8mb4", maxLength: 254, nullable: false),
                    Password = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(200) CHARACTER SET utf8mb4", maxLength: 200, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tracks_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(200) CHARACTER SET utf8mb4", maxLength: 200, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: false),
                    TrackId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Games_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrackPoints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(200) CHARACTER SET utf8mb4", maxLength: 200, nullable: true),
                    Coordinates_Longitude = table.Column<double>(type: "double", nullable: true),
                    Coordinates_Latitude = table.Column<double>(type: "double", nullable: true),
                    TrackId = table.Column<Guid>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackPoints_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameUser",
                columns: table => new
                {
                    GamesWhereParticipatesId = table.Column<Guid>(type: "char(36)", nullable: false),
                    ParticipantsId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameUser", x => new { x.GamesWhereParticipatesId, x.ParticipantsId });
                    table.ForeignKey(
                        name: "FK_GameUser_Games_GamesWhereParticipatesId",
                        column: x => x.GamesWhereParticipatesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameUser_Users_ParticipantsId",
                        column: x => x.ParticipantsId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_CreatorId",
                table: "Games",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_TrackId",
                table: "Games",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_GameUser_ParticipantsId",
                table: "GameUser",
                column: "ParticipantsId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackPoints_TrackId",
                table: "TrackPoints",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_CreatorId",
                table: "Tracks",
                column: "CreatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameUser");

            migrationBuilder.DropTable(
                name: "TrackPoints");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
