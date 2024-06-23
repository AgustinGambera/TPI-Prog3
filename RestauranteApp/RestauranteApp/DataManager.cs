using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteApp
{
    public class DataManager
    {
        public static void SaveToFile(string filePath, List<Element> elements)
        {
            // Lógica para guardar en JSON/XML
        }

        public static List<Element> LoadFromFile(string filePath)
        {
            // Lógica para cargar desde JSON/XML
            return new List<Element>();
        }
    }
}