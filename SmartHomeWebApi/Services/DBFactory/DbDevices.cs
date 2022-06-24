using Microsoft.EntityFrameworkCore;
using SmartHomeWebApi.Data;
using SmartHomeWebApi.Data.Models;

namespace SmartHomeWebApi.Services.DBFactory;

public class DbDevices : IDbDevices
{
    private ApplicationContext _context;

    public DbDevices(ApplicationContext context)
    {
        _context = context;
    }

    public Devices GetAllDevices()
    {
        return new Devices() { ListDevices = _context.Devices.ToList() };
    }

    public int AddNewDevice(Device device)
    {
        _context.Devices.Add(device);
        _context.SaveChanges();
        return device.Id;
    }

    public void ChangeStatus(Device device)
    {
        Device deviceFromDb = _context.Devices.Find(device.Id);
        deviceFromDb.Status = device.Status;
        _context.SaveChanges();
    }

    public void DeleteDevice(Device device)
    {
        _context.Devices.Remove(device);
        _context.SaveChanges();
    }
}