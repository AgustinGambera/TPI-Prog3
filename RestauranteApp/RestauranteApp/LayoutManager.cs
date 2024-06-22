using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;

namespace RestauranteApp
{
    public class LayoutManager
    {
        private List<Element> elementos;

        public LayoutManager()
        {
            elementos = new List<Element>();
        }

        public void AgregarElemento(Element elemento)
        {
            elementos.Add(elemento);
        }

        public void EliminarElemento(Element elemento)
        {
            elementos.Remove(elemento);
        }

        public List<Element> ObtenerElementos()
        {
            return elementos;
        }

        public void ActualizarPosicion(Element elemento, Point nuevaPosicion)
        {
            var elem = elementos.FirstOrDefault(e => e.Id == elemento.Id);
            if (elem != null)
            {
                elem.Position = nuevaPosicion;
            }
        }

        public void GuardarLayout(string filePath)
        {
            //implementar logica 
            /*var json = JsonConvert.SerializeObject(elementos, Formatting.Indented);
            File.WriteAllText(filePath, json);*/
        }

        public void CargarLayout(string filePath)
        {
            if (File.Exists(filePath))
            {
                //implementar logica 
                /*var json = File.ReadAllText(filePath);
                elementos = JsonConvert.DeserializeObject<List<Elemento>>(json);*/
            }
        }
    }