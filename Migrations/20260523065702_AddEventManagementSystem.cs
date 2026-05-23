using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DenzelDev.Migrations
{
    /// <inheritdoc />
    public partial class AddEventManagementSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    OrganizerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Budgets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Budgets_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    TaskName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AssignedTo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskItems_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EventDate", "Location", "OrganizerName", "Title" },
                values: new object[] { 1, "A premier 48-hour programming league challenge designed to assemble software engineering student teams to build dynamic C# applications.", new DateTime(2026, 6, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Manila Tech Dome Complex", "Student Alliance Executive Council", "National Developer Hackathon 2026" });

            migrationBuilder.InsertData(
                table: "Budgets",
                columns: new[] { "Id", "Amount", "EventId", "ItemName", "Type" },
                values: new object[,]
                {
                    { 1, 5000.00m, 1, "Corporate Sponsorships", "Sponsorship" },
                    { 2, 600.00m, 1, "Cloud Servers Provisioning", "Expense" },
                    { 3, 1800.00m, 1, "Physical Promos & Catering", "Expense" }
                });

            migrationBuilder.InsertData(
                table: "TaskItems",
                columns: new[] { "Id", "AssignedTo", "DueDate", "EventId", "Status", "TaskName" },
                values: new object[,]
                {
                    { 1, "Denzel Dev", new DateTime(2026, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Completed", "Provision deployment proxy bridges" },
                    { 2, "Pres. Alex", new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), 1, "In Progress", "Coordinate judges panel" },
                    { 3, "Graphics Team", new DateTime(2026, 6, 15, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Pending", "Distribute promotional details" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_EventId",
                table: "Budgets",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_EventId",
                table: "TaskItems",
                column: "EventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Budgets");

            migrationBuilder.DropTable(
                name: "TaskItems");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
