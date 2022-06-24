using Microsoft.AspNetCore.Mvc;
using SmartHomeWebApi.Data.Models;
using SmartHomeWebApi.Services.DBFactory;

namespace SmartHomeWebApi.Controllers;

[ApiController]
[Route("api/Rooms")]
public class RoomController : ControllerBase
{
    private readonly IDbRooms _rooms;

    public RoomController(IDbFactory factory)
    {
        _rooms = factory.CreateDbRoom();
    }

    [HttpGet]
    [Route("GetAllRooms")]
    public IActionResult GetAllRooms()
    {
        return Ok(_rooms.GetAllRooms());
    }

    [HttpPost]
    [Route("AddNewRoom")]
    public IActionResult AddNewRoom(Room room)
    {
        if (!ModelState.IsValid) return BadRequest();
        room.Id = 0;
        return Ok(_rooms.AddNewRoom(room));
    }

    [HttpPost]
    [Route("ChangeRoomName")]
    public IActionResult ChangeRoomName(Room room)
    {
        if (!ModelState.IsValid) return BadRequest();
        _rooms.ChangeRoomName(room);
        return Ok();
    }

    [HttpPost]
    [Route("DeleteRoom")]
    public IActionResult DeleteRoom(Room room)
    {
        if (!ModelState.IsValid) return BadRequest();
        _rooms.DeleteRoom(room);
        return Ok();
    }
}