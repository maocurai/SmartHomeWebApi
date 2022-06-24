namespace SmartHomeWebApi.Data.Models;

public class DeviceType
{
    public  int Id { get; set; }
    public  string Name { get; set; }

    public DeviceType(int id, string name)
    {
        Id = id;
        Name = name;
    }
}