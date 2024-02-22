using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompportDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class complaint_phone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complains_Devices_DeviceId",
                table: "Complains");

            migrationBuilder.DropForeignKey(
                name: "FK_Complains_Users_UserId",
                table: "Complains");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Complains_ComplaintId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Complains",
                table: "Complains");

            migrationBuilder.RenameTable(
                name: "Complains",
                newName: "Complaints");

            migrationBuilder.RenameIndex(
                name: "IX_Complains_UserId",
                table: "Complaints",
                newName: "IX_Complaints_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Complains_DeviceId",
                table: "Complaints",
                newName: "IX_Complaints_DeviceId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Complaints",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Complaints",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Complaints",
                table: "Complaints",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_Devices_DeviceId",
                table: "Complaints",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_Users_UserId",
                table: "Complaints",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Complaints_ComplaintId",
                table: "Messages",
                column: "ComplaintId",
                principalTable: "Complaints",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Devices_DeviceId",
                table: "Complaints");

            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Users_UserId",
                table: "Complaints");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Complaints_ComplaintId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Complaints",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Complaints");

            migrationBuilder.RenameTable(
                name: "Complaints",
                newName: "Complains");

            migrationBuilder.RenameIndex(
                name: "IX_Complaints_UserId",
                table: "Complains",
                newName: "IX_Complains_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Complaints_DeviceId",
                table: "Complains",
                newName: "IX_Complains_DeviceId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Complains",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Complains",
                table: "Complains",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Complains_Devices_DeviceId",
                table: "Complains",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Complains_Users_UserId",
                table: "Complains",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Complains_ComplaintId",
                table: "Messages",
                column: "ComplaintId",
                principalTable: "Complains",
                principalColumn: "Id");
        }
    }
}
