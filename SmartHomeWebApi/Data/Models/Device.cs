namespace SmartHomeWebApi.Data.Models;

public class Device
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int DeviceTypeId { get; set; }
    public bool Status { get; set; }
    public int RoomId { get; set; }
    public  string Description { get; set; }

    public Device(int id, string name, int deviceTypeId, int roomId, string description)
    {
        Id = id;
        Name = name;
        DeviceTypeId = deviceTypeId;
        RoomId = roomId;
        Description = description;
        Status = false;
    }
}