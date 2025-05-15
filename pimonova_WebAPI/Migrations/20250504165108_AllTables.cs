using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace pimonova_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AllTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sectors_Workshops_WorkshopID",
                table: "Sectors");

            migrationBuilder.DropForeignKey(
                name: "FK_Workshops_ObjectsOfNEI_ObjectOfNEIID",
                table: "Workshops");

            migrationBuilder.AlterColumn<int>(
                name: "ObjectOfNEIID",
                table: "Workshops",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "WorkshopID",
                table: "Sectors",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "MobileIZAVs",
                columns: table => new
                {
                    MobileIZAVID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SectorID = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    NumberInCompany = table.Column<int>(type: "integer", nullable: false),
                    AmountOfIZAVWithOneNumber = table.Column<short>(type: "smallint", nullable: false),
                    Speed = table.Column<short>(type: "smallint", nullable: false),
                    Fuel = table.Column<string>(type: "text", nullable: false),
                    WorkingHoursPerSeason = table.Column<short>(type: "smallint", nullable: false),
                    WorkingHoursPerYear = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileIZAVs", x => x.MobileIZAVID);
                    table.ForeignKey(
                        name: "FK_MobileIZAVs_Sectors_SectorID",
                        column: x => x.SectorID,
                        principalTable: "Sectors",
                        principalColumn: "SectorID");
                });

            migrationBuilder.CreateTable(
                name: "ModesOfIZAVWithNonStationaryEmissions",
                columns: table => new
                {
                    ModeID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ModeDescription = table.Column<string>(type: "text", nullable: false),
                    TimeOfWorking = table.Column<short>(type: "smallint", nullable: false),
                    ModeNumberInCompany = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModesOfIZAVWithNonStationaryEmissions", x => x.ModeID);
                });

            migrationBuilder.CreateTable(
                name: "Pollutants",
                columns: table => new
                {
                    Code = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pollutants", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "StationaryIZAVs",
                columns: table => new
                {
                    StationaryIZAVID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SectorID = table.Column<int>(type: "integer", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    AmountOfIZAVWithOneNumber = table.Column<short>(type: "smallint", nullable: false),
                    IZAVHeight = table.Column<float>(type: "real", nullable: false),
                    EstuaryDiameter = table.Column<float>(type: "real", nullable: false),
                    NumberInCompany = table.Column<int>(type: "integer", nullable: false),
                    EstuaryLength = table.Column<float>(type: "real", nullable: false),
                    EstuaryWidth = table.Column<float>(type: "real", nullable: false),
                    ArealZAVWidth = table.Column<float>(type: "real", nullable: false),
                    ModeNumber = table.Column<short>(type: "smallint", nullable: false),
                    OutputSpeedOfGIM = table.Column<float>(type: "real", nullable: false),
                    VolumeOfGIM = table.Column<float>(type: "real", nullable: false),
                    TemperatureOfGIM = table.Column<short>(type: "smallint", nullable: false),
                    DensityOfGIM = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationaryIZAVs", x => x.StationaryIZAVID);
                    table.ForeignKey(
                        name: "FK_StationaryIZAVs_Sectors_SectorID",
                        column: x => x.SectorID,
                        principalTable: "Sectors",
                        principalColumn: "SectorID");
                });

            migrationBuilder.CreateTable(
                name: "MobileIZAVs_Pollutants",
                columns: table => new
                {
                    MobileIZAVID = table.Column<int>(type: "integer", nullable: false),
                    PollutantCode = table.Column<int>(type: "integer", nullable: false),
                    MeanPollutantEmission = table.Column<float>(type: "real", nullable: false),
                    MaxPollutantEmission = table.Column<float>(type: "real", nullable: false),
                    MeasuringMethod = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileIZAVs_Pollutants", x => new { x.MobileIZAVID, x.PollutantCode });
                    table.ForeignKey(
                        name: "FK_MobileIZAVs_Pollutants_MobileIZAVs_MobileIZAVID",
                        column: x => x.MobileIZAVID,
                        principalTable: "MobileIZAVs",
                        principalColumn: "MobileIZAVID");
                    table.ForeignKey(
                        name: "FK_MobileIZAVs_Pollutants_Pollutants_PollutantCode",
                        column: x => x.PollutantCode,
                        principalTable: "Pollutants",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "GasCleaners",
                columns: table => new
                {
                    GasCleanerID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SectorID = table.Column<int>(type: "integer", nullable: true),
                    NumberInCompany = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Brand = table.Column<string>(type: "text", nullable: false),
                    StationaryIZAVToOut = table.Column<int>(type: "integer", nullable: true),
                    StationaryIZAVID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GasCleaners", x => x.GasCleanerID);
                    table.ForeignKey(
                        name: "FK_GasCleaners_Sectors_SectorID",
                        column: x => x.SectorID,
                        principalTable: "Sectors",
                        principalColumn: "SectorID");
                    table.ForeignKey(
                        name: "FK_GasCleaners_StationaryIZAVs_StationaryIZAVID",
                        column: x => x.StationaryIZAVID,
                        principalTable: "StationaryIZAVs",
                        principalColumn: "StationaryIZAVID");
                });

            migrationBuilder.CreateTable(
                name: "InstrumentalEmissionMeasuringsOfSIZAV",
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
                    table.PrimaryKey("PK_InstrumentalEmissionMeasuringsOfSIZAV", x => x.ResultID);
                    table.ForeignKey(
                        name: "FK_InstrumentalEmissionMeasuringsOfSIZAV_StationaryIZAVs_Stati~",
                        column: x => x.StationaryIZAVID,
                        principalTable: "StationaryIZAVs",
                        principalColumn: "StationaryIZAVID");
                });

            migrationBuilder.CreateTable(
                name: "StationaryIZAVs_Pollutants",
                columns: table => new
                {
                    StationaryIZAVID = table.Column<int>(type: "integer", nullable: false),
                    PollutantCode = table.Column<int>(type: "integer", nullable: false),
                    PollutantConcentration = table.Column<float>(type: "real", nullable: false),
                    PollutantEmissionPower = table.Column<float>(type: "real", nullable: false),
                    GrossPollutantEmissionTonsPerYear = table.Column<float>(type: "real", nullable: false),
                    TotalPollutantEmissionTonsPerPeriod = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationaryIZAVs_Pollutants", x => new { x.StationaryIZAVID, x.PollutantCode });
                    table.ForeignKey(
                        name: "FK_StationaryIZAVs_Pollutants_Pollutants_PollutantCode",
                        column: x => x.PollutantCode,
                        principalTable: "Pollutants",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_StationaryIZAVs_Pollutants_StationaryIZAVs_StationaryIZAVID",
                        column: x => x.StationaryIZAVID,
                        principalTable: "StationaryIZAVs",
                        principalColumn: "StationaryIZAVID");
                });

            migrationBuilder.CreateTable(
                name: "ResultsOfGasCleanersInspection",
                columns: table => new
                {
                    ResultID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GasCleanerID = table.Column<int>(type: "integer", nullable: true),
                    ProjectCleaningDegree = table.Column<short>(type: "smallint", nullable: false),
                    TrueCleaningDegree = table.Column<short>(type: "smallint", nullable: false),
                    ProjectProvisionCoeff = table.Column<float>(type: "real", nullable: false),
                    TrueProvisionCoeff = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultsOfGasCleanersInspection", x => x.ResultID);
                    table.ForeignKey(
                        name: "FK_ResultsOfGasCleanersInspection_GasCleaners_GasCleanerID",
                        column: x => x.GasCleanerID,
                        principalTable: "GasCleaners",
                        principalColumn: "GasCleanerID");
                });

            migrationBuilder.CreateTable(
                name: "SourcesOfPollutants",
                columns: table => new
                {
                    SourceID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SectorID = table.Column<int>(type: "integer", nullable: true),
                    NumberInCompany = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ModeNumber = table.Column<short>(type: "smallint", nullable: true),
                    ModeOfIZAVWithNonStationaryEmissionsModeID = table.Column<int>(type: "integer", nullable: true),
                    WorkingHoursPerDay = table.Column<short>(type: "smallint", nullable: false),
                    WorkingHoursPerYear = table.Column<short>(type: "smallint", nullable: false),
                    AmountOfSOPWithOneNumber = table.Column<short>(type: "smallint", nullable: false),
                    GasCleanerID = table.Column<int>(type: "integer", nullable: true),
                    StationaryIZAVID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SourcesOfPollutants", x => x.SourceID);
                    table.ForeignKey(
                        name: "FK_SourcesOfPollutants_GasCleaners_GasCleanerID",
                        column: x => x.GasCleanerID,
                        principalTable: "GasCleaners",
                        principalColumn: "GasCleanerID");
                    table.ForeignKey(
                        name: "FK_SourcesOfPollutants_ModesOfIZAVWithNonStationaryEmissions_M~",
                        column: x => x.ModeOfIZAVWithNonStationaryEmissionsModeID,
                        principalTable: "ModesOfIZAVWithNonStationaryEmissions",
                        principalColumn: "ModeID");
                    table.ForeignKey(
                        name: "FK_SourcesOfPollutants_Sectors_SectorID",
                        column: x => x.SectorID,
                        principalTable: "Sectors",
                        principalColumn: "SectorID");
                    table.ForeignKey(
                        name: "FK_SourcesOfPollutants_StationaryIZAVs_StationaryIZAVID",
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
                    PollutantEmission = table.Column<float>(type: "real", nullable: false),
                    MeanPollutantEmission = table.Column<float>(type: "real", nullable: false),
                    MaxPollutantEmission = table.Column<float>(type: "real", nullable: false),
                    MeasuringMethod = table.Column<string>(type: "text", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "ResultsOfGasCleanersInspection_Pollutants",
                columns: table => new
                {
                    ResultOfGasCleanersInspectionID = table.Column<int>(type: "integer", nullable: false),
                    PollutantCode = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultsOfGasCleanersInspection_Pollutants", x => new { x.ResultOfGasCleanersInspectionID, x.PollutantCode });
                    table.ForeignKey(
                        name: "FK_ResultsOfGasCleanersInspection_Pollutants_Pollutants_Pollut~",
                        column: x => x.PollutantCode,
                        principalTable: "Pollutants",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_ResultsOfGasCleanersInspection_Pollutants_ResultsOfGasClean~",
                        column: x => x.ResultOfGasCleanersInspectionID,
                        principalTable: "ResultsOfGasCleanersInspection",
                        principalColumn: "ResultID");
                });

            migrationBuilder.CreateTable(
                name: "SourcesOfPollutants_Pollutants",
                columns: table => new
                {
                    SourceOfPollutantsID = table.Column<int>(type: "integer", nullable: false),
                    PollutantCode = table.Column<int>(type: "integer", nullable: false),
                    PollutantAmountGramsPerSecond = table.Column<float>(type: "real", nullable: false),
                    PollutantAmountTonsPerYear = table.Column<float>(type: "real", nullable: false),
                    TotalPollutantAmountTonsPerYear = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SourcesOfPollutants_Pollutants", x => new { x.SourceOfPollutantsID, x.PollutantCode });
                    table.ForeignKey(
                        name: "FK_SourcesOfPollutants_Pollutants_Pollutants_PollutantCode",
                        column: x => x.PollutantCode,
                        principalTable: "Pollutants",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_SourcesOfPollutants_Pollutants_SourcesOfPollutants_SourceOf~",
                        column: x => x.SourceOfPollutantsID,
                        principalTable: "SourcesOfPollutants",
                        principalColumn: "SourceID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GasCleaners_SectorID",
                table: "GasCleaners",
                column: "SectorID");

            migrationBuilder.CreateIndex(
                name: "IX_GasCleaners_StationaryIZAVID",
                table: "GasCleaners",
                column: "StationaryIZAVID");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentalEmissionMeasuringsOfSIZAV_StationaryIZAVID",
                table: "InstrumentalEmissionMeasuringsOfSIZAV",
                column: "StationaryIZAVID");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentalEmissionMeasuringsOfSIZAV_Pollutants_PollutantC~",
                table: "InstrumentalEmissionMeasuringsOfSIZAV_Pollutants",
                column: "PollutantCode");

            migrationBuilder.CreateIndex(
                name: "IX_MobileIZAVs_SectorID",
                table: "MobileIZAVs",
                column: "SectorID");

            migrationBuilder.CreateIndex(
                name: "IX_MobileIZAVs_Pollutants_PollutantCode",
                table: "MobileIZAVs_Pollutants",
                column: "PollutantCode");

            migrationBuilder.CreateIndex(
                name: "IX_ResultsOfGasCleanersInspection_GasCleanerID",
                table: "ResultsOfGasCleanersInspection",
                column: "GasCleanerID");

            migrationBuilder.CreateIndex(
                name: "IX_ResultsOfGasCleanersInspection_Pollutants_PollutantCode",
                table: "ResultsOfGasCleanersInspection_Pollutants",
                column: "PollutantCode");

            migrationBuilder.CreateIndex(
                name: "IX_SourcesOfPollutants_GasCleanerID",
                table: "SourcesOfPollutants",
                column: "GasCleanerID");

            migrationBuilder.CreateIndex(
                name: "IX_SourcesOfPollutants_ModeOfIZAVWithNonStationaryEmissionsMod~",
                table: "SourcesOfPollutants",
                column: "ModeOfIZAVWithNonStationaryEmissionsModeID");

            migrationBuilder.CreateIndex(
                name: "IX_SourcesOfPollutants_SectorID",
                table: "SourcesOfPollutants",
                column: "SectorID");

            migrationBuilder.CreateIndex(
                name: "IX_SourcesOfPollutants_StationaryIZAVID",
                table: "SourcesOfPollutants",
                column: "StationaryIZAVID");

            migrationBuilder.CreateIndex(
                name: "IX_SourcesOfPollutants_Pollutants_PollutantCode",
                table: "SourcesOfPollutants_Pollutants",
                column: "PollutantCode");

            migrationBuilder.CreateIndex(
                name: "IX_StationaryIZAVs_SectorID",
                table: "StationaryIZAVs",
                column: "SectorID");

            migrationBuilder.CreateIndex(
                name: "IX_StationaryIZAVs_Pollutants_PollutantCode",
                table: "StationaryIZAVs_Pollutants",
                column: "PollutantCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Sectors_Workshops_WorkshopID",
                table: "Sectors",
                column: "WorkshopID",
                principalTable: "Workshops",
                principalColumn: "WorkshopID");

            migrationBuilder.AddForeignKey(
                name: "FK_Workshops_ObjectsOfNEI_ObjectOfNEIID",
                table: "Workshops",
                column: "ObjectOfNEIID",
                principalTable: "ObjectsOfNEI",
                principalColumn: "ObjectOfNEIID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sectors_Workshops_WorkshopID",
                table: "Sectors");

            migrationBuilder.DropForeignKey(
                name: "FK_Workshops_ObjectsOfNEI_ObjectOfNEIID",
                table: "Workshops");

            migrationBuilder.DropTable(
                name: "InstrumentalEmissionMeasuringsOfSIZAV_Pollutants");

            migrationBuilder.DropTable(
                name: "MobileIZAVs_Pollutants");

            migrationBuilder.DropTable(
                name: "ResultsOfGasCleanersInspection_Pollutants");

            migrationBuilder.DropTable(
                name: "SourcesOfPollutants_Pollutants");

            migrationBuilder.DropTable(
                name: "StationaryIZAVs_Pollutants");

            migrationBuilder.DropTable(
                name: "InstrumentalEmissionMeasuringsOfSIZAV");

            migrationBuilder.DropTable(
                name: "MobileIZAVs");

            migrationBuilder.DropTable(
                name: "ResultsOfGasCleanersInspection");

            migrationBuilder.DropTable(
                name: "SourcesOfPollutants");

            migrationBuilder.DropTable(
                name: "Pollutants");

            migrationBuilder.DropTable(
                name: "GasCleaners");

            migrationBuilder.DropTable(
                name: "ModesOfIZAVWithNonStationaryEmissions");

            migrationBuilder.DropTable(
                name: "StationaryIZAVs");

            migrationBuilder.AlterColumn<int>(
                name: "ObjectOfNEIID",
                table: "Workshops",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WorkshopID",
                table: "Sectors",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sectors_Workshops_WorkshopID",
                table: "Sectors",
                column: "WorkshopID",
                principalTable: "Workshops",
                principalColumn: "WorkshopID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workshops_ObjectsOfNEI_ObjectOfNEIID",
                table: "Workshops",
                column: "ObjectOfNEIID",
                principalTable: "ObjectsOfNEI",
                principalColumn: "ObjectOfNEIID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
