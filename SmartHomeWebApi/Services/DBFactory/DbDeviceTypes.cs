using SmartHomeWebApi.Data;
using SmartHomeWebApi.Data.Models;

namespace SmartHomeWebApi.Services.DBFactory;

public class DbDeviceTypes : IDbDeviceTypes
{
    private ApplicationContext _context;

    public DbDeviceTypes(ApplicationContext context)
    {
        _context = context;
    }

    public DeviceTypes GetAllDeviceTypes()
    {
        return new DeviceTypes() { ListDeviceTypes = _context.DeviceTypes.ToList() };
    }

    public int AddNewDeviceType(DeviceType deviceType)
    {
        _context.DeviceTypes.Add(deviceType);
        _context.SaveChanges();
        return deviceType.Id;
    }

    public void ChangeDeviceTypeName(DeviceType deviceType)
    {
        _context.DeviceTypes.Update(deviceType);
        _context.SaveChanges();
    }

    public void DeleteDeviceType(DeviceType deviceType)
    {
        _context.DeviceTypes.Remove(deviceType);
        _context.SaveChanges();
    }
}