using System;
using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;

public class SizeConverter : JsonConverter<Size>
{
    public override Size Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        var parts = value.Split(',');
        return new Size(int.Parse(parts[0]), int.Parse(parts[1]));
    }

    public override void Write(Utf8JsonWriter writer, Size value, JsonSerializerOptions options)
    {
        writer.WriteStringValue($"{value.Width},{value.Height}");
    }
}
