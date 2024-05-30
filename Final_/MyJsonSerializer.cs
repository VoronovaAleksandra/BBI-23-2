using System;
using System.IO;
using Newtonsoft.Json;
public class MyJsonSerializer : MySerializer
{
    private readonly JsonSerializerSettings _settings = new JsonSerializerSettings
    {
        TypeNameHandling = TypeNameHandling.Auto
    };

    public override void Write(Garage[] garages, string fileName)
    {
        var json = JsonConvert.SerializeObject(garages, Formatting.Indented, _settings);
        File.WriteAllText(fileName, json);
    }
    public override Garage[] Read(string fileName)
    {
        var json = File.ReadAllText(fileName);
        var garages = JsonConvert.DeserializeObject<Garage[]>(json, _settings);
        return garages ?? Array.Empty<Garage>();
    }
}