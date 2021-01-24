using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{
    class OrangeRotten
    {
        static void Main(string[] args)
        {
            //int[][] grid = new int[][] { new int[] { 2, 1, 1 }, new int[] { 1, 1, 0 }, new int[] { 0, 1, 1 } };
            int[][] grid = new int[][] { new int[] {1,1,2}, new int[] {0,2,0} };
            int ans = OrangesRotting(grid);
        }


        public static int OrangesRotting(int[][] grid)
        {


            bool[][] visited = new bool[grid.Length][];
            for (int i = 0; i < visited.Length; i++)
            {
                visited[i] = new bool[grid[0].Length];
            }

            Queue<int[]> myqueue = new Queue<int[]>();

            for (int i = 0; i < grid.Length; i++)
            {

                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 2)
                    {
                        myqueue.Enqueue(new int[] { i, j });
                        visited[i][j] = true;
                    }

                }
            }

            int mins = 0;
            while (myqueue.Count > 0)
            {
        



                Queue<int[]> temp = getRottenOrange(grid, visited, myqueue);
                if (temp.Count > 0)
                {
                    mins++;
                }

                foreach (int[] arr in temp)
                {
                    myqueue.Enqueue(arr);
                }

            }

            for (int i = 0; i < grid.Length; i++)
            {

                for (int j = 0; j < grid[0].Length; j++)
                {

                    if (grid[i][j] == 1)

                        return -1;
                }
            }

            return mins;


        }

        //public static int OrangesRotting(int[][] grid)
        //{

        //    bool[][] visited = new bool[grid.Length][];
        //    for (int i = 0; i < visited.Length; i++)
        //    {
        //        visited[i] = new bool[grid[0].Length];
        //    }

        //    int mins = 0;
        //    for (int i = 0; i < grid.Length; i++)
        //    {

        //        for (int j = 0; j < grid[0].Length; j++)
        //        {

        //            if (grid[i][j] == 0 || grid[i][j] == 1) continue;

        //            // if(getRottenOrange(i,j,grid,visited)){
        //            //     mins++;
        //            // }

        //            mins += totalSeconds(i, j, grid, visited);
        //        }
        //    }

        //    for (int i = 0; i < grid.Length; i++)
        //    {

        //        for (int j = 0; j < grid[0].Length; j++)
        //        {

        //            if (grid[i][j] == 1)

        //                return -1;
        //        }
        //    }
        //    return mins;

        //}

        //private static int totalSeconds(int i, int j, int[][] grid, bool[][] visited)
        //{

        //    Stack<int[]> myqueue = new Stack<int[]>();
        //    int seconds = 0;
        //    myqueue.Enqueue(new int[] { i, j });
        //    while (myqueue.Count > 0)
        //    {
        //        int[] a = myqueue.Pop();
        //        i = a[0];
        //        j = a[1];

        //        if (grid[i][j] == 2)
        //        {
        //            Stack<int[]> temp = getRottenOrange(i, j, grid, visited);
        //            if (temp.Count > 0) seconds++;
        //            foreach (int[] arr in temp)
        //            {
        //                myqueue.Enqueue(arr);
        //            }

        //        }

        //    }
        //    return seconds;
        //}

        private static Queue<int[]> getRottenOrange(int[][] grid, bool[][] visited, Queue<int[]> currQueue)
        {
            Queue<int[]> myqueue = new Queue<int[]>();
            while (currQueue.Count > 0)
            {
                int[] arr = currQueue.Dequeue();
                int i = arr[0];
                int j = arr[1];



                //bool isRotten = false;
                visited[i][j] = true;
                if (i > 0 && grid[i - 1][j] == 1 && !visited[i - 1][j])
                {
                    grid[i - 1][j] = 2;
                    visited[i - 1][j] = true;
                    //  isRotten = true;
                    myqueue.Enqueue(new int[] { i - 1, j });
                }

                if (i < grid.Length - 1 && grid[i + 1][j] == 1 && !visited[i + 1][j])
                {
                    grid[i + 1][j] = 2;
                    visited[i + 1][j] = true;
                    //   isRotten = true;
                    myqueue.Enqueue(new int[] { i + 1, j });
                }
                if (j > 0 && grid[i][j - 1] == 1 && !visited[i][j - 1])
                {
                    grid[i][j - 1] = 2;
                    visited[i][j - 1] = true;
                    //    isRotten = true;
                    myqueue.Enqueue(new int[] { i, j - 1 });
                }

                if (j < grid[0].Length - 1 && grid[i][j + 1] == 1 && !visited[i][j + 1])
                {
                    grid[i][j + 1] = 2;
                    visited[i][j + 1] = true;
                    //   isRotten = true;
                    myqueue.Enqueue(new int[] { i, j + 1 });
                }
            }
            return myqueue;
        }



    }
}
