using System;
using System.Text;
public static class Mostrar
{  
   public static void MostrarLaberinto(StringBuilder buffer, int n, int turno,ref ficha[] fichas, ref char[,] laberinto)
    {
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= n; j++)
            {
                int cnt = 0;
                for(int k = 0; k < fichas.Length; k++)
                {
                    if(fichas[k] == null)continue;
                    if (i == fichas[k].posX && j == fichas[k].posY) 
                    {
                        cnt++;
                    }
                }
                for(int k = 0; k < fichas.Length; k++)
                {
                    if(fichas[k] == null)continue;
                    if (i == fichas[k].posX && j == fichas[k].posY) // verifica si en I,J hay una ficha
                    {
                        buffer.Append(fichas[k].ico);
                        
                        if(cnt < 2)
                        {
                            buffer.Append(' ');
                        }
                    }
                }
                if (cnt == 0) // verifica si en I,J hay una ficha
                {
                    buffer.Append(laberinto[i, j]);
                    if(laberinto[i,j] == '█' || laberinto[i,j] == ' ')
                    {
                        buffer.Append(laberinto[i, j]);
                    }else{
                        buffer.Append(' ');
                    }
                }  
                
            }
            buffer.AppendLine();
        }
        buffer.Append("Es el turno del jugador ");
        buffer.Append(turno);
        buffer.AppendLine();
    }
}
