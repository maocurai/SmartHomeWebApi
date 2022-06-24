using SmartHomeWebApi.Data;
using SmartHomeWebApi.Data.Models;

namespace SmartHomeWebApi.Services.DBFactory;

public class DbRooms : IDbRooms
{
    private ApplicationContext _context;

    public DbRooms(ApplicationContext context)
    {
        _context = context;
    }

    public Rooms GetAllRooms()
    {
        return new Rooms() { ListRooms = _context.Rooms.ToList() };
    }

    public int AddNewRoom(Room room)
    {
        _context.Rooms.Add(room);
        _context.SaveChanges();
        return room.Id;
    }

    public void ChangeRoomName(Room room)
    {
        _context.Rooms.Update(room);
        _context.SaveChanges();
    }

    public void DeleteRoom(Room room)
    {
        _context.Rooms.Remove(room);
        _context.SaveChanges();
    }
}