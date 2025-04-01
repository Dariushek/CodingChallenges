using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CleverSnippets;

public class StringEnumConverter : JsonConverter<StringEnumBase>
{
    private readonly Dictionary<string, StringEnumBase> valueCache = new();

    public StringEnumConverter()
    {
        foreach (Type type in Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsSubclassOf(typeof(StringEnumBase))))
        {
            foreach (FieldInfo field in type.GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                var value = (StringEnumBase) field.GetValue(null);
                valueCache[value.Value] = value;
            }
        }
    }

    public override StringEnumBase Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? code = reader.GetString();
        valueCache.TryGetValue(code, out StringEnumBase? errorInstance);
        return errorInstance;
    }

    public override void Write(Utf8JsonWriter writer, StringEnumBase value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Value);
    }
}