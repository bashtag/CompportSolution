using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompportDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class deviceid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Devices_DeviceId",
                table: "Complaints");

            migrationBuilder.AlterColumn<int>(
                name: "DeviceId",
                table: "Complaints",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_Devices_DeviceId",
                table: "Complaints",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Devices_DeviceId",
                table: "Complaints");

            migrationBuilder.AlterColumn<int>(
                name: "DeviceId",
                table: "Complaints",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_Devices_DeviceId",
                table: "Complaints",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
