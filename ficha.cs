using System;

public class ficha
{
    public int 
    initX, // posicion x inicial
    initY, // posicion y inicial
    FinX, // posicion x final
    FinY, // lo mismo pero con y
    posX, // 
    posY,
    t_affect, // si es 1 las trampas te afectan
    speed,
    number,
    player, // el player que es dueNo de esta ficha
    Frozen_time,
    id;

    public string 
    ico,
    name,
    skill_desc = "None";

    public spell skl;

    public ficha(string icon, string name = "ficha")
    {
        this.ico = icon;
        this.name = name;
    } 

    public void skill(ref ficha[] fichas)
    {
        if(this.id == 1){

        }else if(this.id == 2){

        }else if(this.id == 3){

        } else if(this.id == 4){
            int x = skl.Begin(this.player,ref fichas);    
            Console.Write(x);
            fichas[x].posX = fichas[x].initX;
            fichas[x].posY = fichas[x].initY;
        }else if(this.id == 5){

        }else{

        }
    }

    public void init()
    {
        if(this.player == 0)
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
    public void MoverFicha (int deltaX, int deltaY, int n, ref char[,] laberinto, ref int lstop)
    {
        int nuevaposX = this.posX + deltaX;
        int nuevaposY = this.posY + deltaY;
        if (nuevaposX >= 0 && nuevaposX < n+1 && nuevaposY >= 0 && nuevaposY < n+1 && laberinto[nuevaposX, nuevaposY] != '█')
        {
            lstop ^= 4; 
            laberinto[this.posX, this.posY] = ' ';
            this.posX = nuevaposX;
            this.posY = nuevaposY;
             if (laberinto[this.posX, this.posY] == 'T')
            {
               // Console.WriteLine("Caiste en un trampa");
                laberinto[this.posX, this.posY] = ' ';
                this.posX = this.initX;
                this.posY = this.initY;
                lstop ^=1;     
            } else if (laberinto[this.posX, this.posY] == 'P') {
                laberinto[this.posX, posY] = ' ';
                this.posX = this.FinX;
                this.posY = this.FinY;
                lstop ^=2;
            }
        }
    }    

}
