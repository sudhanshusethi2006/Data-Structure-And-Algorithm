using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{
    class ValidPathInAGrid_WithoutRecursion
    {

        static void Main(string[] args)
        {
            string x = "s";
            test(x);

            string J = "aA";
            string S = "aAAbbbb";
            int count = 0;

            bool[] tempArray = new bool[122];
            for (int i = 0; i < J.Length; i++)
            {
                tempArray[J[i]] = true;
            }
            for (int i = 0; i < S.Length; i++)
            {
                if (tempArray[S[i]])
                {
                    count++;
                }
            }


          //  int[][] grid = new int[][] { new int[] { 1, 1, 1, 1, 6 }, new int[] { 1, 1, 1, 1, 2 }, new int[] { 1, 1, 1, 1, 2 }, new int[] { 1, 1, 1, 1, 2 }, new int[] { 1, 1, 1, 1, 2 } };
              int[][] grid = new int[][] { new int[] { 1,1,1,1,3}, new int[] {4,2,5,4,2}, new int[] {1,1,6,6,2}, new int[] {4,2,6,2,2 }};
            //  int[][] grid = new int[][] { new int[] { 2, 4, 3 }, new int[] { 6, 5, 2 } };
            // int[][] grid = new int[][] { new int[] { 1,1,2} };
            // int[][] grid = new int[][] { new int[] { 1 } };
            //  int[][] grid = new int[][] { new int[] { 1, 2, 1 }, new int[] { 1, 2, 1 } };
            Solution obj = new Solution();
            bool ans = obj.HasValidPath(grid);
        }


        public static void test(string z)
        {
            string j = z;
            j = "10";
            

        }




        class Solution
        {
            int[][] CopyGrid;
            Stack<int[]> childPath = new Stack<int[]>();
            public bool HasValidPath(int[][] grid)
            {
                int x = grid.Length;
                int y = grid[0].Length;
           
                CopyGrid = new int[x][];

                for (int i = 0; i < x; i++)
                {
                    CopyGrid[i] = new int[y];
                    for (int j = 0; j < y; j++)
                    {

                        CopyGrid[i][j] = grid[i][j];


                    }

                }

                if (x == 1 && y == 1)
                {
                    return true;
                }
                int m = 0;
                int n = 0;
                bool isValid = false;


                while (isValidNeighbour(m, n))
                {
                    if (childPath.Count == 0)
                    {
                        isValid = false;
                        break;
                    }

                    m = childPath.Peek()[0];
                    n = childPath.Peek()[1];
                    childPath.Pop();
                    if (m == x - 1 && n == y - 1)
                    {
                        isValid = true;
                        break;
                    }
                }

                return isValid;

            }

            public bool isValidNeighbour(int x, int y)
            {


                int cellValue = CopyGrid[x][y];
                CopyGrid[x][y] = 0; // the cell is marked visited
                bool ans = false;

                switch (cellValue)
                {
                    case 1: ans = (isValid(x, y - 1) && (CopyGrid[x][y - 1] % 10 == 1 || CopyGrid[x][y - 1] % 10 == 4 || CopyGrid[x][y - 1] % 10 == 6))
                        || (isValid(x, y + 1) && (CopyGrid[x][y + 1] % 10 == 1 || CopyGrid[x][y + 1] % 10 == 3 || CopyGrid[x][y + 1] % 10 == 5));

                        if ((isValid(x, y - 1) && (CopyGrid[x][y - 1] % 10 == 1 || CopyGrid[x][y - 1] % 10 == 4 || CopyGrid[x][y - 1] % 10 == 6)))
                        {
                            if (CopyGrid[x][y - 1] != 0)
                            {
                                childPath.Push(new int[] { x, y - 1 });
                            }

                        }
                        if ((isValid(x, y + 1) && (CopyGrid[x][y + 1] % 10 == 1 || CopyGrid[x][y + 1] % 10 == 3 || CopyGrid[x][y + 1] % 10 == 5)))
                        {
                            if (CopyGrid[x][y + 1] != 0)
                            {
                                childPath.Push(new int[] { x, y + 1 });
                            }
                        }
                        break;

                    case 2: ans = (isValid(x - 1, 1) && (CopyGrid[x - 1][y] % 10 == 2 || CopyGrid[x - 1][y] % 10 == 3 || CopyGrid[x - 1][y] % 10 == 4))
                                   || (isValid(x + 1, y) && (CopyGrid[x + 1][y] % 10 == 2 || CopyGrid[x + 1][y] % 10 == 5 || CopyGrid[x + 1][y] % 10 == 6));

                        if ((isValid(x - 1, 1) && (CopyGrid[x - 1][y] % 10 == 2 || CopyGrid[x - 1][y] % 10 == 3 || CopyGrid[x - 1][y] % 10 == 4)))
                        {
                            if (CopyGrid[x - 1][y] != 0)
                            {
                                childPath.Push(new int[] { x - 1, y });
                            }
                        }

                        if ((isValid(x + 1, y) && (CopyGrid[x + 1][y] % 10 == 2 || CopyGrid[x + 1][y] % 10 == 5 || CopyGrid[x + 1][y] % 10 == 6)))
                        {
                            if (CopyGrid[x + 1][y] != 0)
                            {
                                childPath.Push(new int[] { x + 1, y });
                            }
                        }
                        break;


                    case 3: ans = (isValid(x, y - 1) && (CopyGrid[x][y - 1] % 10 == 4 || CopyGrid[x][y - 1] % 10 == 6 || CopyGrid[x][y - 1] % 10 == 1))
                                   || (isValid(x + 1, y) && (CopyGrid[x + 1][y] % 10 == 5 || CopyGrid[x + 1][y] % 10 == 6 || CopyGrid[x + 1][y] % 10 == 2));

                        if ((isValid(x, y - 1) && (CopyGrid[x][y - 1] % 10 == 4 || CopyGrid[x][y - 1] % 10 == 6 || CopyGrid[x][y - 1] % 10 == 1)))
                        {
                            if (CopyGrid[x][y - 1] != 0)
                            {
                                childPath.Push(new int[] { x, y - 1 });
                            }

                        }

                        if ((isValid(x + 1, y) && (CopyGrid[x + 1][y] % 10 == 5 || CopyGrid[x + 1][y] % 10 == 6 || CopyGrid[x + 1][y] % 10 == 2)))
                        {
                            if (CopyGrid[x+1][y] != 0)
                            {
                                childPath.Push(new int[] { x + 1, y });
                            }
                        }
                        break;


                    case 4: ans = (isValid(x, y + 1) && (CopyGrid[x][y + 1] % 10 == 3 || CopyGrid[x][y + 1] % 10 == 5 || CopyGrid[x][y + 1] % 10 == 1))
                                   || (isValid(x + 1, y) && (CopyGrid[x + 1][y] % 10 == 5 || CopyGrid[x + 1][y] % 10 == 6 || CopyGrid[x + 1][y] % 10 == 2));

                        if ((isValid(x, y + 1) && (CopyGrid[x][y + 1] % 10 == 3 || CopyGrid[x][y + 1] % 10 == 5 || CopyGrid[x][y + 1] % 10 == 1)))
                        {

                            if (CopyGrid[x][y+1] != 0)
                            {
                                childPath.Push(new int[] { x, y + 1 });
                            }
                        }

                        if ((isValid(x + 1, y) && (CopyGrid[x + 1][y] % 10 == 5 || CopyGrid[x + 1][y] % 10 == 6 || CopyGrid[x + 1][y] % 10 == 2)))
                        {
                            if (CopyGrid[x+1][y] != 0)
                            {
                                childPath.Push(new int[] { x + 1, y });
                            }
                        }
                        break;


                    case 5: ans = (isValid(x - 1, y) && (CopyGrid[x - 1][y] % 10 == 3 || CopyGrid[x - 1][y] % 10 == 4 || CopyGrid[x - 1][y] % 10 == 2))
                                   || (isValid(x, y - 1) && (CopyGrid[x][y - 1] % 10 == 4 || CopyGrid[x][y - 1] % 10 == 6 || CopyGrid[x][y - 1] % 10 == 1));

                        if ((isValid(x - 1, y) && (CopyGrid[x - 1][y] % 10 == 3 || CopyGrid[x - 1][y] % 10 == 4 || CopyGrid[x - 1][y] % 10 == 2)))
                        {

                            if (CopyGrid[x - 1][y] != 0)
                            {
                                childPath.Push(new int[] { x - 1, y });
                            }
                        }

                        if ((isValid(x, y - 1) && (CopyGrid[x][y - 1] % 10 == 4 || CopyGrid[x][y - 1] % 10 == 6 || CopyGrid[x][y - 1] % 10 == 1)))
                        {

                            if (CopyGrid[x][y-1] != 0)
                            {
                                childPath.Push(new int[] { x, y - 1 });
                            }
                        }
                        break;


                    case 6: ans = (isValid(x - 1, y) && (CopyGrid[x - 1][y] % 10 == 4 || CopyGrid[x - 1][y] % 10 == 3 || CopyGrid[x - 1][y] % 10 == 2))
                                   || (isValid(x, y + 1) && (CopyGrid[x][y + 1] % 10 == 5 || CopyGrid[x][y + 1] % 10 == 3 || CopyGrid[x][y + 1] % 10 == 1));

                        if ((isValid(x - 1, y) && (CopyGrid[x - 1][y] % 10 == 4 || CopyGrid[x - 1][y] % 10 == 3 || CopyGrid[x - 1][y] % 10 == 2)))
                        {
                            if (CopyGrid[x-1][y] != 0)
                            {
                                childPath.Push(new int[] { x - 1, y });
                            }
                        }

                        if ((isValid(x, y + 1) && (CopyGrid[x][y + 1] % 10 == 5 || CopyGrid[x][y + 1] % 10 == 3 || CopyGrid[x][y + 1] % 10 == 1)))
                        {
                            if (CopyGrid[x][y+1] != 0)
                            {
                                childPath.Push(new int[] { x, y + 1 });
                            }
                        }
                        break;
                }

                return ans;
            }


            public bool isValid(int x, int y)
            {
                bool ans = x >= 0 && y >= 0 && x < CopyGrid.Length && y < CopyGrid[0].Length;

                return ans;
            }
        }

    }
}
