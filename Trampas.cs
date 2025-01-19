using System;
public class Trampas{

    public static void Trampa1 (ref char[,] laberinto, int n) 
    {
       Random rand = new Random();
       int cont = 0;
       while (cont < 2) 
       {
<<<<<<< HEAD
         int x = rand.Next(n);
         int y = rand.Next(n);
         int no_en_inicio = 0;
         if (x == 0 && y == 1 || x == n && y == n-1)
         {
           no_en_inicio = 1;
         }
         if (laberinto[x, y] != '█' && laberinto[x, y] != 'T' && no_en_inicio != 1)
=======
        int x = rand.Next(n);
        int y = rand.Next(n);
         if (laberinto[x, y] != '█' && laberinto[x, y] != 'T' && laberinto[x, y] != '☻' && laberinto[x, y] != '☺')
>>>>>>> 80b3520f835cbdc8a96ad4edfee2afdfb4f8acef
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
<<<<<<< HEAD
         int x = rand.Next(n);
         int y = rand.Next(n);
         int no_en_inicio = 0;
         if (x == 0 && y == 1 || x == n && y == n-1)
=======
        int x = rand.Next(n);
        int y = rand.Next(n);
         if (laberinto[x, y] != '█' && laberinto[x, y] != 'T' && laberinto[x, y] != 'H' && laberinto[x, y] != '☻' && laberinto[x, y] != '☺')
>>>>>>> 80b3520f835cbdc8a96ad4edfee2afdfb4f8acef
         {
           no_en_inicio = 1;
         }
         if (laberinto[x, y] != '█' && laberinto[x, y] != 'T' && laberinto[x, y] != 'H' && no_en_inicio != 1)
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
<<<<<<< HEAD
         int x = rand.Next(n);
         int y = rand.Next(n);
         int no_en_inicio = 0;
         if (x == 0 && y == 1 || x == n && y == n-1)
         {
           no_en_inicio = 1;
         }

         if (laberinto[x, y] != '█' && laberinto[x, y] != 'T' && laberinto[x, y] != 'H' && laberinto[x, y] != 'O' && no_en_inicio != 1)
=======
        int x = rand.Next(n);
        int y = rand.Next(n);
         if (laberinto[x, y] != '█' && laberinto[x, y] != 'T' && laberinto[x, y] != 'H' && laberinto[x, y] != 'O' && laberinto[x, y] != '☻' && laberinto[x, y] != '☺')
>>>>>>> 80b3520f835cbdc8a96ad4edfee2afdfb4f8acef
         {
            cont+=1;
            laberinto[x, y] =  'O';
         }
       }
    }
}