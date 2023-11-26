using Microsoft.VisualBasic;

public class Aritmenticos{

    public static void Aplicar(ref WebApplication app){

    var TagNamee = "Aritmenticos";

    app.MapPost("/suma", Suma)
    .Produces<ServerResult>().WithTags(TagNamee)
    .WithDescription("Realiza la suma de dos numeros enteros");

    app.MapPost("/promedio" , Promedio)
    .Produces<ServerResult>().WithTags(TagNamee)
    .WithDescription("Realiza el promedio de dos numeros enteros");
    
    }

    public static ServerResult Promedio(int a, int b){
        var resultado = new ServerResult();
        resultado.Resultado = (a + b)/2;
        resultado.Mensaje = "Suma realizada con exito";
        return resultado;
    }

    public static ServerResult Suma(int a, int b){
        var resultado = new ServerResult();
        resultado.Resultado = a + b;
        resultado.Mensaje = "Suma realizada con exito";
        return resultado;
    }

}