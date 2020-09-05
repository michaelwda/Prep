using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prep.Tests.group_people;

namespace Prep.Tests.kth_smallest
{
    [TestClass]
    public class KthSmallest
    {
        private readonly Solution _solution = new Solution();
        
        [TestMethod]
        public void Example1()
        {
            TreeNode root=new TreeNode(3);
            root.right=new TreeNode(4);
            root.left=new TreeNode(1);
            root.left.right=new TreeNode(2);
            var result = _solution.KthSmallest(root,1);

            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void Example2()
        {
            TreeNode root = new TreeNode(5);
            root.right = new TreeNode(6);
            root.left = new TreeNode(3);
            root.left.right = new TreeNode(4);
            root.left.left = new TreeNode(2);
            root.left.left.left= new TreeNode(1);
            var result = _solution.KthSmallest(root, 3);

            Assert.AreEqual(3, result);
        }


    }
}
