using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteApp
{
    internal class Reserva
    {
        public int Id { get; set; }
        public Mesa ReservedTable { get; set; }
        public DateTime ReservationTime { get; set; }
        public Cliente Customer { get; set; }
        public Mozo Waiter { get; set; }
    }
}
// Clases de dominio Cliente
public class Cliente
    {
   
    }

// Clases de dominio Mozo
public class Mozo
    {
       
    }

// Clases de dominio Mesa
public class Mesa
{

}


