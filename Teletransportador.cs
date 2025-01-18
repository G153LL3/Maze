using System;
public static class Teletransportador
{
   public static void Tele(ref char[,] laberinto, int n)
    {
        Random rand = new Random();
        int cont = 0;
        while (cont < 4)
        {
            int x = rand.Next(n);
            int y = rand.Next(n);
            int no_en_inicio = 0;
            if (x == 0 && y == 1 || x == n && y == n-1)
            {
                no_en_inicio = 1;
            }
            if (laberinto[x, y] != '█' && laberinto[x, y] != 'T' && laberinto[x, y] != 'H' && laberinto[x, y] != 'O' && laberinto[x, y]!= 'P' && no_en_inicio != 1)
            {
                cont+=1;
                laberinto[x, y] = 'P';
            }  
        }
    }
   
}