using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace hotelapi.Migrations
{
    /// <inheritdoc />
    public partial class seedDataForRoomAndRoomTypesAlsoCreateOtherTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    first_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    last_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    identication_number = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "guests",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    first_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    last_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    identification_number = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone_number = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    birthdate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guests", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "room_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_room_types", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "rooms",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    room_number = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    room_type_id = table.Column<int>(type: "int", nullable: false),
                    price_per_night = table.Column<double>(type: "double", nullable: false),
                    availability = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    max_occupancy_persons = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rooms", x => x.id);
                    table.ForeignKey(
                        name: "FK_rooms_room_types_room_type_id",
                        column: x => x.room_type_id,
                        principalTable: "room_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    room_id = table.Column<int>(type: "int", nullable: false),
                    guest_id = table.Column<int>(type: "int", nullable: false),
                    employee_id = table.Column<int>(type: "int", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    total_cost = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.id);
                    table.ForeignKey(
                        name: "FK_Bookings_employees_employee_id",
                        column: x => x.employee_id,
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_guests_guest_id",
                        column: x => x.guest_id,
                        principalTable: "guests",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_rooms_room_id",
                        column: x => x.room_id,
                        principalTable: "rooms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "room_types",
                columns: new[] { "id", "description", "name" },
                values: new object[,]
                {
                    { 1, "Una acogedora habitación básica con una cama individual, ideal para viajeros solos.", "Habitación Simple" },
                    { 2, "Ofrece flexibilidad con dos camas individuales o una cama doble, perfecta para parejas o amigos.", "Habitación Doble" },
                    { 3, "Espaciosa y lujosa, con una cama king size y una sala de estar separada, ideal para quienes buscan confort y exclusividad.", "Suite" },
                    { 4, "Diseñada para familias, con espacio adicional y varias camas para una estancia cómoda.", "Habitación Familiar" }
                });

            migrationBuilder.InsertData(
                table: "rooms",
                columns: new[] { "id", "availability", "max_occupancy_persons", "price_per_night", "room_number", "room_type_id" },
                values: new object[,]
                {
                    { 1, true, 4, 200.0, "101", 4 },
                    { 2, true, 2, 150.0, "102", 3 },
                    { 3, true, 2, 150.0, "103", 3 },
                    { 4, true, 1, 50.0, "104", 1 },
                    { 5, true, 1, 50.0, "105", 1 },
                    { 6, true, 2, 80.0, "201", 2 },
                    { 7, true, 4, 200.0, "202", 4 },
                    { 8, true, 4, 200.0, "203", 4 },
                    { 9, true, 1, 50.0, "204", 1 },
                    { 10, true, 2, 150.0, "205", 3 },
                    { 11, true, 2, 80.0, "301", 2 },
                    { 12, true, 4, 200.0, "302", 4 },
                    { 13, true, 2, 150.0, "303", 3 },
                    { 14, true, 1, 50.0, "304", 1 },
                    { 15, true, 4, 200.0, "305", 4 },
                    { 16, true, 1, 50.0, "401", 1 },
                    { 17, true, 2, 80.0, "402", 2 },
                    { 18, true, 2, 150.0, "403", 3 },
                    { 19, true, 4, 200.0, "404", 4 },
                    { 20, true, 2, 150.0, "405", 3 },
                    { 21, true, 2, 80.0, "501", 2 },
                    { 22, true, 2, 80.0, "502", 2 },
                    { 23, true, 2, 80.0, "503", 2 },
                    { 24, true, 2, 80.0, "504", 2 },
                    { 25, true, 1, 50.0, "505", 1 },
                    { 26, true, 4, 200.0, "601", 4 },
                    { 27, true, 2, 80.0, "602", 2 },
                    { 28, true, 2, 80.0, "603", 2 },
                    { 29, true, 2, 150.0, "604", 3 },
                    { 30, true, 1, 50.0, "605", 1 },
                    { 31, true, 4, 200.0, "701", 4 },
                    { 32, true, 4, 200.0, "702", 4 },
                    { 33, true, 4, 200.0, "703", 4 },
                    { 34, true, 1, 50.0, "704", 1 },
                    { 35, true, 2, 80.0, "705", 2 },
                    { 36, true, 2, 150.0, "801", 3 },
                    { 37, true, 2, 80.0, "802", 2 },
                    { 38, true, 2, 80.0, "803", 2 },
                    { 39, true, 4, 200.0, "804", 4 },
                    { 40, true, 2, 80.0, "805", 2 },
                    { 41, true, 2, 80.0, "901", 2 },
                    { 42, true, 4, 200.0, "902", 4 },
                    { 43, true, 4, 200.0, "903", 4 },
                    { 44, true, 1, 50.0, "904", 1 },
                    { 45, true, 2, 80.0, "905", 2 },
                    { 46, true, 2, 150.0, "1001", 3 },
                    { 47, true, 2, 150.0, "1002", 3 },
                    { 48, true, 2, 80.0, "1003", 2 },
                    { 49, true, 1, 50.0, "1004", 1 },
                    { 50, true, 2, 80.0, "1005", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_employee_id",
                table: "Bookings",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_guest_id",
                table: "Bookings",
                column: "guest_id");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_room_id",
                table: "Bookings",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "IX_rooms_room_type_id",
                table: "rooms",
                column: "room_type_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "guests");

            migrationBuilder.DropTable(
                name: "rooms");

            migrationBuilder.DropTable(
                name: "room_types");
        }
    }
}
