using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

    // Complete the queensAttack function below.
    static int queensAttack(int n, int k, int r_q, int c_q, int[][] obstacles)
    {
        List<List<int>> board = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            List<int> temp = new List<int>();

            for (int jq = 0; jq < n; jq++)
            {
                temp.Add(1);
            }
            board.Add(temp);
        }

        //set blocked 
        for (int i = 0; i < k; i++)
        {
            board[obstacles[i][0]-1][obstacles[i][1]-1] = 0;

        }
        //iterate over the board to find all places the queen can reach
        //we are only looking for blocks 
        int found = 0;
        //up
        for (int i = r_q- 1; i >0; i--)
        {
            if (board[c_q][i]!=0)
            {
                found++;
            }
            else
            {
                break;
            }
        }
        //down
        for (int i = r_q-1; i <n; i++)
        {
            if (board[c_q][i]!=0)
            {
                found++;
            }
            else
            {
                break;
            }
        }
        //left
        for (int i = c_q-1; i >0 ; i--)
        {
            if (board[i][r_q] !=0)
            {
                found++;
            }
            else
            {
                break;
            }
        }
        //right 
        for (int i = c_q+1; i < n; i++)
        {
            if (board[i][r_q] !=0 )
            {
                found++;
            }
            else
            {
                break;
            }
        }
        // up and left  <-|
        int j = r_q - 1;
        for (int i = c_q-1; i >0; i--)
        {
            if (j <0)
            {
                break;
            }

            if (board[i][j]!=0)
            {
                found++;
            }
            else
            {
                break;
            }
            j--;

        }

        //up and right 
        j = r_q - 1;
        for (int i = c_q+1; i < n; i++)
        {
            if (n < 0)
            {
                break;
            }
            if (board[i][j]!=0)
            {
                found++;
            }
            else
            {
                break;
            }
            j--;

        }

        //down and left 
        j = r_q + 1;
        for (int i = c_q-1; i > 0; i--)
        {
            if (j>=n)
            {
                break;
            }
            if (board[i][j]!=0)
            {
                found++;
            }
            else
            {
                break;
            }
            j++;
        }
        //down and right 
        j = r_q +1;
        for (int i = c_q+1; i < n; i++)
        {
            if (j>=n)
            {
                break;
            }
            if (board[i][j]!=0)
            {
                found++;
            }
            else
            {
                break;
            }
            j++;
        }

        /*for (int i = 0; i < n; i++)
        {
            for (int jq = 0; jq < n; jq++)
            {
                Console.WriteLine(board[i][jq].ToString());
            }
            Console.Write("\n");
        }
        Console.WriteLine(found.ToString());
        
        return 1;*/
        return found;
    }

    static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
      //  textWriter = new StreamWriter(".");

        string[] nk = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nk[0]);

        int k = Convert.ToInt32(nk[1]);

        string[] r_qC_q = Console.ReadLine().Split(' ');

        int r_q = Convert.ToInt32(r_qC_q[0]);

        int c_q = Convert.ToInt32(r_qC_q[1]);

        int[][] obstacles = new int[k][];

        for (int i = 0; i < k; i++)
        {
            obstacles[i] = Array.ConvertAll(Console.ReadLine().Split(' '), obstaclesTemp => Convert.ToInt32(obstaclesTemp));
        }

        int result = queensAttack(n, k, r_q, c_q, obstacles);
        Console.WriteLine(result.ToString());

      //  textWriter.WriteLine(result);

       // textWriter.Flush();
      //  textWriter.Close();
    }
}
