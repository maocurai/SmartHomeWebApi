using SmartHomeWebApi.Data;

namespace SmartHomeWebApi.Services.DBFactory;

public class DbFactory : IDbFactory
{
    private ApplicationContext _context;

    public DbFactory(ApplicationContext context)
    {
        _context = context;
    }

    public IDbDevices CreateDbDevices()
    {
        return new DbDevices(_context);
    }

    public IDbRooms CreateDbRoom()
    {
        return new DbRooms(_context);
    }

    public IDbDeviceTypes CreateDbDeviceTypes()
    {
        return new DbDeviceTypes(_context);
    }
}