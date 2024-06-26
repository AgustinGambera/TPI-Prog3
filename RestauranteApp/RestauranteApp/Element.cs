using System;
using System.Drawing;

namespace RestauranteApp
{
    public class Element
    {
        public Guid Id { get; set; }
        public string ImagePath { get; set; } // Usamos la ruta de la imagen en lugar de un Bitmap.
        public Point Position { get; set; }
        public Size Size { get; set; } // Nueva propiedad para el tamaño

        // Constructor para inicializar con un Id generado automáticamente
        public Element()
        {
            Id = Guid.NewGuid();
        }
    }

    public class Cliente : Element //pase estas clases desde Reserva.cs
    {

    }

    // Clases de dominio Mozo
    public class Mozo : Element
    {

    }

    // Clases de dominio Mesa
    public class Mesa : Element
    {

    }
}
