using System;
public class Trampas{
    public static void Trampa (ref char[,] laberinto, int n) 
    {
       Random rand = new Random();
       int cont = 0;
       while (cont < 2) 
       {
        int x = rand.Next(n);
        int y = rand.Next(n);
         if (laberinto[x, y] != '█' && laberinto[x, y] != 'T' && laberinto[x, y] != 'F')
         {
            cont+=1;
            laberinto[x, y] =  'T';
         }
       }
    }
}