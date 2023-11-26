using Microsoft.VisualBasic;

public class Trigonometricos{

    public static void Aplicar(ref WebApplication app){

    var TagNamee = "Trigonometricos";

    app.MapGet("/Hipotenusa", Hipotenusa).Produces<ServerResult>().WithTags(TagNamee)
    .WithDescription("Encuentra la hipotenusa de un triangulo rectagulo");

    app.MapGet("/Cateto" , Cateto)
    .Produces<ServerResult>().WithTags(TagNamee)
    .WithDescription("Encuentra el cateto de un triangulo rectagulo");
    
    app.MapGet("/Area" , Area)
    .Produces<ServerResult>().WithTags(TagNamee)
    .WithDescription("Realiza el promedio de dos numeros enteros");

    }

    public static ServerResult Hipotenusa(int cateto1, int cateto2){
        var resultado = new ServerResult();
        resultado.Resultado = Math.Sqrt(Math.Pow(cateto1,2) + Math.Pow(cateto2,2));
        resultado.Mensaje = "Hipotenusa encontrada con exito";
        return resultado;
    }

    public static ServerResult Cateto(int hipotenusa, int cateto){
        var resultado = new ServerResult();
        resultado.Resultado = Math.Sqrt(Math.Pow(hipotenusa,2) - Math.Pow(cateto,2));
        resultado.Mensaje = "Cateto encontrada con exito";
        return resultado;
    }

    public static ServerResult Area(int altura, int Base){
        var resultado = new ServerResult();
        resultado.Resultado = (altura * Base)/2;
        resultado.Mensaje = "Area encontrada con exito";
        return resultado;
    }

}