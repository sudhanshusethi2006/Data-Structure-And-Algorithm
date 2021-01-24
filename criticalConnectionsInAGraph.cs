using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{
    class criticalConnectionsInAGraph
    {

        static int time;

        static void Main(string[] args)
        {



            int n = 4;

            IList<IList<int>> connections = new List<IList<int>>() { new List<int> { 0, 1 }, new List<int> { 1, 2 }, new List<int> { 2, 0 }, new List<int> { 1, 3 } };

            var ans = CriticalConnections(n, connections);
        }



        public static IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
        {
            IList<IList<int>> Allbridges = new List<IList<int>>();


            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();


            foreach (List<int> connection in connections)
            {
                int node1 = connection[0];
                int node2 = connection[1];



                if (!graph.ContainsKey(node1))
                {

                    graph[node1] = new List<int>();

                }
                if (!graph.ContainsKey(node2))
                {
                    graph[node2] = new List<int>();
                }

                graph[node1].Add(node2);
                graph[node2].Add(node1);

            }

            int[] AllIds = new int[n];
            int[] lows = new int[n];

            AllIds = Enumerable.Repeat(-1, n).ToArray();

            for (int i = 0; i < n; i++)
            {
                if (AllIds[i] == -1)
                {
                    DFS(i, i, AllIds, lows, graph, Allbridges);
                }
            }

            return Allbridges;

        }

        private static void DFS(int child, int parent, int[] Allids, int[] lows, Dictionary<int, List<int>> graph, IList<IList<int>> bridges)
        {
            Allids[child] = time;
            lows[child] = time;

            time++;

            for (int i = 0; i < graph[child].Count(); i++)
            {
                int v = graph[child][i];

                if (v == parent) continue;

                if (Allids[v] == -1)
                {
                    DFS(v, child, Allids, lows, graph, bridges);
                    lows[child] = Math.Min(lows[child], lows[v]);


                    if (lows[v] > Allids[child])
                    {
                        bridges.Add(new List<int> { child, v });
                    }
                }

                else
                {
                    lows[child] = Math.Min(lows[child], Allids[v]);
                }
            }

        }




    }




}
