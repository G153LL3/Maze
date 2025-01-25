using System;
using System.Text;
using Spectre.Console;
public static class Program
{
    
    public static int n = 20; //tamaño del lab
    static int[,] lab = new int[1000, 1000]; //lab de 1 y 0
    public static int[] pl_cnt = {2,2};
    static bool[,] vis = new bool[1000, 1000]; //verifica si una pos ya fue vis
    
    static char[,] laberinto = new char [1000, 1000]; //laberinto
    static ficha[] fichas = {
        new ficha("☺"),new ficha("☻"),new ficha("☻"),
        new ficha("☺"),new ficha("☺"),new ficha("☺")
    }; // 6 fichas

    ///habilidades
    const string skill1_txt = "duplica su velocidad";
    const string skill2_txt = "las trampas no le afectan";
    const string skill3_txt = "destruye las paredes del laberinto";
    const string skill4_txt = "regresa un slime del oponente al inicio";
    const string skill5_txt = "congela los slimes del oponente";
    const string skill6_txt = "impide que el rival use las habilidades de sus slimes";

    static int cant_fichas = 2; //cada jugador tiene 2 fichas

    static void MainMenu () // menu principal
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; //usar emojis
        
        fichas[0].name = "Fast Slime";
        fichas[0].speed = 15;
        fichas[0].Frozen_time = 2;
        fichas[0].skill_desc = skill1_txt;

        fichas[1].name = "Trap Slime";
        fichas[1].speed = 14;
        fichas[1].Frozen_time = 3;
        fichas[1].skill_desc = skill2_txt;

        fichas[2].name = "Strong Slime";
        fichas[2].speed = 10;
        fichas[2].Frozen_time = 1;
        fichas[2].skill_desc = skill3_txt;

        fichas[3].name = "Begin Slime";
        fichas[3].speed = 12;
        fichas[3].Frozen_time = 5;
        fichas[3].skill_desc = skill4_txt;

        fichas[4].name = "Frozen Slime";
        fichas[4].speed = 18;
        fichas[4].Frozen_time = 4;
        fichas[4].skill_desc = skill5_txt;

        fichas[5].name = "Skill Slime";
        fichas[5].speed = 22;
        fichas[5].Frozen_time = 2;
        fichas[5].skill_desc = skill6_txt;

