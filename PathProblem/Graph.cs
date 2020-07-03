using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PathProblem
{
    class Graph
    {
        public List<List<Tuple<int, int>>> g { get; }

        public Graph()
        {
            this.g = new List<List<Tuple<int, int>>>();
        }

        public void Add(int v, Tuple<int, int> e, bool graphType)
        {
           if (g.Count <= Math.Max(v , e.Item1))
            {
                int count = g.Count;

                for (int i = 0; i < Math.Max(v, e.Item1) - count + 1; i++)
                {
                    g.Add(new List<Tuple<int, int>>());
                }
            }
            g[v].Add(e);
            
            if(!graphType)
            {
                g[e.Item1].Add(new Tuple<int, int>(v, e.Item2));
            } 
            
        }
    }
}
