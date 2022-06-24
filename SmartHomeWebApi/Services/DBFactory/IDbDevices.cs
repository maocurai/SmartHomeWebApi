using SmartHomeWebApi.Data.Models;

namespace SmartHomeWebApi.Services.DBFactory;

public interface IDbDevices
{
    Devices GetAllDevices();
    int AddNewDevice(Device device);
    void ChangeStatus(Device device);
    void DeleteDevice(Device device);
}