using System;

public class ficha
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
    player, // el player que es dueNo de esta ficha
    Frozen_time,
    id;

    public string 
    ico,
    name,
    skill_desc = "None";

    public ficha(string icon, string name = "ficha")
    {
        this.t_affect = 1;
        this.ico = icon;
        this.name = name;
    } 

    public void skill(ref int nxt_not,ref int turn,ref int vel,ref ficha[] fichas)
    {
        if(this.id == 1){
            dup_speed(ref vel);
        }else if(this.id == 2){
            tramp_affect();
        }else if(this.id == 3){

        } else if(this.id == 4){
            int x = Begin(ref fichas);    
            Console.Write(x);
            fichas[x].posX = fichas[x].initX;
            fichas[x].posY = fichas[x].initY;
        }else if(this.id == 5){
            Frozen(ref turn);
        }else{
            Nskills(ref nxt_not);
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
            this.posX = nuevaposX;
            this.posY = nuevaposY;
            if (laberinto[this.posX, this.posY] == 'T' && t_affect > 0)
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






    /**de aqui para abajo es las habilidades*/

    public int index;

    public void dup_speed(ref int vel){
        vel -= this.speed;
    }

    public void tramp_affect() 
    {
        this.t_affect = 0;
    }// recordar marcar al final del turno
    
    public void unbreaking(){ // no afectan las skill hasta el proximo turno

    }

    public int Begin(ref ficha[] fichas){ // mueve una ficha del rival al inicio
        Console.WriteLine("Diga que ficha desea mover al inicio");
        for(int i = 0; i < fichas.Length; i++){
            if(fichas[i] == null)continue; 
            if(player == fichas[i].player)continue;
            Console.WriteLine(fichas[i].name + " " + (i+1));
        }
        return int.Parse(Console.ReadLine())-1;
    }

    public void Frozen(ref int rcp){ // congela un slime
        rcp+=1;
    }

    public void Nskills(ref int nxt_not){ // no deja que los demas la usen en el proximo turno
        nxt_not = 1;
    }
}