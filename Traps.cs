using System;

public class Traps
{
    public static void Trap_1 (ref string[,] maze, int n) 
    {
        Random rand = new Random();
        int count = 0;
        while (count < 5) 
        {
            int x = rand.Next(n);
            int y = rand.Next(n);
            int notbegin = 0;
            if (x == 0 && y == 1 || x == n && y == n-1)
            {
                notbegin = 1;
            }
            if (maze[x, y] != "█" && maze[x, y] != "🔙" && notbegin != 1)
            {
                count+=1;
                maze[x, y] =  "🔙";
            }
        }
    }
    public static void Trap_2 (ref string[,] maze, int n) 
    {
        Random rand = new Random();
        int count = 0;
        while (count < 5) 
        {
            int x = rand.Next(n);
            int y = rand.Next(n);
            int notbegin = 0;
            if (x == 0 && y == 1 || x == n && y == n-1)
            {
                notbegin = 1;
            }
            if (maze[x, y] != "█" && maze[x, y] != "🔙" && maze[x, y] != "🐢" && notbegin != 1)
            {
                count+=1;
                maze[x, y] ="🐢";
            }
       }
    }
    public static void Trap_3 (ref string[,] maze, int n) 
    {
        Random rand = new Random();
        int count = 0;
        while (count < 5) 
        {
            int x = rand.Next(n);
            int y = rand.Next(n);
            int notbegin = 0;
            if (x == 0 && y == 1 || x == n && y == n-1)
            {
                notbegin = 1;
            }

            if (maze[x, y] != "█" && maze[x, y] != "🔙" && maze[x, y] != "🐢" && maze[x, y] != "💣" && notbegin != 1)
            {
                count+=1;
                maze[x, y] =  "💣";
            }
       }
    } 
}