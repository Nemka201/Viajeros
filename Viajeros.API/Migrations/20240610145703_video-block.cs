using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Viajeros.API.Migrations
{
    /// <inheritdoc />
    public partial class videoblock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VideoLink",
                table: "Videos",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<string>(
                name: "VideoLinkFourth",
                table: "Videos",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VideoLinkSecond",
                table: "Videos",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VideoLinkThird",
                table: "Videos",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoLinkFourth",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "VideoLinkSecond",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "VideoLinkThird",
                table: "Videos");

            migrationBuilder.AlterColumn<string>(
                name: "VideoLink",
                table: "Videos",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);
        }
    }
}
