using RestauranteApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RestauranteApp
{
    public abstract class Element
    {
        private Size size;
        private string name;

        protected Element(int id, Point position, Size size, string name)
        {
            Id = id;
            Position = position;
            this.size = size;
            this.name = name;
        }

        public int Id { get; set; }
        public Point Position { get; set; }

        public abstract void Draw(Graphics g); //DE EJEMPLO XD
    }
}

// Clase Mesa que hereda de Elemento
public class Mesa : Element
{
    public int NumeroSillas { get; set; }

    public Mesa(int id, Point position, Size size, string name, int numeroSillas)
        : base(id, position, size, name)
    {
        NumeroSillas = numeroSillas;
    }

    public override void Draw(Graphics g)
    {
        throw new NotImplementedException();
    }
}

// Clase Silla que hereda de Elemento
public class Silla : Element
{
    public bool Ocupada { get; set; }

    public Silla(int id, Point position, Size size, string name, bool ocupada)
        : base(id, position, size, name)
    {
        Ocupada = ocupada;
    }

    public override void Draw(Graphics g)
    {
        throw new NotImplementedException();
    }
}

public class Divider : Element
{
    public Divider(int id, Point position, Size size, string name) : base(id, position, size, name)
    {
    }

    public override void Draw(Graphics g)
    {
        // Lógica para dibujar un divisor
    }
}

public class Wall : Element
{
    public Wall(int id, Point position, Size size, string name) : base(id, position, size, name)
    {
    }

    public override void Draw(Graphics g)
    {
        // Lógica para dibujar una pared
    }
}