using System;
using System.Text;
using Spectre.Console;

public static class Program
{
    public static int n = 10;
    static int[,] lab = new int[1000, 1000];
    public static int[] pl_cnt = {2,2};
    static bool[,] vis = new bool[1000, 1000];
    static char[,] laberinto = new char [1000, 1000];
    static ficha[] fichas = {
        new ficha("☻"),new ficha("☻"),new ficha("☻"),
        new ficha("☺"),new ficha("☺"),new ficha("☺")
    };

    const string skill1_txt = "duplica velocidad";
    const string skill2_txt = "las trampas no le afectan";
    const string skill3_txt = "inmunidad ante habilidades";
    const string skill4_txt = "regresa una ficha al inicio";
    const string skill5_txt = "congela las ficha rival por 1 turno";
    const string skill6_txt = "impide que el rival use habilidades";

    static int cant_fichas = 2;

    static void MainMenu () // menu principal
    {
        
        fichas[0].name = "SlimeFast";
        fichas[0].speed = 15;
        fichas[0].Frozen_time = 2;
        fichas[0].skill_desc = skill1_txt;

        fichas[1].name = "SlimeTramp";
        fichas[1].speed = 10;
        fichas[1].Frozen_time = 3;
        fichas[1].skill_desc = skill2_txt;

        fichas[2].name = "SlimeUnbreaking";
        fichas[2].speed = 20;
        fichas[2].Frozen_time = 1;
        fichas[2].skill_desc = skill3_txt;

        fichas[3].name = "SlimeBegin";
        fichas[3].speed = 12;
        fichas[3].Frozen_time = 5;
        fichas[3].skill_desc = skill4_txt;

        fichas[4].name = "SlimeFrozen";
        fichas[4].speed = 18;
        fichas[4].Frozen_time = 4;
        fichas[4].skill_desc = skill5_txt;

        fichas[5].name = "SLimeSkill";
        fichas[5].speed = 22;
        fichas[5].Frozen_time = 2;
        fichas[5].skill_desc = skill6_txt;


        Console.Clear();
        Console.WriteLine("***********");
        Console.WriteLine("*Main Menu*");
        Console.WriteLine("***********");
        Console.WriteLine("* 1-Jugar *");
        Console.WriteLine("* 2-Salir *");
        Console.WriteLine("***********");
        
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
        //laberinto[0, 1] = 'F';
    }
    
