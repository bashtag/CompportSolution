using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompportDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class yeni : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complains_ChatRooms_ChatRoomId",
                table: "Complains");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Addresses_AddressId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AddressId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Complains_ChatRoomId",
                table: "Complains");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ChatRoomId",
                table: "Complains");

            migrationBuilder.AddColumn<int>(
                name: "ComplainId",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ComplainId",
                table: "Messages",
                column: "ComplainId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Complains_ComplainId",
                table: "Messages",
                column: "ComplainId",
                principalTable: "Complains",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Complains_ComplainId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ComplainId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ComplainId",
                table: "Messages");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ChatRoomId",
                table: "Complains",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddressId",
                table: "Users",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Complains_ChatRoomId",
                table: "Complains",
                column: "ChatRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Complains_ChatRooms_ChatRoomId",
                table: "Complains",
                column: "ChatRoomId",
                principalTable: "ChatRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Addresses_AddressId",
                table: "Users",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
