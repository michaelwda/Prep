using System.Collections.Generic;

namespace Prep.Tests.DataStructures
{
    public class SimpleDisjointSet
    {
        private readonly List<int> _disjointSet= new List<int>();
        private readonly Dictionary<int, int> _bijection=new Dictionary<int, int>();
        private int _count = 0;
        public bool SetExists(int x)
        {
            return _bijection.ContainsKey(x);
        }
        public void AddSet(int x)
        {
            if (_bijection.ContainsKey(x))
                return;
            var max = _disjointSet.Count;
            _bijection.Add(x, max);
            _disjointSet.Add(max);
            _count++;
        }

        //Union two indexes
        public void Union(int x, int y)
        {
            //use the bijection to look up the value, then find the root array index
            var xRoot = FindRoot(_bijection[x]);
            var yRoot = FindRoot(_bijection[y]);

            if (xRoot == yRoot)
                return;

            //Merge y into this one
            _disjointSet[yRoot] = xRoot;
            _count--;
        }

        private int FindRoot(int index)
        {
            //Find Root
            var root = index;
            while (_disjointSet[root] != root)
            {
                root = _disjointSet[root];
            }

            //Walk tree again and repoint nodes to root - path compression
            while (_disjointSet[index] != root)
            {
                //Store the parent
                var parent = _disjointSet[index];
                //Point child directly to the root node
                _disjointSet[index] = root;
                //Continue upwards
                index = parent;
            }


            return root;
        }

        public int UniqueSets()
        {
           return _count;
        }
    }
}
