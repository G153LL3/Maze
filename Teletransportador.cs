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
            if (laberinto[x, y] != '█' && laberinto[x, y] != 'T' && laberinto[x, y] != 'H' && laberinto[x, y] != 'O' && laberinto[x, y] != '☻' && laberinto[x, y]!= 'P' && laberinto[x, y] != '☺')
            {
                cont+=1;
                laberinto[x, y] = 'P';
            }  
        }
    }
   
}