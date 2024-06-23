using System;
using System.Drawing;

namespace RestauranteApp
{
    public class Element
    {
        public Guid Id { get; set; }
        public Point Position { get; set; }
        public Image ImageLocation { get; set; } // Propiedad para almacenar la imagen

        // Constructor para inicializar con un Id generado automáticamente
        public Element()
        {
            Id = Guid.NewGuid();
        }
    }
}
