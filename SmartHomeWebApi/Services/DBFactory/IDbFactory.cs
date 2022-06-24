namespace SmartHomeWebApi.Services.DBFactory;

public interface IDbFactory
{
    IDbDevices CreateDbDevices();
    IDbRooms CreateDbRoom();
    IDbDeviceTypes CreateDbDeviceTypes();
}