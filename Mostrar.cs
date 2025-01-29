using System;
using System.Text;
using Spectre.Console;
public static class Mostrar
{  
   public static void MostrarLaberinto(StringBuilder buffer, int n, int turno,ref ficha[] fichas, ref string[,] laberinto)
    {
        int parche= 0; // esto es para cuando se teletransporta o cae en trampa y el finalo inicio esta lleno
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= n; j++)
            {
                int cnt = 0;
                for (int k = 0; k < fichas.Length; k++)
                {
                    if (fichas[k] == null) continue;
                    if (i == fichas[k].posX && j == fichas[k].posY) 
                    {
                        cnt++;
                    }
                }
                
                for (int k = 0; k < fichas.Length; k++)
                {
                    if (fichas[k] == null) continue;
                    if (i == fichas[k].posX && j == fichas[k].posY) // verifica si en I,J hay una ficha
                    {
                        buffer.Append(fichas[k].ico);
                        //string palabra = fichas[k].ico;
                        //var x = new Markup($"[blue]{palabra}[/]");
                        //buffer.Append(x);
                        

                        
                        if(cnt < 2) //si no hay 2 fichas juntas ponme un espacio en su lugar
                        {
                            buffer.Append(" ");
                           // buffer.Append(" ");
                            //buffer.Append(" ");
                            //buffer.Append(" ");
                        }
                        
                    }
                }
                if (cnt == 3)
                {
                    parche = 1;
                }
                
                
                if (cnt == 0) // verifica si en I,J hay una ficha
                {
                    if (parche != 1) 
                    {
                        
                    
                    buffer.Append(laberinto[i, j]);

                    if (laberinto[i,j] == "█" || laberinto[i,j] == " ")
                    {
                        buffer.Append(laberinto[i, j]);
                       
                    }
                    else {
                       // buffer.Append(" ");
                    }
                    } else {
                        if (i == 0 && j ==2) 
                        {
                            buffer.Append(" ");
                        }
                        parche = 0;
                    }
                }  
                
            }
            buffer.AppendLine();
         
        }
        
    }
    public static void ShowSlimes(int id)
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
