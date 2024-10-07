using Bogus;
using hotelapi.Models;
using Microsoft.EntityFrameworkCore;


namespace hotelapi.Seeders
{
    public class RoomSeeder
    {
        public static void Seed(ModelBuilder modelBuilder, int amout)
        {
            var rooms = GenerateRooms(amout);
            modelBuilder.Entity<Room>().HasData(rooms);
        }

        public static IEnumerable<Room> GenerateRooms(int count)
        {
            var faker = new Faker<Room>()
                .RuleFor(a => a.Id, f => f.IndexFaker + 1)
                .RuleFor(a => a.RoomNumber, (f, r) =>
                {
                    int floor = (r.Id - 1) / 5; // Determinar el piso (0, 1, 2, ...)
                    int roomOnFloor = (r.Id - 1) % 5 + 1; // Habitaciones del 1 al 5 en cada piso
                    return (floor * 100 + 101 + (roomOnFloor - 1)).ToString(); // Formato 101, 102, ..., 105, 201, ...
                })
                .RuleFor(a => a.RoomTypeId, f => f.Random.Number(1, 4)) // Asignar un tipo de habitación aleatorio (1 a 4)
                .RuleFor(a => a.PricePerNight, (f, r) =>
                {
                    return r.RoomTypeId switch
                    {
                        1 => 50,  // Habitación Simple
                        2 => 80,  // Habitación Doble
                        3 => 150, // Suite
                        4 => 200, // Habitación Familiar
                        _ => 100 // Default
                    };
                })
                .RuleFor(a => a.Availability, f => true) // Todas las habitaciones siempre disponibles
                .RuleFor(a => a.MaxOccupancyPersons, (f, r) =>
                {
                    var roomTypeId = r.RoomTypeId; // Almacenar el ID de tipo de habitación
                    return roomTypeId switch
                    {
                        1 => 1,
                        2 => 2,
                        3 => 2,
                        4 => 4,
                        _ => 1
                    };
                });

            return faker.Generate(count);
        }


    }
}