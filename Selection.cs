using System;
using Spectre.Console;
using System.Text;


class Selection
{
    public static bool Options()
    {
        ConsoleKeyInfo key;
        do {
            key = Console.ReadKey(); //vemos si desea jugar o salir
            if (key.Key == ConsoleKey.D1)
            {
                return true;
            } 
            else if (key.Key == ConsoleKey.D2)
            {
                return false;
            } else {
                AnsiConsole.MarkupLine(" [bold italic red]: Tecla incorrecta[/]");
            }
            
        } while(true);
               
    }
    public static void Decide(ref bool[] selected, piece[] pieces, int i) /// pasar fichas x ref?
    {
        ConsoleKeyInfo key;
        do {
                key = Console.ReadKey(); //vemos si escoge slime valido
                if (key.Key == ConsoleKey.D1)
                {
                    if (selected[0] == false) 
                    {
                        selected[0] = true;
                        pieces[0].player = (i%2);
                        pieces[0].id = 1;
                        break;
                    } 
                    else {
                        AnsiConsole.MarkupLine(" [bold italic red]Este Slime ya fue seleccionado[/]");
                    }
                }
                if (key.Key == ConsoleKey.D2)
                {
                    if (selected[1] == false) 
                    {
                        selected[1] = true;
                        pieces[1].player = (i%2);
                        pieces[1].id = 2;
                        break;
                    } 
                    else {
                       AnsiConsole.MarkupLine(" [bold italic red]Este Slime ya fue seleccionado[/]");
                    }
                }
                if (key.Key == ConsoleKey.D3)
                {
                    if (selected[2] == false) 
                    {
                        selected[2] = true;
                        pieces[2].player = (i%2);
                        pieces[2].id = 3;
                        break;
                    } 
                    else {
                        
                        AnsiConsole.MarkupLine(" [bold italic red]Este Slime ya fue seleccionado[/]");
                    }
                }
                if (key.Key == ConsoleKey.D4)
                {
                    if (selected[3] == false) 
                    {
                        selected[3] = true;
                        pieces[3].player = (i%2);
                        pieces[3].id = 4;
                        break;
                    } 
                    else {
                        AnsiConsole.MarkupLine(" [bold italic red]Este Slime ya fue seleccionado[/]");
                    }
                }
                if (key.Key == ConsoleKey.D5)
                {
                    if (selected[4] == false) 
                    {
                        selected[4] = true;
                        pieces[4].player = (i%2);
                        pieces[4].id = 5;
                        break;
                    } 
                    else {
                        AnsiConsole.MarkupLine(" [bold italic red]Este Slime ya fue seleccionado[/]");
                    }
                }
                if (key.Key == ConsoleKey.D6)
                {
                    if (selected[5] == false)
                    {
                        selected[5] = true;
                        pieces[5].player = (i%2);
                        pieces[5].id = 6;

                        break;
                    } 
                    else {
                        AnsiConsole.MarkupLine(" [bold italic red]Este Slime ya fue seleccionado[/]");
                    }
                }


                } while(true);               
    }
    public static int Choose (bool[] visited) 
    {
        ///excepcion para cuando elige la ficha a mover
        do 
        {
            string number = Console.ReadLine();
            if (number == "1") 
            {
                if (visited[1]) return 1;
                AnsiConsole.MarkupLine("[bold italic red]Tecla incorrecta[/]");
                
            } else if (number == "2")
            {
                if (visited[2]) return 2;
                AnsiConsole.MarkupLine("[bold italic red]Tecla incorrecta[/]");
            } else if (number == "3")
            {
                if (visited[3]) return 3;
                AnsiConsole.MarkupLine("[bold italic red]Tecla incorrecta[/]");
            } else if (number == "4")
            {
                if (visited[4]) return 4;
                AnsiConsole.MarkupLine("[bold italic red]Tecla incorrecta[/]");
            } else if (number == "5")
            {
                if (visited[5]) return 5;
                AnsiConsole.MarkupLine("[bold italic red]Tecla incorrecta[/]");
            } else if (number == "6")
            {
                if (visited[6]) return 6;
                AnsiConsole.MarkupLine("[bold italic red]Tecla incorrecta[/]");
    
            } else {
                AnsiConsole.MarkupLine("[bold italic red]Tecla incorrecta[/]");
            }
         
        }    while(true);
    }
}