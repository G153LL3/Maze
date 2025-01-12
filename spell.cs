using System;


public class spell{
    public int index;

    public void dup_speed(ref int vel, ficha act_f){
        vel -= act_f.speed;
    }

    public void t_affect(ref ficha fh) 
    {
        fh.t_affect = 0;
    }// recordar marcar al final del turno
    
    public void unbreaking(){ // no afectan las skill hasta el proximo turno

    }

    public int Begin(int player,ref ficha[] fichas){ // mueve una ficha del rival al inicio
        Console.Write("Diga que ficha desea mover al inicio");
        for(int i = 0; i < fichas.Length; i++){
            if(fichas[i] == null)continue; 
            if(player == fichas[i].player)continue;
            Console.WriteLine(fichas[i].name + " " + i+1);
        }
        return int.Parse(Console.ReadLine());
    }

    public void Frozen(ref int rcp){ // congela un slime
        rcp+=1;
    }


    public void Nskills(){ // no deja que los demas la usen en el proximo turno

    }


}