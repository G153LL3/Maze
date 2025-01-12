using System;
public class Trampas{

    public static void Trampa1 (ref char[,] laberinto, int n) 
    {
       Random rand = new Random();
       int cont = 0;
       while (cont < 2) 
       {
        int x = rand.Next(n);
        int y = rand.Next(n);
         if (laberinto[x, y] != '█' && laberinto[x, y] != 'T')
         {
            cont+=1;
            laberinto[x, y] =  'T';
         }
       }
    }
    public static void Trampa2 (ref char[,] laberinto, int n) 
    {
       Random rand = new Random();
       int cont = 0;
       while (cont < 2) 
       {
        int x = rand.Next(n);
        int y = rand.Next(n);
         if (laberinto[x, y] != '█' && laberinto[x, y] != 'T' && laberinto[x, y] != 'H')
         {
            cont+=1;
            laberinto[x, y] = 'H';
         }
       }
    }
    public static void Trampa3 (ref char[,] laberinto, int n) 
    {
       Random rand = new Random();
       int cont = 0;
       while (cont < 2) 
       {
        int x = rand.Next(n);
        int y = rand.Next(n);
         if (laberinto[x, y] != '█' && laberinto[x, y] != 'T' && laberinto[x, y] != 'H' && laberinto[x, y] != 'O')
         {
            cont+=1;
            laberinto[x, y] =  'O';
         }
       }
    }
}