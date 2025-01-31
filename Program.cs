using System;
using NAudio.Wave; 
using System.Text;
using Spectre.Console;


public static class Program
{
    ///ponerlo todo en ingles
    //hacer informe

        
    public static int n = 30; //tamaño del lab
    static int[,] lab = new int[1000, 1000]; //lab de 1 y 0
    static bool[,] vis = new bool[1000, 1000]; //veriPiecea si una pos ya fue vis
     public static int[] pl_cnt = {2,2}; /// player contador 
    
    static string[,] maze = new string [1000, 1000]; //maze
    static piece[] pieces = {
        new piece("☻"),new piece("☻"),new piece("☻"),
        new piece("☻"),new piece("☻"),new piece("☻")
    }; // 6 pieces


    ///habilidades
    const string skill1_txt = "duplica su velocidad";
    const string skill2_txt = "las trampas no le afectan";
    const string skill3_txt = "destruye las paredes del maze";
    const string skill4_txt = "regresa un slime del oponente al inicio";
    const string skill5_txt = "congela los slimes del oponente";
    const string skill6_txt = "impide que el rival use las habilidades de sus slimes";
    

    static int cant = 2; //cada jugador tiene 2 pieces

    static void MainMenu () // menu principal
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; //usar emojis
        
        pieces[0].name = "Fast Slime";
        pieces[0].speed = 15;
        pieces[0].Frozen_time = 2;
        pieces[0].skill_desc = skill1_txt;

        pieces[1].name = "Trap Slime";
        pieces[1].speed = 14;
        pieces[1].Frozen_time = 3;
        pieces[1].skill_desc = skill2_txt;

        pieces[2].name = "Strong Slime";
        pieces[2].speed = 10;
        pieces[2].Frozen_time = 1;
        pieces[2].skill_desc = skill3_txt;

        pieces[3].name = "Begin Slime";
        pieces[3].speed = 12;
        pieces[3].Frozen_time = 5;
        pieces[3].skill_desc = skill4_txt;

        pieces[4].name = "Frozen Slime";
        pieces[4].speed = 18;
        pieces[4].Frozen_time = 4;
        pieces[4].skill_desc = skill5_txt;

        pieces[5].name = "Skill Slime";
        pieces[5].speed = 22;
        pieces[5].Frozen_time = 2;
        pieces[5].skill_desc = skill6_txt;

