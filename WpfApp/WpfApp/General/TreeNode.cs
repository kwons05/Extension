using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.General
{
    public class TreeNode<T>
    {
        List<TreeNode<T>> Children = new List<TreeNode<T>>();

        T Item { get; set; }

        public TreeNode(T item)
        {
            Item = item;
        }

        public TreeNode<T> AddChild(T item)
        {
            TreeNode<T> nodeItem = new TreeNode<T>(item);
            Children.Add(nodeItem);
            return nodeItem;
        }
    }

    public static class Test
    {
        public static void Run()
        {
            string root = "root";
            TreeNode<string> myTreeRoot = new TreeNode<string>(root);
            var first = myTreeRoot.AddChild("first child");
            var second = myTreeRoot.AddChild("second child");
            var grandChild = first.AddChild("first child's child");
        }
    }
}
