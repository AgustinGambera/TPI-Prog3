using RestauranteApp;
using System.Text.Json;
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
        var elementoExistente = elementos.FirstOrDefault(el => el.Id == elemento.Id);
        if (elementoExistente != null)
        {
            elementoExistente.Position = nuevaPosicion;
        }
    }

    public void GuardarLayout(string filePath)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters = { new ColorJsonConverter() }
        };
        string jsonString = JsonSerializer.Serialize(elementos, options);
        File.WriteAllText(filePath, jsonString);

    }

    public void CargarLayout(string filePath)
    {
        var options = new JsonSerializerOptions
        {
            Converters = { new ColorJsonConverter() }
        };
        string jsonString = File.ReadAllText(filePath);
        elementos = JsonSerializer.Deserialize<List<Element>>(jsonString, options);
    }
}
