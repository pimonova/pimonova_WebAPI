using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace pimonova_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class TablesRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstrumentalEmissionMeasuringsOfSIZAV_Pollutants");

            migrationBuilder.DropTable(
                name: "InstrumentalEmissionMeasuringsOfSIZAV");

            migrationBuilder.CreateTable(
                name: "InstrumentalEmissionMeasurings",
                columns: table => new
                {
                    ResultID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    StationaryIZAVID = table.Column<int>(type: "integer", nullable: true),
                    DiameterOfWasteGas = table.Column<float>(type: "real", nullable: false),
                    SpeedOfWasteGas = table.Column<float>(type: "real", nullable: false),
                    VolumetricFlowRateOfWasteGasNC = table.Column<float>(type: "real", nullable: false),
                    TrueVolumetricFlowRateOfWasteGas = table.Column<float>(type: "real", nullable: false),
                    TemperatureOfWasteGas = table.Column<short>(type: "smallint", nullable: false),
                    PressureOfWasteGas = table.Column<short>(type: "smallint", nullable: false),
                    WaterVaporConcentration = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentalEmissionMeasurings", x => x.ResultID);
                    table.ForeignKey(
                        name: "FK_InstrumentalEmissionMeasurings_StationaryIZAVs_StationaryIZ~",
                        column: x => x.StationaryIZAVID,
                        principalTable: "StationaryIZAVs",
                        principalColumn: "StationaryIZAVID");
                });

            migrationBuilder.CreateTable(
                name: "InstrumentalEmissionMeasurings_Pollutants",
                columns: table => new
                {
                    InstrumentalEmissionMeasuringID = table.Column<int>(type: "integer", nullable: false),
                    PollutantCode = table.Column<int>(type: "integer", nullable: false),
                    MassConcentration = table.Column<float>(type: "real", nullable: false),
                    PollutantEmission = table.Column<float>(type: "real", nullable: false),
                    MeanPollutantEmission = table.Column<float>(type: "real", nullable: false),
                    MaxPollutantEmission = table.Column<float>(type: "real", nullable: false),
                    MeasuringMethod = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentalEmissionMeasurings_Pollutants", x => new { x.InstrumentalEmissionMeasuringID, x.PollutantCode });
                    table.ForeignKey(
                        name: "FK_InstrumentalEmissionMeasurings_Pollutants_InstrumentalEmiss~",
                        column: x => x.InstrumentalEmissionMeasuringID,
                        principalTable: "InstrumentalEmissionMeasurings",
                        principalColumn: "ResultID");
                    table.ForeignKey(
                        name: "FK_InstrumentalEmissionMeasurings_Pollutants_Pollutants_Pollut~",
                        column: x => x.PollutantCode,
                        principalTable: "Pollutants",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentalEmissionMeasurings_StationaryIZAVID",
                table: "InstrumentalEmissionMeasurings",
                column: "StationaryIZAVID");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentalEmissionMeasurings_Pollutants_PollutantCode",
                table: "InstrumentalEmissionMeasurings_Pollutants",
                column: "PollutantCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstrumentalEmissionMeasurings_Pollutants");

            migrationBuilder.DropTable(
                name: "InstrumentalEmissionMeasurings");

            migrationBuilder.CreateTable(
                name: "InstrumentalEmissionMeasuringsOfSIZAV",
                columns: table => new
                {
                    ResultID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StationaryIZAVID = table.Column<int>(type: "integer", nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    DiameterOfWasteGas = table.Column<float>(type: "real", nullable: false),
                    PressureOfWasteGas = table.Column<short>(type: "smallint", nullable: false),
                    SpeedOfWasteGas = table.Column<float>(type: "real", nullable: false),
                    TemperatureOfWasteGas = table.Column<short>(type: "smallint", nullable: false),
                    TrueVolumetricFlowRateOfWasteGas = table.Column<float>(type: "real", nullable: false),
                    VolumetricFlowRateOfWasteGasNC = table.Column<float>(type: "real", nullable: false),
                    WaterVaporConcentration = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentalEmissionMeasuringsOfSIZAV", x => x.ResultID);
                    table.ForeignKey(
                        name: "FK_InstrumentalEmissionMeasuringsOfSIZAV_StationaryIZAVs_Stati~",
                        column: x => x.StationaryIZAVID,
                        principalTable: "StationaryIZAVs",
                        principalColumn: "StationaryIZAVID");
                });

            migrationBuilder.CreateTable(
                name: "InstrumentalEmissionMeasuringsOfSIZAV_Pollutants",
                columns: table => new
                {
                    InstrumentalEmissionMeasuringOfSIZAVID = table.Column<int>(type: "integer", nullable: false),
                    PollutantCode = table.Column<int>(type: "integer", nullable: false),
                    MassConcentration = table.Column<float>(type: "real", nullable: false),
                    MaxPollutantEmission = table.Column<float>(type: "real", nullable: false),
                    MeanPollutantEmission = table.Column<float>(type: "real", nullable: false),
                    MeasuringMethod = table.Column<string>(type: "text", nullable: false),
                    PollutantEmission = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentalEmissionMeasuringsOfSIZAV_Pollutants", x => new { x.InstrumentalEmissionMeasuringOfSIZAVID, x.PollutantCode });
                    table.ForeignKey(
                        name: "FK_InstrumentalEmissionMeasuringsOfSIZAV_Pollutants_Instrument~",
                        column: x => x.InstrumentalEmissionMeasuringOfSIZAVID,
                        principalTable: "InstrumentalEmissionMeasuringsOfSIZAV",
                        principalColumn: "ResultID");
                    table.ForeignKey(
                        name: "FK_InstrumentalEmissionMeasuringsOfSIZAV_Pollutants_Pollutants~",
                        column: x => x.PollutantCode,
                        principalTable: "Pollutants",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentalEmissionMeasuringsOfSIZAV_StationaryIZAVID",
                table: "InstrumentalEmissionMeasuringsOfSIZAV",
                column: "StationaryIZAVID");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentalEmissionMeasuringsOfSIZAV_Pollutants_PollutantC~",
                table: "InstrumentalEmissionMeasuringsOfSIZAV_Pollutants",
                column: "PollutantCode");
        }
    }
}
