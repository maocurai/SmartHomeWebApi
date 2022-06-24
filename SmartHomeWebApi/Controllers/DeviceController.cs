using Microsoft.AspNetCore.Mvc;
using SmartHomeWebApi.Data.Models;
using SmartHomeWebApi.Services.DBFactory;

namespace SmartHomeWebApi.Controllers;

[ApiController]
[Route("api/Devices")]
public class DeviceController : ControllerBase
{
    private readonly IDbDevices _devices;

    public DeviceController(IDbFactory factory)
    {
        _devices = factory.CreateDbDevices();
    }
    
    [HttpGet]
    [Route("GetAllDevices")]
    public IActionResult GetAllDevices()
    {
        return Ok(_devices.GetAllDevices());
    }

    [HttpPost]
    [Route("AddNewDevice")]
    public IActionResult AddNewDevice(Device device)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        device.Id = 0;

        return Ok(_devices.AddNewDevice(device));
    }

    [HttpPost]
    [Route("ChangeStatus")]
    public IActionResult ChangeStatus(Device device)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Invalid Model");
        }
        
        _devices.ChangeStatus(device);
        return Ok();
    }

    [HttpPost]
    [Route("DeleteDevice")]
    public IActionResult DeleteDevice(Device device)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        
        _devices.DeleteDevice(device);

        return Ok();
    }
}