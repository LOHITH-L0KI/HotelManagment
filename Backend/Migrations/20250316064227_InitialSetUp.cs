using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialSetUp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer_Details",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ContactNumber = table.Column<string>(type: "varchar(10)", nullable: false),
                    Address = table.Column<string>(type: "varchar(200)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_Details", x => x.Id);
                    table.UniqueConstraint("AK_Customer_Details_FirstName_LastName", x => new { x.FirstName, x.LastName });
                });

            migrationBuilder.CreateTable(
                name: "Room_Details",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<long>(type: "bigint", nullable: false),
                    Floor = table.Column<long>(type: "bigint", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    HasAC = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room_Details", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User_Details",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false),
                    ContactNumber = table.Column<string>(type: "varchar(10)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false, defaultValue: 2)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Details", x => x.Id);
                    table.UniqueConstraint("AK_User_Details_FirstName_LastName", x => new { x.FirstName, x.LastName });
                });

            migrationBuilder.CreateTable(
                name: "Booking_Details",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Room_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Customer_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OutTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckedIn = table.Column<bool>(type: "bit", nullable: false),
                    Advance = table.Column<int>(type: "int", nullable: false),
                    Rent = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Details_Customer_Details_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer_Details",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Booking_Details_Room_Details_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room_Details",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Details_CustomerId",
                table: "Booking_Details",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Details_RoomId",
                table: "Booking_Details",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Details_ContactNumber",
                table: "Customer_Details",
                column: "ContactNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Details_Email",
                table: "Customer_Details",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Room_Details_Number_Floor",
                table: "Room_Details",
                columns: new[] { "Number", "Floor" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Details_ContactNumber",
                table: "User_Details",
                column: "ContactNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Details_Email",
                table: "User_Details",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking_Details");

            migrationBuilder.DropTable(
                name: "User_Details");

            migrationBuilder.DropTable(
                name: "Customer_Details");

            migrationBuilder.DropTable(
                name: "Room_Details");
        }
    }
}
