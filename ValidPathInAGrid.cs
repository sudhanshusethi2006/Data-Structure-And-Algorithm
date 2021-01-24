using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{
    class ValidPathInAGrid
    {

        static void Main(string[] args)
        {


         //   int[][] grid = new int[][] { new int[] { 2, 4, 3 }, new int[] { 6, 5, 2 } };
            //int[][] grid = new int[][] { new int[] { 1 } };

            int[][] grid = new int[][] { new int[] { 1, 1, 1, 1, 6 }, new int[] { 1, 1, 1, 1, 2 }, new int[] { 1, 1, 1, 1, 2 }, new int[] { 1, 1, 1, 1, 2 }, new int[] { 1, 1, 1, 1, 2 } };
         //   int[][] grid = new int[][] { new int[] { 1, 2, 1 }, new int[] { 1, 2, 1 } };
            Solution obj = new Solution();
            bool ans = obj.HasValidPath(grid);
        }


        class Solution
        {
            int[][] CopyGrid;
            public bool HasValidPath(int[][] grid)
            {
   
                int x= grid.Length;
                int y= grid[0].Length;
                int[] arr= new int[y];
                CopyGrid = new int[x][];

                for (int i = 0; i < x; i++)
                {
                    CopyGrid[i] = new int[y];
                    for (int j = 0; j < y; j++)
                    {

                        CopyGrid[i][j] = grid[i][j];
                    }
                }

                CopyGrid[x-1][y-1]=10+  CopyGrid[x-1][y-1];
                bool ans = checkEveryCell(0, 0);
                return ans;
            }


            public bool checkEveryCell(int x, int y)
            {
                if (CopyGrid[x][y] >= 10) return true;
                else if (CopyGrid[x][y] <= 0) return false;

                else
                {
                    int temp = CopyGrid[x][y];
                    CopyGrid[x][y] = 0;
                    bool ans = false;

                 

                    switch (temp)
                    {
                        case 1: ans = (isValid(x, y - 1) && (CopyGrid[x][y - 1] % 10 == 1 || CopyGrid[x][y - 1] % 10 == 4 || CopyGrid[x][y - 1] % 10 == 6) && checkEveryCell(x, y - 1))
                            || (isValid(x, y + 1) && (CopyGrid[x][y + 1] % 10 == 1 || CopyGrid[x][y + 1] % 10 == 3 || CopyGrid[x][y + 1] % 10 == 5) && checkEveryCell(x, y + 1));
                            break;

                        case 2: ans = (isValid(x - 1, 1) && (CopyGrid[x - 1][y] % 10 == 2 || CopyGrid[x - 1][y] % 10 == 3 || CopyGrid[x - 1][y] % 10 == 4) && checkEveryCell(x - 1, y))
                                       || (isValid(x + 1, y) && (CopyGrid[x + 1][y] % 10 == 2 || CopyGrid[x + 1][y] % 10 == 5 || CopyGrid[x + 1][y] % 10 == 6) && checkEveryCell(x + 1, y));
                            break;


                        case 3: ans = (isValid(x, y - 1) && (CopyGrid[x][y - 1] % 10 == 4 || CopyGrid[x][y - 1] % 10 == 6 || CopyGrid[x][y - 1] % 10 == 1) && checkEveryCell(x, y - 1))
                                       || (isValid(x + 1, y) && (CopyGrid[x + 1][y] % 10 == 5 || CopyGrid[x + 1][y] % 10 == 6 || CopyGrid[x + 1][y] % 10 == 2) && checkEveryCell(x + 1, y));
                            break;


                        case 4: ans = (isValid(x, y + 1) && (CopyGrid[x][y + 1] % 10 == 3 || CopyGrid[x][y + 1] % 10 == 5 || CopyGrid[x][y + 1] % 10 == 1) && checkEveryCell(x, y + 1))
                                       || (isValid(x + 1, y) && (CopyGrid[x + 1][y] % 10 == 5 || CopyGrid[x + 1][y] % 10 == 6 || CopyGrid[x + 1][y] % 10 == 2) && checkEveryCell(x + 1, y));
                            break;


                        case 5: ans = (isValid(x - 1, y) && (CopyGrid[x - 1][y] % 10 == 3 || CopyGrid[x - 1][y] % 10 == 4 || CopyGrid[x - 1][y] % 10 == 2) && checkEveryCell(x - 1, y))
                                       || (isValid(x, y - 1) && (CopyGrid[x][y - 1] % 10 == 4 || CopyGrid[x][y - 1] % 10 == 6 || CopyGrid[x][y - 1] % 10 == 1) && checkEveryCell(x, y - 1));
                            break;


                        case 6: ans = (isValid(x - 1, y) && (CopyGrid[x - 1][y] % 10 == 4 || CopyGrid[x - 1][y] % 10 == 3 || CopyGrid[x - 1][y] % 10 == 2) && checkEveryCell(x - 1, y))
                                       || (isValid(x, y + 1) && (CopyGrid[x][y + 1] % 10 == 5 || CopyGrid[x][y + 1] % 10 == 3 || CopyGrid[x][y + 1] % 10 == 1) && checkEveryCell(x, y + 1));
                            break;
                    }
                    if (ans) CopyGrid[x][y] = temp + 10;
                    else CopyGrid[x][y] = temp % 10 - 10;
                    return ans;
                }


            }


            public bool isValid(int x, int y)
            {
                bool ans= x >= 0 && y >= 0 && x<CopyGrid.Length && y< CopyGrid[0].Length;

                return ans;
            }

            //enum isPath
            //{
            //    leftAndRight = 1,
            //    upperAndLower = 2,
            //    leftAndLower = 3,
            //    rightandLower = 4,
            //    leftAndUpper = 5,
            //    rightandUpper = 6

            //}
        }

    }
}
