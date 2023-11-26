using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.IO;


public class Dealer{

    public static List<Vehiculo> ListaVehiculos;

    private static readonly string jsonFilePath = "vehiculos.json";
    public static void CargarVehiculos()
    {
        if (File.Exists(jsonFilePath))
        {
            string json = File.ReadAllText(jsonFilePath);
            ListaVehiculos = JsonConvert.DeserializeObject<List<Vehiculo>>(json);
        }
        else
        {
            ListaVehiculos = new List<Vehiculo>();
        }
    }
    public static void GuardarVehiculos()
    {
        string json = JsonConvert.SerializeObject(ListaVehiculos);
        File.WriteAllText(jsonFilePath, json);
    }


    public static void Aplicar(ref WebApplication app){

    var TagNamee = "Crud";

    app.MapPost("/crub/agregar", Agregar).
    Produces<ServerResult>().WithTags(TagNamee)
    .WithDescription("Agregar un vehiculo a la lista");

     app.MapGet("/crub/listar", Listar)
    .Produces<ServerResult>().WithTags(TagNamee)
    .WithDescription("Lista los vehiculos agregados");

     app.MapPut("/crub/Modificar", Modificar)
    .Produces<ServerResult>().WithTags(TagNamee)
    .WithDescription("modifica un vehiculo de la lista");

     app.MapDelete("/crub/Eliminar", Eliminar)
    .Produces<ServerResult>().WithTags(TagNamee)
    .WithDescription("Elimina un vehiculo de la lista");

    CargarVehiculos();
    }

   

    public static ServerResult Agregar(Vehiculo vehiculo){
        var resultado = new ServerResult();
        var vehiculoencontrado = ListaVehiculos.Find(v => v.Codigo == vehiculo.Codigo);
        if(vehiculoencontrado != null){
        resultado.Exito = false;
        resultado.Mensaje = "Vehiculo ya existe con exito";
        return resultado;
        }

        ListaVehiculos.Add(vehiculo);
        resultado.Resultado = vehiculo;
        GuardarVehiculos();
        resultado.Mensaje = "Vehiculo Agregado con exito";
        return resultado;
    }

    public static ServerResult Listar(){
        var resultado = new ServerResult();
        resultado.Resultado = ListaVehiculos;
        CargarVehiculos();
        resultado.Mensaje = "Vehiculo Listados con exito";
        return resultado;
    }

    public static ServerResult Modificar(Vehiculo vehiculo){
        var resultado = new ServerResult();
        var vehiculoencontrado = ListaVehiculos.Find(v => v.Codigo == vehiculo.Codigo);
        if(vehiculoencontrado != null){
            vehiculoencontrado.Marca = vehiculo.Marca;
            vehiculoencontrado.Modelo = vehiculo.Modelo;
            vehiculoencontrado.Color = vehiculo.Color;
            vehiculoencontrado.Anio = vehiculo.Anio;
            vehiculoencontrado.Costo = vehiculo.Costo;
            resultado.Resultado = vehiculoencontrado;
            GuardarVehiculos();
            resultado.Mensaje = "Vehiculo modificado con exito";
        }else{
            resultado.Exito = false;
            resultado.Mensaje = "Vehiculo no encontrado";
        }
        return resultado;
    }

    public static ServerResult Eliminar(string codigo){
        var resultado = new ServerResult();
        var vehiculoencontrado = ListaVehiculos.Find(v => v.Codigo == codigo);
        if(vehiculoencontrado != null){
            ListaVehiculos.Remove(vehiculoencontrado);
            resultado.Resultado = vehiculoencontrado;
            GuardarVehiculos();
            resultado.Mensaje = "Vehiculo Eliminado con exito";
        }else{
            resultado.Exito = false;
            resultado.Mensaje = "Vehiculo no encontrado";
        }
        return resultado;
    }

}

public class Vehiculo{
    public string Codigo {get; set;} = "";
    public string Marca {get; set;} = "";
    public string Modelo {get; set;} = "";
    public string Color {get; set;} = "";
    public int Anio {get; set;} = 0;
    public int Costo {get; set;} = 0;
}