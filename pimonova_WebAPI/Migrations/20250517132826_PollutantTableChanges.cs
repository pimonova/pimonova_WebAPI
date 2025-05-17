using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace pimonova_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class PollutantTableChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentalEmissionMeasurings_Pollutants_Pollutants_Pollut~",
                table: "InstrumentalEmissionMeasurings_Pollutants");

            migrationBuilder.DropForeignKey(
                name: "FK_MobileIZAVs_Pollutants_Pollutants_PollutantCode",
                table: "MobileIZAVs_Pollutants");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultsOfGasCleanersInspection_Pollutants_Pollutants_Pollut~",
                table: "ResultsOfGasCleanersInspection_Pollutants");

            migrationBuilder.DropForeignKey(
                name: "FK_SourcesOfPollutants_Pollutants_Pollutants_PollutantCode",
                table: "SourcesOfPollutants_Pollutants");

            migrationBuilder.DropForeignKey(
                name: "FK_StationaryIZAVs_Pollutants_Pollutants_PollutantCode",
                table: "StationaryIZAVs_Pollutants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pollutants",
                table: "Pollutants");

            migrationBuilder.RenameColumn(
                name: "PollutantCode",
                table: "StationaryIZAVs_Pollutants",
                newName: "PollutantID");

            migrationBuilder.RenameIndex(
                name: "IX_StationaryIZAVs_Pollutants_PollutantCode",
                table: "StationaryIZAVs_Pollutants",
                newName: "IX_StationaryIZAVs_Pollutants_PollutantID");

            migrationBuilder.RenameColumn(
                name: "PollutantCode",
                table: "SourcesOfPollutants_Pollutants",
                newName: "PollutantID");

            migrationBuilder.RenameIndex(
                name: "IX_SourcesOfPollutants_Pollutants_PollutantCode",
                table: "SourcesOfPollutants_Pollutants",
                newName: "IX_SourcesOfPollutants_Pollutants_PollutantID");

            migrationBuilder.RenameColumn(
                name: "PollutantCode",
                table: "ResultsOfGasCleanersInspection_Pollutants",
                newName: "PollutantID");

            migrationBuilder.RenameIndex(
                name: "IX_ResultsOfGasCleanersInspection_Pollutants_PollutantCode",
                table: "ResultsOfGasCleanersInspection_Pollutants",
                newName: "IX_ResultsOfGasCleanersInspection_Pollutants_PollutantID");

            migrationBuilder.RenameColumn(
                name: "PollutantCode",
                table: "MobileIZAVs_Pollutants",
                newName: "PollutantID");

            migrationBuilder.RenameIndex(
                name: "IX_MobileIZAVs_Pollutants_PollutantCode",
                table: "MobileIZAVs_Pollutants",
                newName: "IX_MobileIZAVs_Pollutants_PollutantID");

            migrationBuilder.RenameColumn(
                name: "PollutantCode",
                table: "InstrumentalEmissionMeasurings_Pollutants",
                newName: "PollutantID");

            migrationBuilder.RenameIndex(
                name: "IX_InstrumentalEmissionMeasurings_Pollutants_PollutantCode",
                table: "InstrumentalEmissionMeasurings_Pollutants",
                newName: "IX_InstrumentalEmissionMeasurings_Pollutants_PollutantID");

            migrationBuilder.AlterColumn<int>(
                name: "Code",
                table: "Pollutants",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "PollutantID",
                table: "Pollutants",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pollutants",
                table: "Pollutants",
                column: "PollutantID");

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentalEmissionMeasurings_Pollutants_Pollutants_Pollut~",
                table: "InstrumentalEmissionMeasurings_Pollutants",
                column: "PollutantID",
                principalTable: "Pollutants",
                principalColumn: "PollutantID");

            migrationBuilder.AddForeignKey(
                name: "FK_MobileIZAVs_Pollutants_Pollutants_PollutantID",
                table: "MobileIZAVs_Pollutants",
                column: "PollutantID",
                principalTable: "Pollutants",
                principalColumn: "PollutantID");

            migrationBuilder.AddForeignKey(
                name: "FK_ResultsOfGasCleanersInspection_Pollutants_Pollutants_Pollut~",
                table: "ResultsOfGasCleanersInspection_Pollutants",
                column: "PollutantID",
                principalTable: "Pollutants",
                principalColumn: "PollutantID");

            migrationBuilder.AddForeignKey(
                name: "FK_SourcesOfPollutants_Pollutants_Pollutants_PollutantID",
                table: "SourcesOfPollutants_Pollutants",
                column: "PollutantID",
                principalTable: "Pollutants",
                principalColumn: "PollutantID");

            migrationBuilder.AddForeignKey(
                name: "FK_StationaryIZAVs_Pollutants_Pollutants_PollutantID",
                table: "StationaryIZAVs_Pollutants",
                column: "PollutantID",
                principalTable: "Pollutants",
                principalColumn: "PollutantID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentalEmissionMeasurings_Pollutants_Pollutants_Pollut~",
                table: "InstrumentalEmissionMeasurings_Pollutants");

            migrationBuilder.DropForeignKey(
                name: "FK_MobileIZAVs_Pollutants_Pollutants_PollutantID",
                table: "MobileIZAVs_Pollutants");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultsOfGasCleanersInspection_Pollutants_Pollutants_Pollut~",
                table: "ResultsOfGasCleanersInspection_Pollutants");

            migrationBuilder.DropForeignKey(
                name: "FK_SourcesOfPollutants_Pollutants_Pollutants_PollutantID",
                table: "SourcesOfPollutants_Pollutants");

            migrationBuilder.DropForeignKey(
                name: "FK_StationaryIZAVs_Pollutants_Pollutants_PollutantID",
                table: "StationaryIZAVs_Pollutants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pollutants",
                table: "Pollutants");

            migrationBuilder.DropColumn(
                name: "PollutantID",
                table: "Pollutants");

            migrationBuilder.RenameColumn(
                name: "PollutantID",
                table: "StationaryIZAVs_Pollutants",
                newName: "PollutantCode");

            migrationBuilder.RenameIndex(
                name: "IX_StationaryIZAVs_Pollutants_PollutantID",
                table: "StationaryIZAVs_Pollutants",
                newName: "IX_StationaryIZAVs_Pollutants_PollutantCode");

            migrationBuilder.RenameColumn(
                name: "PollutantID",
                table: "SourcesOfPollutants_Pollutants",
                newName: "PollutantCode");

            migrationBuilder.RenameIndex(
                name: "IX_SourcesOfPollutants_Pollutants_PollutantID",
                table: "SourcesOfPollutants_Pollutants",
                newName: "IX_SourcesOfPollutants_Pollutants_PollutantCode");

            migrationBuilder.RenameColumn(
                name: "PollutantID",
                table: "ResultsOfGasCleanersInspection_Pollutants",
                newName: "PollutantCode");

            migrationBuilder.RenameIndex(
                name: "IX_ResultsOfGasCleanersInspection_Pollutants_PollutantID",
                table: "ResultsOfGasCleanersInspection_Pollutants",
                newName: "IX_ResultsOfGasCleanersInspection_Pollutants_PollutantCode");

            migrationBuilder.RenameColumn(
                name: "PollutantID",
                table: "MobileIZAVs_Pollutants",
                newName: "PollutantCode");

            migrationBuilder.RenameIndex(
                name: "IX_MobileIZAVs_Pollutants_PollutantID",
                table: "MobileIZAVs_Pollutants",
                newName: "IX_MobileIZAVs_Pollutants_PollutantCode");

            migrationBuilder.RenameColumn(
                name: "PollutantID",
                table: "InstrumentalEmissionMeasurings_Pollutants",
                newName: "PollutantCode");

            migrationBuilder.RenameIndex(
                name: "IX_InstrumentalEmissionMeasurings_Pollutants_PollutantID",
                table: "InstrumentalEmissionMeasurings_Pollutants",
                newName: "IX_InstrumentalEmissionMeasurings_Pollutants_PollutantCode");

            migrationBuilder.AlterColumn<int>(
                name: "Code",
                table: "Pollutants",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pollutants",
                table: "Pollutants",
                column: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentalEmissionMeasurings_Pollutants_Pollutants_Pollut~",
                table: "InstrumentalEmissionMeasurings_Pollutants",
                column: "PollutantCode",
                principalTable: "Pollutants",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_MobileIZAVs_Pollutants_Pollutants_PollutantCode",
                table: "MobileIZAVs_Pollutants",
                column: "PollutantCode",
                principalTable: "Pollutants",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_ResultsOfGasCleanersInspection_Pollutants_Pollutants_Pollut~",
                table: "ResultsOfGasCleanersInspection_Pollutants",
                column: "PollutantCode",
                principalTable: "Pollutants",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_SourcesOfPollutants_Pollutants_Pollutants_PollutantCode",
                table: "SourcesOfPollutants_Pollutants",
                column: "PollutantCode",
                principalTable: "Pollutants",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_StationaryIZAVs_Pollutants_Pollutants_PollutantCode",
                table: "StationaryIZAVs_Pollutants",
                column: "PollutantCode",
                principalTable: "Pollutants",
                principalColumn: "Code");
        }
    }
}
