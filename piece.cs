using System;
using System.Text;
using Spectre.Console;

public class piece
{
    public int 
    startX,     //posicion x inicial
    startY,     //posicion y inicial
    endX,       //posicion x final
    endY,       //lo mismo y final
    posX,       //pos actual
    posY,       //pos actaual 
    c_time = 0, //tiempo actual
    t_affect,   //si es 1 las trampas te afectan
    speed,      //veclocidad
    number,     //nose
    player,     //el player que es dueño de esta ficha
    Frozen_time,//tiempo de enfriamiento
    id,         //identifica la ficha
    strong = 0, //para habilidad
    brk = 0;    //para la segunda trampa
     
    public string ico, name, skill_desc = "None";

    public piece (string icon,string name = "piece")
    {
        this.t_affect = 1;
        this.ico = icon;
        this.name = name;
    }
    
    public void skill (ref int nxt_not, ref int turn, ref int sp, ref piece[] pieces)
    {
        if (this.id == 1)
        {
            dup_speed(ref sp);
        } else if(this.id == 2)
        {
            trap_affect();  
        } else if(this.id == 3)
        {
            this.strong = 1;
        } else if(this.id == 4)
        {
            int x = Begin(ref pieces);    
            Console.Write(x);
            pieces[x].posX = pieces[x].startX;
            pieces[x].posY = pieces[x].startY;
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
            this.startX = 0;
            this.startY= 1;
            this.endX = Program.n;
            this.endY = Program.n-1;
        }
        else if(this.player == 1)
        {
            this.posX = Program.n;
            this.posY = Program.n-1;
            this.startX = Program.n;
            this.startY= Program.n-1;
            this.endX = 0;
            this.endY = 1;
        }
    }
    //lstop como llevar 3 bool es last operation
    public void Move (int deltaX, int deltaY, int n, ref string[,] maze, ref int lstop, ref piece[] pieces)
    {   
        int newposX = this.posX + deltaX;
        int newposY = this.posY + deltaY;
        int cnt = 0; ///cuenta la catidad de pieces
        for (int k = 0; k < pieces.Length; k++)
        {
            if (pieces[k] == null) continue;        
            if ( newposX == pieces[k].posX && newposY == pieces[k].posY) //verifica si hay una ficha
            {
                cnt++;
            }
        }

        if (newposX >= 0 && newposX < n+1 && newposY >= 0 && newposY < n+1 && (maze[newposX, newposY] != "█" || this.strong == 1)&& cnt <=1)
        {
            lstop ^= 4; 
            this.posX = newposX;
            posY = newposY;
            if (maze[this.posX, this.posY] == "█") maze[this.posX, this.posY] = " ";
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
                maze[this.posX, this.posY] = " ";
                this.posX = this.startX;
                this.posY = this.startY;
                lstop ^=1;     
            } 
            if (maze[this.posX, this.posY] == "🚪") 
            {
                maze[this.posX, this.posY] = " ";
                this.posX = this.endX;
                this.posY = this.endY;
                lstop ^=2;
            }
        }
    }    
    /**de aqui para abajo es las habilidades*/

    public int index;
    public void dup_speed (ref int sp)
    {
        sp -= this.speed;
    }

    public void trap_affect() 
    {
        this.t_affect = 0;
    }// recordar marcar al final del turno
    
    public int Begin(ref piece[] pieces)
    { // mueve una ficha del rival al inicio
        AnsiConsole.MarkupLine("[bold italic blue]Diga que ficha desea mover al inicio[/]");
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