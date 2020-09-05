using System.Collections.Generic;
using Prep.Tests.DataStructures;

//https://leetcode.com/problems/number-of-distinct-islands-ii/
namespace Prep.Tests.number_of_islands_hard
{
    public class Solution
    {
        public IList<int> NumIslands2(int m, int n, int[][] positions)
        {
            var directions = new List<(int, int)>(){(-1,0), (0,1), (1,0), (0,-1)};
            var uniqueCounts = new List<int>();
            //initialize set
            var ds=new SimpleDisjointSet();
            foreach (var position in positions)
            {
                var row = position[0];
                var column = position[1];

                //3 x 4. Row 1, column 2 = position 6
                // 0 1 2 3
                // 4 5 6 7
                var index = row * n + column;
                ds.AddSet(index);

                //Look in all directions for additional land, union
                foreach (var t in directions)
                {
                    var searchRow = row + t.Item1;
                    var searchColumn = column + t.Item2;
                    if (searchRow < 0 || searchRow >= m || searchColumn < 0 || searchColumn >= n)
                        continue;
                    var searchIndex = searchRow * n + searchColumn;
                    if (ds.SetExists(searchIndex))
                    {
                        ds.Union(index, searchIndex);
                    }
                }

                uniqueCounts.Add(ds.UniqueSets());
            }

            return uniqueCounts;

        }
         
    }

}
