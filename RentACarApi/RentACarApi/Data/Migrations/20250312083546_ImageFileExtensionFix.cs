using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentACarApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class ImageFileExtensionFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "Path",
                value: "AF109A5C-041F-47E1-A103-ADD976BCD83B.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                column: "Path",
                value: "631C96AF-2FD2-4198-86C5-5A9A011EDBBE.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "Path",
                value: "0BD9FD45-B1E9-4E47-BAA5-4A25C240907D.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                column: "Path",
                value: "64BAACEA-7F1F-4F81-8498-4759FCCFEEAE.jpeg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5,
                column: "Path",
                value: "34DE130B-8E3C-4007-95A5-DEB9E77F8CE6.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "Path",
                value: "AF109A5C-041F-47E1-A103-ADD976BCD83B");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                column: "Path",
                value: "631C96AF-2FD2-4198-86C5-5A9A011EDBBE");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "Path",
                value: "0BD9FD45-B1E9-4E47-BAA5-4A25C240907D");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                column: "Path",
                value: "64BAACEA-7F1F-4F81-8498-4759FCCFEEAE");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5,
                column: "Path",
                value: "34DE130B-8E3C-4007-95A5-DEB9E77F8CE6");
        }
    }
}
