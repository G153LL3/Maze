using System;

public static class Teleporter
{
   public static void Tele(ref string[,] maze, int n)
    {
        Random rand = new Random();
        int count = 0;
        while (count < 3)
        {
            int x = rand.Next(n);
            int y = rand.Next(n);
            int notbegin = 0;
            if (x == 0 && y == 1 || x == n && y == n-1)
            {
                notbegin = 1;
            }
            if (maze[x, y] != "█" && maze[x, y] != "🔙" && maze[x, y] != "💣" && maze[x, y] != "🐢" && maze[x, y]!= "🚪"  && notbegin != 1)
            {
                count+=1;
                maze[x, y] = "🚪";
            }  
        }
    }
   
}