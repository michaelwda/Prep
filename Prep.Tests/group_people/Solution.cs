using System;
using System.Collections.Generic;
using System.Text;

namespace Prep.Tests.group_people
{
    public class Solution
    {
        public IList<IList<int>> GroupThePeople(int[] groupSizes)
        {
            IList<IList<int>> results = new List<IList<int>>();
            var groups = new Dictionary<int, List<int>>();
            for (var i = 0; i < groupSizes.Length; i++)
            {
                if (groupSizes[i] == 1)
                {
                    results.Add(new List<int>() { i });
                }
                else
                {
                    if (!groups.ContainsKey(groupSizes[i]))
                    {
                        groups.Add(groupSizes[i], new List<int>() { i });
                    }
                    else
                    {
                        groups[groupSizes[i]].Add(i);
                        if (groups[groupSizes[i]].Count == groupSizes[i])
                        {
                            results.Add(groups[groupSizes[i]]);
                            groups[groupSizes[i]] = new List<int>();
                        }
                    }
                }
            }
            return results;
        }
    }


    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}