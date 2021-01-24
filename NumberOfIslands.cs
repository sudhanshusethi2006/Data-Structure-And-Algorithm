using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{
    class NumberOfIslands
    {
        public int NumIslands(char[][] grid)
        {
            if (grid == null || grid.Length == 0)
                return 0;
            int numIslands = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    // we have found an island
                    if (grid[i][j] == '1')
                    {
                        // check neighbours to find # of 1s that are part of this island
                        numIslands += DepthFirstSearch(grid, i, j);
                    }
                }
            }

            return numIslands;
        }

    

        private int DepthFirstSearch(char[][] grid, int i, int j)
        {
            // if i and j are out of bound or grid i,j represent water or grid i,j  is already visited
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || grid[i][j] == '0' || grid[i][j] == 'v')
            {
                return 0;
            }

            // mark this point visited. Using 'v 'to mark visited
            grid[i][j] = 'v';

            // check neighbours up,down,left and right in matrix. Method will mark neighbours visited if grid[i][j] are one i.e. they are also part of this island.
            DepthFirstSearch(grid, i - 1, j);
            DepthFirstSearch(grid, i + 1, j);
            DepthFirstSearch(grid, i, j - 1);
            DepthFirstSearch(grid, i, j + 1);

            return 1;

        }



    }
}
