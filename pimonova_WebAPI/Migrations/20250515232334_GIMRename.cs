using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pimonova_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class GIMRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VolumeOfGIM",
                table: "StationaryIZAVs",
                newName: "VolumeOfGAM");

            migrationBuilder.RenameColumn(
                name: "TemperatureOfGIM",
                table: "StationaryIZAVs",
                newName: "TemperatureOfGAM");

            migrationBuilder.RenameColumn(
                name: "OutputSpeedOfGIM",
                table: "StationaryIZAVs",
                newName: "OutputSpeedOfGAM");

            migrationBuilder.RenameColumn(
                name: "DensityOfGIM",
                table: "StationaryIZAVs",
                newName: "DensityOfGAM");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VolumeOfGAM",
                table: "StationaryIZAVs",
                newName: "VolumeOfGIM");

            migrationBuilder.RenameColumn(
                name: "TemperatureOfGAM",
                table: "StationaryIZAVs",
                newName: "TemperatureOfGIM");

            migrationBuilder.RenameColumn(
                name: "OutputSpeedOfGAM",
                table: "StationaryIZAVs",
                newName: "OutputSpeedOfGIM");

            migrationBuilder.RenameColumn(
                name: "DensityOfGAM",
                table: "StationaryIZAVs",
                newName: "DensityOfGIM");
        }
    }
}
