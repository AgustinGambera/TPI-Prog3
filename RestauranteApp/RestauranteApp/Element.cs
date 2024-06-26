using System;
using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RestauranteApp
{
    public class Element
    {
        public Guid Id { get; set; }
        public string ImagePath { get; set; } // Usamos la ruta de la imagen en lugar de un Bitmap.
        public Point Position { get; set; }
        public Size Size { get; set; } // Nueva propiedad para el tamaño
        [JsonConverter(typeof(ColorJsonConverter))]
        public Color BackColor { get; set; }
        public string Estado { get; set; } // Nuevo campo para el estado
        public string MozoEncargado { get; set; } // Nuevo campo para el mozo encargado
        public string Cliente { get; set; } // Nuevo campo para el cliente
        public string Permanencia { get; set; } // Nuevo campo para la permanencia
        public string Consumos { get; set; } // Nuevo campo para los consumos

        // Constructor para inicializar con un Id generado automáticamente
        public Element()
        {
            Id = Guid.NewGuid();
        }
    }

    public class ColorJsonConverter : JsonConverter<Color>
    {
        public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            reader.Read(); // StartObject
            reader.Read(); // PropertyName "R"
            int r = reader.GetInt32();
            reader.Read(); // PropertyName "G"
            reader.Read(); // Value of G
            int g = reader.GetInt32();
            reader.Read(); // PropertyName "B"
            reader.Read(); // Value of B
            int b = reader.GetInt32();
            reader.Read(); // PropertyName "A"
            reader.Read(); // Value of A
            int a = reader.GetInt32();
            reader.Read(); // EndObject
            return Color.FromArgb(a, r, g, b);
        }

        public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteNumber("R", value.R);
            writer.WriteNumber("G", value.G);
            writer.WriteNumber("B", value.B);
            writer.WriteNumber("A", value.A);
            writer.WriteEndObject();
        }
    }
}
