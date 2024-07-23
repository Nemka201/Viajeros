using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Viajeros.API.Migrations
{
    /// <inheritdoc />
    public partial class fixVideos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideoTags_Videos_VideoID",
                table: "VideoTags");

            migrationBuilder.AlterColumn<int>(
                name: "VideoID",
                table: "VideoTags",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoTags_Videos_VideoID",
                table: "VideoTags",
                column: "VideoID",
                principalTable: "Videos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideoTags_Videos_VideoID",
                table: "VideoTags");

            migrationBuilder.AlterColumn<int>(
                name: "VideoID",
                table: "VideoTags",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoTags_Videos_VideoID",
                table: "VideoTags",
                column: "VideoID",
                principalTable: "Videos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
