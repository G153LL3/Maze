using System;
using System.Text;
using Spectre.Console;

public class piece
{
    
   
    
    public int 
    initX, // posicion x inicial
    initY, // posicion y inicial
    FinX, // posicion x final
    FinY, // lo mismo pero con y
    posX, // 
    posY,act_time = 0,
    t_affect, // si es 1 las trampas te afectan
    speed,
    number,
    player, // el player que es dueño de esta ficha
    Frozen_time,
    id,strong = 0,
    brk=0;

    public string 
    ico,
    name,
    skill_desc = "None";

    public piece (string icon,string name = "piece")
    {
        this.t_affect = 1;
        this.ico = icon;
        this.name = name;
       
    }
    
    public void skill (ref int nxt_not, ref int turn, ref int vel, ref piece[] pieces)
    {
        if (this.id == 1)
        {
            dup_speed(ref vel);
        } else if(this.id == 2)
        {
            tramp_affect();
        } else if(this.id == 3)
        {
            this.strong = 1;
        } else if(this.id == 4)
        {
            int x = Begin(ref pieces);    
            Console.Write(x);
            pieces[x].posX = pieces[x].initX;
            pieces[x].posY = pieces[x].initY;
        } else if(this.id == 5)
        {
            Frozen(ref turn);
        } else
        {
            Nskills(ref nxt_not);
        }
    }

    public void init()
    {
        //le asignamos a cada ficha su posicion inicial, final y actual
        if (this.player == 0)
        {
            this.posX = 0;
            this.posY = 1;
            this.initX = 0;
            this.initY= 1;
            this.FinX = Program.n;
            this.FinY = Program.n-1;
        }
        else if(this.player == 1)
        {
            this.posX = Program.n;
            this.posY = Program.n-1;
            this.initX = Program.n;
            this.initY= Program.n-1;
            this.FinX = 0;
            this.FinY = 1;
        }
    }
    //lstop como llevar 3 bool es last operation
    public void Move (int deltaX, int deltaY, int n, ref string[,] maze, ref int lstop)
    {
        int nuevaposX = this.posX + deltaX;
        int nuevaposY = this.posY + deltaY;
        if (nuevaposX >= 0 && nuevaposX < n+1 && nuevaposY >= 0 && nuevaposY < n+1 && (maze[nuevaposX, nuevaposY] != "█" || this.strong == 1))
        {
            lstop ^= 4; 
            this.posX = nuevaposX;
            this.posY = nuevaposY;
            if (maze[this.posX, this.posY] == "█")maze[this.posX, this.posY] = " ";
            if (maze[this.posX, this.posY] == "🐢" && t_affect > 0)
            {
                lstop ^=1;     
                maze[this.posX, this.posY] = " ";
                this.speed /= 2; 
            }
            if (maze[this.posX, this.posY] == "💣" && t_affect > 0)
            {
                lstop ^=1;     
                maze[this.posX, this.posY] = " ";
                this.brk = 1;
            }
            
            if (maze[this.posX, this.posY] == "🔙" && t_affect > 0)
            {
               // Console.WriteLine("Caiste en un trampa");
                maze[this.posX, this.posY] = " ";
                this.posX = this.initX;
                this.posY = this.initY;
                lstop ^=1;     
            } else if (maze[this.posX, this.posY] == "🚪") 
            {
                maze[this.posX, this.posY] = " ";
                this.posX = this.FinX;
                this.posY = this.FinY;
                lstop ^=2;

            }
        }
    }    

    /**de aqui para abajo es las habilidades*/

    public int index;

    public void dup_speed(ref int vel)
    {
        vel -= this.speed;
    }

    public void tramp_affect() 
    {
        this.t_affect = 0;
    }// recordar marcar al final del turno
    

    public int Begin(ref piece[] pieces)
    { // mueve una ficha del rival al inicio
        AnsiConsole.MarkupLine("[bold italic blue]Diga que ficha desea mover al inicio[/]");
        for(int i = 0; i < pieces.Length; i++)
        {
            if (pieces[i] == null) continue; 
            if (player == pieces[i].player) continue;
            //Console.WriteLine(pieces[i].name + " " + (i+1));
            Show.Slimes(pieces[i].id);
        }
        return int.Parse(Console.ReadLine())-1;
    }

    public void Frozen(ref int rcp)
    { // congela un slime
        rcp+=1;
        
    }

    public void Nskills(ref int nxt_not)
    { // no deja que los demas la usen en el proximo turno
        nxt_not = 1;
    }
}