using System;
public class Trampas{

    public static void Trampa1 (ref string[,] laberinto, int n) 
    {
       Random rand = new Random();
       int cont = 0;
       while (cont < 5) 
       {
         int x = rand.Next(n);
         int y = rand.Next(n);
         int no_en_inicio = 0;
         if (x == 0 && y == 1 || x == n && y == n-1)
         {
           no_en_inicio = 1;
         }
         if (laberinto[x, y] !="█" && laberinto[x, y] != "🔙" && no_en_inicio != 1)
         {
            cont+=1;
            laberinto[x, y] =  "🔙";
         }
       }
    }
    public static void Trampa2 (ref string[,] laberinto, int n) 
    {
       Random rand = new Random();
       int cont = 0;
       while (cont < 5) 
       {
         int x = rand.Next(n);
         int y = rand.Next(n);
         int no_en_inicio = 0;
         if (x == 0 && y == 1 || x == n && y == n-1)
         {
           no_en_inicio = 1;
         }
         if (laberinto[x, y] != "█" && laberinto[x, y] != "🔙" && laberinto[x, y] != "🐢" && no_en_inicio != 1)
         {
               cont+=1;
               laberinto[x, y] ="🐢";
         }
       }
    }
    public static void Trampa3 (ref string[,] laberinto, int n) 
    {
       Random rand = new Random();
       int cont = 0;
       while (cont < 5) 
       {
         int x = rand.Next(n);
         int y = rand.Next(n);
         int no_en_inicio = 0;
         if (x == 0 && y == 1 || x == n && y == n-1)
         {
           no_en_inicio = 1;
         }

         if (laberinto[x, y] != "█" && laberinto[x, y] != "🔙" && laberinto[x, y] != "🐢" && laberinto[x, y] != "💣" && no_en_inicio != 1)
         {
            cont+=1;
            laberinto[x, y] =  "💣";
         }
       }
    }
}