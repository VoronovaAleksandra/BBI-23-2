//сериализация
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

public abstract class MySerializer
{
    public abstract void Write(List<Garage> garages, string filePath);
    public abstract List<Garage> Read(string filePath);
}

//JSON
public class VehicleConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(Vehicle);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        var jsonObject = JObject.Load(reader);
        var vehicleType = jsonObject["Type"].Value<string>();

        Vehicle vehicle;
        switch (vehicleType)
        {
            case "Car":
                vehicle = new Car();
                break;
            case "Truck":
                vehicle = new Truck();
                break;
            case "Motorcycle":
                vehicle = new Motorcycle();
                break;
            default:
                throw new InvalidOperationException("Unknown vehicle type");
        }

        serializer.Populate(jsonObject.CreateReader(), vehicle);
        return vehicle;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}


public class MyJsonSerializer : MySerializer
{
    public override void Write(List<Garage> garages, string filePath)
    {
        var jsonData = JsonConvert.SerializeObject(garages, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText(filePath, jsonData);
    }

    public override List<Garage> Read(string filePath)
    {
        var jsonData = File.ReadAllText(filePath);
        var settings = new JsonSerializerSettings();
        settings.Converters.Add(new VehicleConverter());
        return JsonConvert.DeserializeObject<List<Garage>>(jsonData, settings);
    }
}