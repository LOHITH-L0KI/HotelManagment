using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class Booking_Details_Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Details_Customer_Details_CustomerId",
                table: "Booking_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Details_Room_Details_RoomId",
                table: "Booking_Details");

            migrationBuilder.DropIndex(
                name: "IX_Booking_Details_CustomerId",
                table: "Booking_Details");

            migrationBuilder.DropIndex(
                name: "IX_Booking_Details_RoomId",
                table: "Booking_Details");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Booking_Details");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Booking_Details");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Details_Customer_Id",
                table: "Booking_Details",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Details_Room_Id",
                table: "Booking_Details",
                column: "Room_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Details_Customer_Details_Customer_Id",
                table: "Booking_Details",
                column: "Customer_Id",
                principalTable: "Customer_Details",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Details_Room_Details_Room_Id",
                table: "Booking_Details",
                column: "Room_Id",
                principalTable: "Room_Details",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Details_Customer_Details_Customer_Id",
                table: "Booking_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Details_Room_Details_Room_Id",
                table: "Booking_Details");

            migrationBuilder.DropIndex(
                name: "IX_Booking_Details_Customer_Id",
                table: "Booking_Details");

            migrationBuilder.DropIndex(
                name: "IX_Booking_Details_Room_Id",
                table: "Booking_Details");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Booking_Details",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RoomId",
                table: "Booking_Details",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Details_CustomerId",
                table: "Booking_Details",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Details_RoomId",
                table: "Booking_Details",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Details_Customer_Details_CustomerId",
                table: "Booking_Details",
                column: "CustomerId",
                principalTable: "Customer_Details",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Details_Room_Details_RoomId",
                table: "Booking_Details",
                column: "RoomId",
                principalTable: "Room_Details",
                principalColumn: "Id");
        }
    }
}
