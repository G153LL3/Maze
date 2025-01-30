using System;

public static class Lab {
    
    public static bool outt(int i, int j, int n) //verifica que no se salga de rango
    {
        if (i <= 0 || j <= 0) return true;
        if (j >= n || i >= n) return true;
        return false; 
    }
    
    public static void dfs (int n, int i, int j, ref bool[,] vis, ref  int[,] lab ,int p1 = -10000, int p2 = -10000)
    {
        if (outt(i, j, n)) return; //verifico q esa pos no esta visitada
        vis[i, j] = true;
        int[] x = {0, 0, 2,-2};
        int[] y = {2,-2, 0, 0};
        int[] ok = {0, 0, 0, 0};
        
        for (int l = 0; l < 100; l++) 
        {
            int k = -1;
            Random rand = new Random();
            int z = rand.Next(101);
            if (z <= 100) k = 3; /// divido entre 4 para que tengan la misma probabilidad
            if (z <= 75)  k = 2;
            if (z <= 50)  k = 1;
            if (z <= 25)  k = 0;

            if (outt(i+x[k], j+y[k], n)) continue;

                if (z <= 25) 
                {
                    if (ok[0] == 1) continue; //que no haya cogido en esa direccion
                    ok[0] = 1;
                    if (i == p1 && j+2 == p2) continue; // verifico que a donde voy no sea de donde vengo
                    if (!vis[i,j+2]) {
                        lab[i,j+2] = 0; /// rompo paredes 
                        lab[i,j+1] = 0;
                        dfs(n, i, j+2, ref vis, ref lab, i, j);  // me muevo 
                    }
                    continue;
                } 
                
                if (z <= 50)
                {
                    if (ok[1] == 1) continue;
                    ok[1] = 1;
                    if (i == p1 && j-2 == p2) continue;
                    if (!vis[i,j-2]) {
                        lab[i,j-2] = 0;
                        lab[i,j-1] = 0;
                        dfs(n, i, j-2, ref vis, ref lab, i, j);
                    }
                    continue;
                }
                
                if (z <= 75)
                {
                    if (ok[2] == 1) continue;
                    ok[2] = 1;
                    if (i+2 == p1 && j == p2) continue;
                    if (!vis[i+2,j]) {
                        lab[i+1,j] = 0;
                        lab[i+2,j] = 0;
                        dfs(n, i+2, j, ref vis, ref lab, i, j);
                    }
                    continue;
                }
                if (z <= 100)
                {
                    if (ok[3] == 1) continue;
                    ok[3] = 1;
                    if (i-2 == p1 && j == p2) continue;
                    if (!vis[i-2,j]) {
                        lab[i-1,j] = 0;
                        lab[i-2,j] = 0;
                        dfs(n, i-2, j, ref vis, ref lab, i, j);
                    }
                    continue;
                }
                
        }

    }
}