using SmartHomeWebApi.Data.Models;

namespace SmartHomeWebApi.Services.DBFactory;

public interface IDbDeviceTypes
{
    DeviceTypes GetAllDeviceTypes();
    int AddNewDeviceType(DeviceType deviceType);
    void ChangeDeviceTypeName(DeviceType deviceType);
    void DeleteDeviceType(DeviceType deviceType);
}