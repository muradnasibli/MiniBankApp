using System.Text.Json;
using Microsoft.Extensions.Options;
using MiniBankApp.API.Helpers.Base;

namespace MiniBankApp.API.Helpers;

public class JsonConverterService<T> : IConvert<T>
{
    public string Serialize(T entity)
    {
        return JsonSerializer.Serialize(entity);
    }

    public T Deserialize(string data)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        
        return JsonSerializer.Deserialize<T>(data, options);
    }
}