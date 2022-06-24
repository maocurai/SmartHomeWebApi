using Microsoft.AspNetCore.Mvc;
using SmartHomeWebApi.Data.Models;
using SmartHomeWebApi.Services.DBFactory;

namespace SmartHomeWebApi.Controllers;

[ApiController]
[Route("api/DeviceTypes")]
public class DeviceTypeController : ControllerBase
{
    private readonly IDbDeviceTypes _deviceTypes;

    public DeviceTypeController(IDbFactory factory)
    {
        _deviceTypes = factory.CreateDbDeviceTypes();
    }

    [HttpGet]
    [Route("GetAllDeviceTypes")]
    public IActionResult GetAllDeviceTypes()
    {
        return Ok(_deviceTypes.GetAllDeviceTypes());
    }

    [HttpPost]
    [Route("AddNewDeviceType")]
    public IActionResult AddNewDeviceType(DeviceType deviceType)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        deviceType.Id = 0;

        return Ok(_deviceTypes.AddNewDeviceType(deviceType));
    }

    [HttpPost]
    [Route("ChangeDeviceTypeName")]
    public IActionResult ChangeDeviceTypeName(DeviceType deviceType)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        
        _deviceTypes.ChangeDeviceTypeName(deviceType);
        
        return Ok();
    }

    [HttpPost]
    [Route("DeleteDeviceType")]
    public IActionResult DeleteDeviceType(DeviceType deviceType)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        
        _deviceTypes.DeleteDeviceType(deviceType);

        return Ok();
    }
}