    public static int Main()
    {
        ConsoleKeyInfo key;
        MainMenu();
        do {
            key = Console.ReadKey(); //vemos si desea jugar o salir
            if (key.Key == ConsoleKey.D1)
            {
                break;
            }
            if (key.Key == ConsoleKey.D2)
            {
                return 0;
            }
        } while(key.Key != ConsoleKey.D1 && key.Key != ConsoleKey.D2);
        

        muela.inicio(); //introduccion al juego
        bool []selected = {false, false, false, false, false, false};
        
        for (int i = 0; i < 4; i++) //escogen sus fichas
        {
            Console.Clear();
            Console.WriteLine("Seleccione los slimes que desea ayudar");
            for (int fhs = 0; fhs < fichas.Length; fhs++) //muestro las 6 fichas
            {
                if (selected[fhs]) continue;
                Console.WriteLine(" " +(1+fhs)+ "- " + fichas[fhs].name + " speed: " + fichas[fhs].speed + " skill: " + fichas[fhs].skill_desc + " frozen time " + fichas[fhs].Frozen_time +" * ");
            }
            Console.WriteLine("***************************");

            Console.WriteLine("Jugador "+(i%2+1)+" Seleccione una slime: ");
            key = Console.ReadKey(); //el jugador selecciona sus slimes
            if(key.Key == ConsoleKey.D1)
            {
                selected[0] = true;
                fichas[0].player = (i%2);
                fichas[0].id = 1;
            }
            else if(key.Key == ConsoleKey.D2)
            {
                selected[1] = true;
                fichas[1].player = (i%2);
                fichas[1].id = 2;

            }
            else if(key.Key == ConsoleKey.D3)
            {
                selected[2] = true;
                fichas[2].player = (i%2);
                fichas[2].id = 3;

            }
            else if(key.Key == ConsoleKey.D4)
            {
                selected[3] = true;
                fichas[3].player = (i%2);
                fichas[3].id = 4;

            }
            else if(key.Key == ConsoleKey.D5)
            {
                selected[4] = true;
                fichas[4].player = (i%2);
                fichas[4].id = 5;

            }
            else if(key.Key == ConsoleKey.D6)
            {
                selected[5] = true;
                fichas[5].player = (i%2);
                fichas[5].id = 6;
            }
        }
        for(int i = 0; i < 6; i++)
        {
            fichas[i].init();
            if (selected[i] == false)
                fichas[i] = null;
        }
        
        Makelab(); // se hace el lab for
        Trampas.Trampa1(ref laberinto, n); //trampas
        Trampas.Trampa2(ref laberinto, n); //trampas
        Trampas.Trampa3(ref laberinto, n); //trampas

        Teletransportador.Tele(ref laberinto, n); //teletranportadores 
        StringBuilder buffer = new StringBuilder(); //evitar pantallazos

        int last_operation = 0, turno = 1, jugador = -1;
        int  all_no_skill = 0;
        while (true)
        {
            
            for(int tt = 0;; tt++)
            {        
                jugador+=1;  
                jugador%=2;
                Console.Clear();    
                buffer.Clear();
                Mostrar.MostrarLaberinto(buffer, n,turno, ref fichas, ref laberinto);
                buffer.AppendLine("Jugador "+(1+jugador)+" tus slimes: ");

                for(int i = 0; i < fichas.Length; i++){
                    if(fichas[i] == null || fichas[i].player != jugador)continue;
                    buffer.AppendLine(fichas[i].name+" "+fichas[i].id);
                }
                buffer.AppendLine("Seleccione el slime que desea usar");
                AnsiConsole.Write(buffer.ToString());
                buffer.Clear();
                int ttt = int.Parse(Console.ReadLine());

                ficha fic = null;
                int fi_pos = 0;
                for(int i = 0; i < fichas.Length; i++)
                {
                    if(fichas[i] == null)continue;
                    if(fichas[i].id == ttt){
                        fic = fichas[i];
                        fi_pos = i;
                    }
                }
                
                char ky='N';
                if (fic.act_time <= 0 && all_no_skill == 0){
                    buffer.AppendLine("Ecriba Yes si desea usar la habilidad de este slime en este turno y No en caso contario");
                    AnsiConsole.Write(buffer.ToString());
                    buffer.Clear();
                    ky = char.Parse(Console.ReadLine());
                }
                if(all_no_skill == 1)all_no_skill = 0;

                int op = 0;
                for(int vel = 0; vel < fic.speed; vel ++){
                    if(vel == 0 )
                    if(ky == 'Y' || ky == 'y'){
                        fic.act_time = fic.Frozen_time+1;
                        fic.skill(ref all_no_skill,ref op,ref vel,ref fichas);
                    }
                    buffer.Clear();
                    Mostrar.MostrarLaberinto(buffer, n,turno, ref fichas, ref laberinto);

                    buffer.Append("movimientos restantes: ");
                    buffer.Append((fic.speed - vel));
                    buffer.AppendLine();
                    if (last_operation == 1)
                    {
                        buffer.Append("Haz caido en una trampa :( ");
                    } 
                    else if (last_operation == 2)
                    {
                        buffer.Append("Te haz teletransportado a la salida :) ");
                    }

                    if(last_operation != 0)last_operation = 0;
                    Console.Clear();
                    AnsiConsole.Write(buffer.ToString());
                    if (fic.posX == fic.FinX && fic.posY == fic.FinY) 
                    {
                        pl_cnt[fic.player]--;
                        if(pl_cnt[fic.player] == 0)
                        {
                            Console.WriteLine("HA GANADO EL JUGADOR " + (jugador+1));
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
                    if(last_operation < 4){
                        vel--;
                    } else {
                        last_operation ^= 4;
                    }
                    if(fic.brk == 1)
                    {
                        fic.brk = 0;
                        break;
                    }

                }
                jugador += op;
                if(fic != null){
                    fic.t_affect = 1;
                    fic.act_time-=1;
                }
                fichas[fi_pos] = fic;
                if(turno == 1)turno = 2;
                else turno = 1;
            }
            /// si el tiempo de enfriamiento es dif de 0 y jugo el jugador que tiene la hab correspondiente a ese tiempo de enfriamiento
            ///tiempo de enfriamiento --  
       }     
       return 0;        
    }
}
    /**
          
    */
