using Microsoft.EntityFrameworkCore;
using SmartHomeWebApi.Data.Models;

namespace SmartHomeWebApi.Data;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        Database.EnsureCreated();
        if (!Rooms.Any())
        {
            Rooms.AddRange(new Room[]
            {
                new Room(0, "Kitchen"), 
                new Room(0, "Bedroom")
            });
            SaveChanges();
        }
        if (!DeviceTypes.Any())
        {
            DeviceTypes.AddRange(new DeviceType[]
            {
                new DeviceType(0, "Electrical"),
                new DeviceType(0, "Lights"),
                new DeviceType(0, "Appliance"),
                new DeviceType(0, "Other")
            });
            SaveChanges();
        }
        if (!Devices.Any())
        {
            Devices.AddRange(new Device[]
            {
                new Device(0, "TV", 1, 1, "TV on kitchen"),
                new Device(0, "Lamp", 2, 2, "Lamp in bedroom")
            });
            SaveChanges();
        }
    }
    
    public DbSet<Room> Rooms { get; set; }
    public DbSet<DeviceType> DeviceTypes { get; set; }
    public DbSet<Device> Devices { get; set; }
}