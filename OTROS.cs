using Microsoft.VisualBasic;

public class Otros{

    public static void Aplicar(ref WebApplication app){

    var TagNamee = "Otros";

    app.MapGet("/Ecuacion de segundo grado", Ecuacion).Produces<ServerResult>().WithTags(TagNamee)
    .WithDescription("Encuentra la Solucion de x1 y x2");

    app.MapGet("/Frase" , Frase)
    .Produces<ServerResult>().WithTags(TagNamee)
    .WithDescription("Contar la cantidad de caracteres que escriba");
    
    app.MapGet("/Viajes" , Viajes)
    .Produces<ServerResult>().WithTags(TagNamee)
    .WithDescription("Realiza la cantidad de viajes que se puede realizar en el ITLA");

    app.MapGet("/MB, GB, TB" , Capacidad)
    .Produces<ServerResult>().WithTags(TagNamee)
    .WithDescription("Decir la cantidad de Gigabytes y Terabytes dependiendo los Megabytes.");

    app.MapGet("/Cambio de pesos a dolares" , Cambio)
    .Produces<ServerResult>().WithTags(TagNamee)
    .WithDescription("Realiza el promedio de dos numeros enteros");

    app.MapGet("/Acerca de" , Acerca)
    .Produces<ServerResult>().WithTags(TagNamee)
    .WithDescription("Realiza el promedio de dos numeros enteros");


    }

    public static ServerResult Ecuacion(int ax, int bx, int c){
        double x1 = (-bx + Math.Sqrt(Math.Pow(bx, 2) - 4 * (ax*c))) / 2 * ax;
        double x2 = (-bx - Math.Sqrt(Math.Pow(bx, 2) - 4 * (ax*c))) / 2 * ax;
        var resultado = new ServerResult();
        resultado.Resultado = $"La solucion de x1 es: {x1}" + " y la solucion de x2 es: " + x2;
        resultado.Mensaje = "soluciones de X1 y X2 encontrada con exito";
        return resultado;
    }

    public static ServerResult Frase(string frase){
        var resultado = new ServerResult();
        resultado.Resultado = "Segun lo que escribiste tiene una cantidad de " + frase.Length +" caracteres.";
        resultado.Mensaje = "Realizado con exito";
        return resultado;
    }

    public static ServerResult Viajes(int viaje){
        var resultado = new ServerResult();
        resultado.Resultado = "La cantidad de viajes que puedes realizar al itla son: " + viaje/50;
        resultado.Mensaje = "Area encontrada con exito";
        return resultado;
    }

    public static ServerResult Capacidad(int MB){
        var resultado = new ServerResult();
        resultado.Resultado = "La cantidad de Gigabytes de esos Megabytes son: " + MB / 1024 + ". La cantidad de Terabytes de esos Megabytes son: " + MB / 1048576;
        resultado.Mensaje = "Cantidad encontrada con exito";
        return resultado;
    }

    public static ServerResult Cambio(int pesos, decimal dolar){
        decimal EEUU = pesos/dolar;
        var resultado = new ServerResult();
        resultado.Resultado = "La cantidad de dolares que tiene son: " + Math.Round(EEUU, 2);
        resultado.Mensaje = "Cambio de monedas realizado con exito";
        return resultado;
    }

    public static Persona Acerca(){
        var info = new Persona();
        info.Foto = "https://itlaedudo-my.sharepoint.com/:i:/g/personal/20221003_itla_edu_do/EQV4VNnT2atEt0INlKcIQZ4B26mkwYglq7Z5qTzuohZVYw?e=CiDn84";
        info.Nombre = "Pablo Elias";
        info.Apellido = "Basilio de Jesus";
        info.Aplicacion = "Tarea 5";
        info.Correo = "Pabloeliasbasiliodejesus@gmail.com";
        info.Telegram = "https://t.me/Eliaspablo";
        return info;
    }

}