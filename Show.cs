using System;
using System.Text;
using Spectre.Console;

public static class Show
{  
   public static void Maze (StringBuilder buffer, int n, int turn, ref piece[] pieces, ref string[,] maze)
    {
        int pos_full = 0; // esto es para cuando se teletransporta o cae en trampa y el final o el inicio esta lleno
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= n; j++)
            {
                int cnt = 0; ///cuenta la catidad de pieces
                for (int k = 0; k < pieces.Length; k++)
                {
                    if (pieces[k] == null) continue;
                    if (i == pieces[k].posX && j == pieces[k].posY) 
                    {
                        cnt++;
                    }
                }
                
                for (int k = 0; k < pieces.Length; k++)
                {
                    if (pieces[k] == null) continue;
                    
                    if (i == pieces[k].posX && j == pieces[k].posY) // verifica si en i,j hay una ficha
                    {
                        
                        ///agrego pieces al buffer segun su color
                        if (pieces[k].id == 1) 
                        {
                            buffer.Append($"[cyan]{pieces[k].ico}[/]");
                        } else if (pieces[k].id == 2)
                        {
                            buffer.Append($"[yellow]{pieces[k].ico}[/]");
                        } else if (pieces[k].id == 3)
                        {
                            buffer.Append($"[green]{pieces[k].ico}[/]");

                        } else if (pieces[k].id == 4)
                        {
                            buffer.Append($"[hotpink]{pieces[k].ico}[/]");

                        } else if (pieces[k].id == 5)
                        {
                            buffer.Append($"[blue]{pieces[k].ico}[/]");

                        } else {
                           buffer.Append($"[red]{pieces[k].ico}[/]");
                        }
                        
                        if (cnt < 2) //si hay pieces ponme un espacio en el buffer
                        {
                            buffer.Append(" ");
                        }
                        
                    }
                }
                if (cnt == 3)
                {
                    pos_full = 1; ///hay 3 pieces
                }
                
                
                if (cnt == 0) // no hay pieces
                {
                    if (pos_full != 1) 
                    {
                        buffer.Append(maze[i, j]);

                        if (maze[i,j] == "█" || maze[i,j] == " ")
                        {
                            buffer.Append(maze[i, j]);      
                        }
                    } else {
                        if (i == 0 && j == 2) 
                        {
                            buffer.Append(" ");
                        }
                        pos_full = 0;
                    }
                }  
                
            }
            buffer.AppendLine();        
        }
    }
    public static void Slimes(int id)
    {
        if (id == 1)
        {
            AnsiConsole.MarkupLine("[bold italic cyan]1 Fast SLime[/]");
        } else if (id == 2)
        {
            AnsiConsole.MarkupLine("[bold italic yellow]2 Trap SLime[/]");
        } else if (id == 3)
        {
            AnsiConsole.MarkupLine("[bold italic green]3 Strong SLime[/]");
        } else if (id == 4)
        {
            AnsiConsole.MarkupLine("[bold italic hotpink]4 BeginSLime[/]");
        } else if (id == 5)
        {
            AnsiConsole.MarkupLine("[bold italic blue]5 Frozen SLime[/]");
        } else if (id == 6)
        {
            AnsiConsole.MarkupLine("[bold italic red]6 Skill SLime[/]");
            
        }
    }
}
