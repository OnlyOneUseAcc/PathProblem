using System;
using System.Collections.Generic;

namespace PathProblem
{
    static class Dijkstra
    {
        const int INF = 2147483647;
        public static void findCoast(Graph graph, int firstV, int aimV)
        {
            if (firstV <= 0 || aimV <= 0)
            {
                Console.WriteLine("unexpexted edges");
                return;
            }
            firstV--;
            aimV--;
            
            int n = graph.g.Count;
            int[] coasts = new int[n];
            bool[] used = new bool[n];
            for (int i = 0; i < n; i++)
            {
                coasts[i] = INF;
                used[i] = false;
            }
            coasts[firstV] = 0;
            
            int[] parents = new int[n];

            for (int i = 0; i < n; i++)
            {
                int v = -1;
                for (int k = 0; k < n; k++)
                {
                    if (!used[k] && (v == -1 || coasts[k] < coasts[v]))
                    {
                        v = k;
                    }
                }
                if (coasts[v] == INF)
                {
                    break;
                }
                used[v] = true;
                for (int k = 0; k < graph.g[v].Count; k++)
                {
                    int to = graph.g[v][k].Item1;
                    int coast = graph.g[v][k].Item2;

                    if (coasts[v] + coast < coasts[to])
                    {
                        coasts[to] = coasts[v] + coast;
                        parents[to] = v;
                    }
                }
                
            }
            if (coasts[aimV] != INF)
            {
                Console.WriteLine("Path form " + (firstV + 1) + " to " + (aimV + 1) +
                    " will coast " + coasts[aimV]);
                List<int> path = new List<int>();
                for (int v = aimV; v != firstV; v = parents[v])
                {
                    path.Add(v + 1);
                }
                path.Add(firstV + 1);
                path.Reverse();
                Console.WriteLine("Path: ");
                for (int i = 0; i < path.Count; i++)
                {
                    Console.WriteLine("\t" + path[i]); 
                }
            } else
            {
                Console.WriteLine("There isn't path form " + (firstV + 1) + " to " + (aimV + 1));
            }
        }
    }
}