        Introduction.Menu();        
    }
    static void MakeTable()
    {
        var table = new Table();

        table.AddColumn("[blue]ID[/]");
        table.AddColumn("[blue]Nombre[/]");
        table.AddColumn("[blue]Habilidad[/]");
        table.AddColumn("[blue]Veclocidad[/]");
        table.AddColumn("[blue]Tiempo de enfriamiento[/]");
        table.AddRow("[cyan]1[/]", "[cyan]Fast Slime[/]", "[cyan]duplica su velocidad[/]", "[cyan]15[/]", "[cyan]2[/]");
        table.AddRow("[yellow]2[/]", "[yellow]Tramp Slime[/]", "[yellow]las trampas no le afectan[/]", "[yellow]14[/]", "[yellow]3[/]");
        table.AddRow("[green]3[/]", "[green]Strong Slime[/]", "[green]destruye las paredes del maze[/]", "[green]10[/]", "[green]1[/]");
        table.AddRow("[hotpink]4[/]", "[hotpink]Begin SLime[/]", "[hotpink]regresa un slime del oponente al inicio[/]", "[hotpink]12[/]", "[hotpink]5[/]");
        table.AddRow("[blue]5[/]", "[blue]Frozen Slime[/]", "[blue]congela los slimes del oponente[/]", "[blue]18[/]", "[blue]4[/]");
        table.AddRow("[red]6[/]", "[red]SkillS Lime[/]", "[red]impide que el rival use las habilidades de sus slimes[/]", "[red]22[/]", "[red]2[/]");

        table.BorderColor(Color.Blue);
        AnsiConsole.Write(table);
    }

    static void Makelab () // hago el maze
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
                    maze[i,j] = " ";
                } 
                else 
                {
                    if (lab[i, j] == 0) 
                    { 
                        maze[i, j] = " ";
                    } 
                    else {
                        maze[i, j] = "█";
                    }
                }
            }   
        }
    }
    public static int Main(string[] args)
    {
        ///musica
        using (var audioFile= new AudioFileReader("F:/programas/Slime.mp3"))
        using (var outputDevice = new WaveOutEvent())
        {
            outputDevice.Init(audioFile);
            outputDevice.Play();
           
        

        ConsoleKeyInfo key;
        MainMenu(); // inicio
        bool  follow = Selection.Options(); //vemos si desea jugar o salir
        if (!follow) return 0;
        
        Introduction.Begin(); //introduccion al juego
        bool []selected = {false, false, false, false, false, false};
        
        for (int i = 0; i < 4; i++) //escogen sus pieces
        {
            Console.Clear();
            AnsiConsole.MarkupLine("[bold italic magenta]Seleccione los slimes que desea ayudar[/]");
            Console.WriteLine();
            MakeTable(); //muestro pieces para que el jugador elija en forma de tabla
            int num_player = (i%2+1);
            if (num_player == 1) {
                AnsiConsole.MarkupLine("[bold italic magenta]Jugador 1 seleccione un slime:[/] ");
            } else {
                AnsiConsole.MarkupLine("[bold italic magenta]Jugador 2 seleccione un slime:[/] ");
            }
            
            Selection.Decide(ref selected, pieces, i); //ver que pieces decide coger
            
        }
        for (int i = 0; i < 6; i++) //iteramos por todas las pieces y vemos que Pieceha es de que jugador
        { 
            pieces[i].init(); //ver funcion
            if (selected[i] == false)
                pieces[i] = null;
        }
        
        Makelab(); // se hace el lab for
        Traps.Trap_1(ref maze, n); //trampas
        Traps.Trap_2(ref maze, n); //trampas
        Traps.Trap_3(ref maze, n); //trampas

        Teleporter.Tele(ref maze, n); //teletranportadores 
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
                Show.Maze(buffer, n, turn, ref pieces, ref maze);
                
                AnsiConsole.Markup(buffer.ToString()); //mostramos
                
                Console.WriteLine();
                if (turn == 1) 
                {
                    AnsiConsole.MarkupLine("[bold italic magenta]Es el turno del jugador 1[/]");
                } 
                else {
                    AnsiConsole.MarkupLine("[bold italic magenta]Es el turno del jugador 2[/]");
                }
                
                AnsiConsole.MarkupLine("[bold italic magenta]Seleccione el slime que desea usar[/]");
                if (1+Player == 1)
                {
                   AnsiConsole.MarkupLine("[bold italic magenta]Jugador 1 tus slimes:[/]");
                } 
                else {
                   AnsiConsole.MarkupLine("[bold italic magenta]Jugador 2 tus slimes:[/]");
                }
                
                bool[] visited = new bool[7];
                for (int i = 0; i < pieces.Length; i++)
                {
                    if (pieces[i] == null || pieces[i].player != Player) continue;
                    Show.Slimes(pieces[i].id);
                    visited[i+1] = true;

                }
                buffer.Clear();
                int piece_id = Selection.Choose(visited);
                piece Piece = null;
                int pos_Piece = 0;
                for (int i = 0; i < pieces.Length; i++)
                {
                    if (pieces[i] == null) continue;
                    if (pieces[i].id == piece_id) ///si es la ficha que elegi
                    {
                        Piece = pieces[i];
                        pos_Piece = i;
                    }
                }
                
                string useskills = "NO";
                if (Piece.c_time <= 0 && all_no_skill == 0)
                {
                    AnsiConsole.MarkupLine("[bold italic blue]Escriba[/]" + "[bold italic magenta] SI [/]" + "[bold italic blue]si desea usar la habilidad de este slime en este turno y [/]" + " [bold italic magenta]NO[/] " + "[bold italic blue]en caso contario[/]");
                    useskills = Console.ReadLine();
                }
                if (all_no_skill == 1) all_no_skill = 0;
                bool frst = true;
                int op = 0, res = Piece.speed;
                for (int vel = 0; vel < res; vel ++)
                {
                    if (frst)
                    if (useskills == "SI")
                    {
                        frst = false;
                        Piece.c_time = Piece.Frozen_time+1;
                        Piece.skill(ref all_no_skill,ref op,ref vel,ref pieces);
                    }
                    buffer.Clear();
                    
                    Show.Maze (buffer, n,turn, ref pieces, ref maze);

                    string mov = "Movimientos restantes: ";
                    buffer.Append($"[magenta]{mov}[/]");
                    buffer.Append((res - vel));
                    buffer.AppendLine();

                    if (last_operation != 0) last_operation = 0;
                    Console.Clear();
                    AnsiConsole.Markup(buffer.ToString());
                    if (Piece.posX == Piece.endX && Piece.posY == Piece.endY) 
                    {
                        pl_cnt[Piece.player]--;
                        if (pl_cnt[Piece.player] == 0)
                        {
                            Console.WriteLine();
                            if (Player+1 == 1)
                            {
                                AnsiConsole.MarkupLine("[bold italic magenta]HA GANADO EL JUGADOR 1[/]");
                            } else {
                                AnsiConsole.MarkupLine("[bold italic magenta]HA GANADO EL JUGADOR 2[/]");
                            }
                            
                            return 0;
                        }
                      
                        Piece = null;
                        break;
                    }       
                     
                    ConsoleKeyInfo KEY = Console.ReadKey(true);
                    if (KEY.Key == ConsoleKey.UpArrow)
                        Piece.Move(-1, 0, n, ref maze, ref last_operation);
                    else if (KEY.Key == ConsoleKey.DownArrow)
                        Piece.Move(1, 0, n, ref maze, ref last_operation);
                    else if (KEY.Key == ConsoleKey.LeftArrow)
                        Piece.Move(0, -1, n, ref maze, ref last_operation );
                    else if (KEY.Key == ConsoleKey.RightArrow)
                        Piece.Move(0, 1, n, ref maze, ref last_operation);
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
                        Show.Maze (buffer, n, turn, ref pieces, ref maze);
                        Console.WriteLine();
                        AnsiConsole.Markup(buffer.ToString());
                        
                        Console.WriteLine();
                        AnsiConsole.MarkupLine("[bold italic magenta]Has caído en una trampa :([/]");
                        AnsiConsole.MarkupLine("[bold italic blue]Presione cualquier tecla para continuar[/]");
                        Console.ReadKey();
                    } 
                    else if (last_operation == 2)
                    {
                        Console.Clear();
                        Show.Maze(buffer, n, turn, ref pieces, ref maze);
                        Console.WriteLine();
                        AnsiConsole.Markup(buffer.ToString());
                        
                        Console.WriteLine();
                        AnsiConsole.MarkupLine("[bold italic magenta]Te has teletransportado a la salida :)[/]");
                        AnsiConsole.MarkupLine("[bold italic blue]Saque su Slime fuera del maze[/]");
                        Console.ReadKey();
                    }
                    if (Piece.brk == 1)
                    {
                        Piece.brk = 0;
                        break;
                    }
                }
                Player += op;
                if (Piece != null)
                {
                    Piece.strong = 0;
                    Piece.t_affect = 1;
                    Piece.c_time-=1;
                }
                pieces[pos_Piece] = Piece;
                if (op == 0)
                    if (turn == 1) turn = 2;
                    else turn = 1;
                
            }
       }  
       Console.ReadKey();
       }
       return 0;        
    }
}
