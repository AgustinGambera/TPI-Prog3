using System;
using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;

public class PointConverter : JsonConverter<Point>
{
    public override Point Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        var parts = value.Split(',');
        return new Point(int.Parse(parts[0]), int.Parse(parts[1]));
    }

    public override void Write(Utf8JsonWriter writer, Point value, JsonSerializerOptions options)
    {
        writer.WriteStringValue($"{value.X},{value.Y}");
    }
}
