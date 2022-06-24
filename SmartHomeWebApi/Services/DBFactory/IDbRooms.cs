using SmartHomeWebApi.Data.Models;

namespace SmartHomeWebApi.Services.DBFactory;

public interface IDbRooms
{
    Rooms GetAllRooms();
    int AddNewRoom(Room room);
    void ChangeRoomName(Room room);
    void DeleteRoom(Room room);
}