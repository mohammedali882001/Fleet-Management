using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnasProject.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    DriverId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.DriverId);
                });

            migrationBuilder.CreateTable(
                name: "Geofences",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeofenceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<long>(type: "bigint", nullable: false),
                    StrockColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    StrockOpacity = table.Column<double>(type: "float", nullable: false),
                    StrockWeight = table.Column<double>(type: "float", nullable: false),
                    FillColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FillOpacity = table.Column<double>(type: "float", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    Radius = table.Column<long>(type: "bigint", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    GeofenceId = table.Column<long>(type: "bigint", nullable: true),
                    PolygonGeofence_Latitude = table.Column<double>(type: "float", nullable: true),
                    PolygonGeofence_Longitude = table.Column<double>(type: "float", nullable: true),
                    PolygonGeofence_GeofenceId = table.Column<long>(type: "bigint", nullable: true),
                    North = table.Column<double>(type: "float", nullable: true),
                    East = table.Column<double>(type: "float", nullable: true),
                    West = table.Column<double>(type: "float", nullable: true),
                    South = table.Column<double>(type: "float", nullable: true),
                    RectangleGeofence_GeofenceId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Geofences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Geofences_Geofences_GeofenceId",
                        column: x => x.GeofenceId,
                        principalTable: "Geofences",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Geofences_Geofences_PolygonGeofence_GeofenceId",
                        column: x => x.PolygonGeofence_GeofenceId,
                        principalTable: "Geofences",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Geofences_Geofences_RectangleGeofence_GeofenceId",
                        column: x => x.RectangleGeofence_GeofenceId,
                        principalTable: "Geofences",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleNumber = table.Column<long>(type: "bigint", nullable: false),
                    VehicleType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                });

            migrationBuilder.CreateTable(
                name: "RouteHistories",
                columns: table => new
                {
                    RouteHistoryId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<long>(type: "bigint", nullable: false),
                    VehicleDirection = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    VehicleSpeed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Epoch = table.Column<long>(type: "bigint", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteHistories", x => x.RouteHistoryId);
                    table.ForeignKey(
                        name: "FK_RouteHistories_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "VehiclesInformations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<long>(type: "bigint", nullable: true),
                    DriverId = table.Column<long>(type: "bigint", nullable: true),
                    VehicleMake = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    VehicleModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchaseDate = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclesInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehiclesInformations_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "DriverId");
                    table.ForeignKey(
                        name: "FK_VehiclesInformations_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Geofences_GeofenceId",
                table: "Geofences",
                column: "GeofenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Geofences_PolygonGeofence_GeofenceId",
                table: "Geofences",
                column: "PolygonGeofence_GeofenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Geofences_RectangleGeofence_GeofenceId",
                table: "Geofences",
                column: "RectangleGeofence_GeofenceId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteHistories_VehicleId",
                table: "RouteHistories",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclesInformations_DriverId",
                table: "VehiclesInformations",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclesInformations_VehicleId",
                table: "VehiclesInformations",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Geofences");

            migrationBuilder.DropTable(
                name: "RouteHistories");

            migrationBuilder.DropTable(
                name: "VehiclesInformations");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
