using System;
using Spectre.Console;


public static class Introduction
{
    public static void Menu()
    {
        Console.Clear();
        Console.WriteLine(" ");
        var title = "SLIMES IN MAZE";
        var bigText = new FigletText(title)
            .Color(Color.Blue);    
        AnsiConsole.Render(bigText);

        
        AnsiConsole.MarkupLine("[bold magenta]Presiona cualquier tecla para continuar[/]");
        Console.ReadKey();
        Console.Clear();
        AnsiConsole.MarkupLine("[bold italic blue]OPCIONES:[/]");
        AnsiConsole.MarkupLine("[bold italic magenta]1-Jugar[/]");
        AnsiConsole.MarkupLine("[bold italic magenta]2-Salir[/]");
    }
    public static void Begin()
    {
        Console.Clear();
        var panel_1 = new Panel("[bold italic blue]Beatrix ha vuelto a perder sus slimes, estos escaparon[/]"
           + "\n" + "[bold italic blue]del rancho y ahora se encuentran  atrapados  en   un[/]" 
           + "\n" + "[bold italic blue]laberinto en la lejana pradera. Para  recuperarlos[/]"
           + "\n" + "[bold italic blue]Beatrix necesita de ayuda. Deberá guiar sus[/]"
           + "\n" + "[bold italic blue]slimes hasta la salida del laberinto. Veamos que[/]"
           + "\n" + "[bold italic blue]jugador lo  logra primero.[/]")
        {
            Border = BoxBorder.Rounded, 
            Padding = new Padding(1,1,1,1),
            BorderStyle = new Style(Color.Blue) 
        };
        AnsiConsole.Write(panel_1); 

        Console.WriteLine(" ");
        AnsiConsole.MarkupLine("[bold italic magenta]Presione cualquier tecla para continuar[/]");
        Console.ReadKey();
        Console.Clear();
        
        var panel_2 = new Panel("[bold italic blue]Solo puede ayudar a 2 slimes a salir del laberinto, a[/]"
           + "\n" + "[bold italic blue]continuación deberá seleccionar que slimes desea ayudar,[/]" 
           + "\n" + "[bold italic blue]para ello tenga en cuenta que Beatrix ha estado haciendo[/]"
           + "\n" + "[bold italic blue]experimentos con los slimes y cada uno ha desarrollado una[/]"
           + "\n" + "[bold italic blue]habilidad única que le podría facilitar el recorrido,[/]"
           + "\n" + "[bold italic blue]también podría encontrarse con puertas slime que lo[/]"
           + "\n" + "[bold italic blue]lleven a la salida y tenga cuidado con las trampas, la lejana[/]"
           + "\n" + "[bold italic blue]pradera es un lugar peligroso.[/]")
        {
            Border = BoxBorder.Rounded, 
            Padding = new Padding(1,1,1,1),
            BorderStyle= new Style(Color.Blue) 
        };
         AnsiConsole.Write(panel_2); 

        Console.WriteLine(" ");
        AnsiConsole.MarkupLine("[bold magenta]Presione cualquier tecla para continuar[/]");
        Console.ReadKey();
    }
}