using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompportDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class complaints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_ChatRooms_ChatRoomId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Complains_ComplainId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "ComplainId",
                table: "Messages",
                newName: "ComplaintId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ComplainId",
                table: "Messages",
                newName: "IX_Messages_ComplaintId");

            migrationBuilder.AlterColumn<int>(
                name: "ChatRoomId",
                table: "Messages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Devices",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_ChatRooms_ChatRoomId",
                table: "Messages",
                column: "ChatRoomId",
                principalTable: "ChatRooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Complains_ComplaintId",
                table: "Messages",
                column: "ComplaintId",
                principalTable: "Complains",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_ChatRooms_ChatRoomId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Complains_ComplaintId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "ComplaintId",
                table: "Messages",
                newName: "ComplainId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ComplaintId",
                table: "Messages",
                newName: "IX_Messages_ComplainId");

            migrationBuilder.AlterColumn<int>(
                name: "ChatRoomId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Devices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_ChatRooms_ChatRoomId",
                table: "Messages",
                column: "ChatRoomId",
                principalTable: "ChatRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Complains_ComplainId",
                table: "Messages",
                column: "ComplainId",
                principalTable: "Complains",
                principalColumn: "Id");
        }
    }
}
