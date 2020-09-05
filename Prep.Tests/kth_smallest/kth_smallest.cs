using Prep.Tests.group_people;

namespace Prep.Tests.kth_smallest
{
    //https://leetcode.com/problems/kth-smallest-element-in-a-bst/submissions/
    //I bet we could use a FIFO queue here and eliminate all the recursion
    public class Solution
    {
        public int KthSmallest(TreeNode root, int k)
        {
            j = k;
            InOrder(root);
            return answer;
        }

        private int answer=-1;
        private int j;
        public void InOrder(TreeNode root)
        {
            if (root == null)
                return;
            if (answer > -1)
                return;

            InOrder(root.left);
            j--;
            if (j == 0)
            {
                answer = root.val;
                return;
            }
 
            InOrder(root.right);

        }
    }

   

}
