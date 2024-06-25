using RestauranteApp;
using System.Xml.Serialization;

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
        XmlSerializer serializer = new XmlSerializer(typeof(List<Element>));
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            serializer.Serialize(writer, elementos);
        }
    }

    public void CargarLayout(string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Element>));
        using (StreamReader reader = new StreamReader(filePath))
        {
            elementos = (List<Element>)serializer.Deserialize(reader);
        }
    }
}