        Introduction.Menu();        
    }
    static void MakeTable()
    {
        // Crear una tabla
        var table = new Table();

        // Definir las columnas de la tabla
       // Console.BackgroundColor = ConsoleColor.Blue;
        Console.ForegroundColor = ConsoleColor.Blue;


        table.AddColumn("ID");
        table.AddColumn("Nombre");
        table.AddColumn("Habilidad");
        table.AddColumn("Veclocidad");
        table.AddColumn("Tiempo de enfriamiento");

        // Agregar filas a la tabla
        table.AddRow("1", "Fast Slime", "duplica su velocidad", "15", "2");
        table.AddRow("2", "Tramp Slime", "las trampas no le afectan", "14", "3");
        table.AddRow("3", "Strong Slime", "destruye las paredes del laberinto", "10", "1");
        table.AddRow("4", "Begin SLime", "regresa un slime del oponente al inicio", "12", "5");
        table.AddRow("5", "Frozen Slime", "congela los slimes del oponente", "18", "4");
        table.AddRow("6", "SkillS Lime", "impide que el rival use las habilidades de sus slimes", "22", "2");

        // Mostrar la tabla en la consola
        AnsiConsole.Render(table);
    }

    static void Makelab () // hago el laberinto
    {
        for (int i = 0; i < 1000; i++)    
        {
            for (int j = 0; j < 1000; j++)
            {
                lab[i,j] = 1;
            }
        }
        lab[1, 1] = 0;
        Lab.dfs(n, 1, 1, ref vis, ref  lab);
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= n; j++) 
            {
                if (i == 0 && j == 1 || i == n && j == n-1) 
                {
                    laberinto[i,j] = ' ';
                } 
                else 
                {
                    if (lab[i, j] == 0) 
                    {
                        laberinto[i, j] = ' ';
                    } 
                    else {
                        laberinto[i, j] = '█'; 
                    }
                }
            }   
        }
    }
    
    public static int Main()
    {
        ConsoleKeyInfo key;
        MainMenu(); // inicio
        bool  follow = Selection.Options(); //vemos si desea jugar o salir
        if (!follow) return 0;
        
        Introduction.Begin(); //introduccion al juego
        bool []selected = {false, false, false, false, false, false};
        
        for (int i = 0; i < 4; i++) //escogen sus fichas
        {
            Console.Clear();
            AnsiConsole.MarkupLine("[bold italic blue]Seleccione los slimes que desea ayudar[/]");
            Console.WriteLine();
            MakeTable(); //muestro fichas para que el jugador elija en forma de tabla
            int num_player = (i%2+1);
            if (num_player == 1) {
                AnsiConsole.MarkupLine("[bold italic blue]Jugador 1 seleccione un slime:[/] ");
            } else {
                AnsiConsole.MarkupLine("[bold italic blue]Jugador 2 seleccione un slime:[/] ");
            }
            
            Selection.Decide(ref selected, fichas, i); //ver que fichas decide coger
            
        }
        for (int i = 0; i < 6; i++) //iteramos por todas las fichas y vemos que ficha es de que jugador
        { 
            fichas[i].init(); //ver funcion
            if (selected[i] == false)
                fichas[i] = null;
        }
        
        Makelab(); // se hace el lab for
        Trampas.Trampa1(ref laberinto, n); //trampas
        Trampas.Trampa2(ref laberinto, n); //trampas
        Trampas.Trampa3(ref laberinto, n); //trampas

        Teletransportador.Tele(ref laberinto, n); //teletranportadores 
        StringBuilder buffer = new StringBuilder(); //evitar pantallazos

        int last_operation = 0, turn = 1, Player = -1;
        int  all_no_skill = 0;
        while (true)
        {
            
            for (int tt = 0;; tt++)
            {        
                Player+=1;  
                Player%=2;
                Console.Clear();    
                buffer.Clear();
                Mostrar.MostrarLaberinto(buffer, n, turn, ref fichas, ref laberinto);
                
                AnsiConsole.Write(buffer.ToString()); //mostramos lab
                Console.WriteLine();
                if (turn == 1) 
                {
                    AnsiConsole.MarkupLine("[bold italic blue]Es el turno del jugador 1[/]");
                } else {
                    AnsiConsole.MarkupLine("[bold italic blue]Es el turno del jugador 2[/]");
                }
                
                AnsiConsole.MarkupLine("[bold italic blue]Seleccione el slime que desea usar[/]");
                if (1+Player == 1)
                {
                   AnsiConsole.MarkupLine("[bold italic blue]Jugador 1 tus slimes:[/]");
                } else {
                   AnsiConsole.MarkupLine("[bold italic blue]Jugador 2 tus slimes:[/]");
                }
                

                for (int i = 0; i < fichas.Length; i++)
                {
                    if (fichas[i] == null || fichas[i].player != Player) continue;
                    // buffer.AppendLine(fichas[i].name+" "+fichas[i].id);
                    //Console.WriteLine(fichas[i].id + " " +fichas[i].name);
                    Mostrar.ShowSlimes(fichas[i].id);


                }
                buffer.Clear();
                int ttt = int.Parse(Console.ReadLine());

                ficha fic = null;
                int fi_pos = 0;
                for (int i = 0; i < fichas.Length; i++)
                {
                    if (fichas[i] == null) continue;
                    if (fichas[i].id == ttt)
                    {
                        fic = fichas[i];
                        fi_pos = i;
                    }
                }
                
                string ky = "NO";
                if (fic.act_time <= 0 && all_no_skill == 0)
                {
                    //buffer.AppendLine("Ecriba yes si desea usar la habilidad de este slime en este turno y no en caso contario");7
                   //AnsiConsole.Write(buffer.ToString());
                    //buffer.Clear();
                    //Console.WriteLine();
                    AnsiConsole.MarkupLine("[bold italic blue]Escriba[/]" + "[bold italic red] SI [/]" + "[bold italic blue]si desea usar la habilidad de este slime en este turno y [/]" + " [bold italic red]NO[/] " + "[bold italic blue]en caso contario[/]");
                    
                    ky = Console.ReadLine();
                }
                if (all_no_skill == 1) all_no_skill = 0;
                bool frst = true;
                int op = 0, res = fic.speed;
                for (int vel = 0; vel < res; vel ++)
                {
                    if (frst)
                    if (ky == "SI")
                    {
                        frst = false;
                        fic.act_time = fic.Frozen_time+1;
                        fic.skill(ref all_no_skill,ref op,ref vel,ref fichas);
                    }
                    buffer.Clear();
                    
                    Mostrar.MostrarLaberinto(buffer, n,turn, ref fichas, ref laberinto);

                    buffer.Append("Movimientos restantes: ");
                    //AnsiConsole.MarkupLine("[bold italic red]Movimientoa restantes[/]");
                    buffer.Append((res - vel));
                    buffer.AppendLine();

                    if (last_operation != 0) last_operation = 0;
                    Console.Clear();
                    AnsiConsole.Write(buffer.ToString());
                    if (fic.posX == fic.FinX && fic.posY == fic.FinY) 
                    {
                        pl_cnt[fic.player]--;
                        if (pl_cnt[fic.player] == 0)
                        {
                            Console.WriteLine();
                            if (Player+1 == 1)
                            {
                                AnsiConsole.MarkupLine("[bold italic green]HA GANADO EL JUGADOR 1[/]");
                            } else {
                                AnsiConsole.MarkupLine("[bold italic green]HA GANADO EL JUGADOR 2[/]");
                            }
                            
                            return 0;
                        }
                      
                        fic = null;
                        break;
                    }       
                     
                    ConsoleKeyInfo tecla = Console.ReadKey(true);
                    if (tecla.Key == ConsoleKey.UpArrow)
                        fic.MoverFicha(-1, 0, n, ref laberinto, ref last_operation);
                    else if (tecla.Key == ConsoleKey.DownArrow)
                        fic.MoverFicha(1, 0, n, ref laberinto, ref last_operation);
                    else if (tecla.Key == ConsoleKey.LeftArrow)
                        fic.MoverFicha(0, -1, n, ref laberinto, ref last_operation );
                    else if (tecla.Key == ConsoleKey.RightArrow)
                        fic.MoverFicha(0, 1, n, ref laberinto, ref last_operation);
                    if(last_operation < 4)
                    {
                        vel--;
                    }
                    else 
                    {
                        last_operation ^= 4;
                    }
                    buffer.Clear();
                    if (last_operation == 1)
                    {
                        Console.Clear();
                        Mostrar.MostrarLaberinto(buffer, n, turn, ref fichas, ref laberinto);
                        Console.WriteLine();
                        buffer.Append("Haz caído en una trampa :( ");
                        buffer.AppendLine();
                        AnsiConsole.Write(buffer.ToString());
                        Console.ReadKey();
                    } 
                    else if (last_operation == 2)
                    {
                        Console.Clear();
                        Mostrar.MostrarLaberinto(buffer, n, turn, ref fichas, ref laberinto);
                        Console.WriteLine();
                        buffer.Append("Te haz teletransportado a la salida :)");
                        buffer.AppendLine();
                        AnsiConsole.Write(buffer.ToString());
                        Console.ReadKey();
                        //Console.Clear();
                        
                    }
                    if (fic.brk == 1)
                    {
                        fic.brk = 0;
                        break;
                    }
                }
                Player += op;
                if (fic != null)
                {
                    fic.strong = 0;
                    fic.t_affect = 1;
                    fic.act_time-=1;
                }
                fichas[fi_pos] = fic;
                if (op == 0)
                    if (turn == 1) turn = 2;
                    else turn = 1;
                
            }
       }     
       return 0;        
    }
}
