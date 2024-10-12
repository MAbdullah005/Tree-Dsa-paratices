using System;
using System.Collections.Generic;
namespace Binary_tree
{
    public class binayTree
    {
        private class Node
        {
            public int value;
            public Node left;
            public Node right;
            public Node()
            {

            }
            public Node(int val)
            {
                this.value = val;
                this.left = null!;
                this.right = null!;
            }
        }
        private Node root = new Node();
        private int size = 0;
        private int size1 = 0;
        private int count = 0;
        bool c = true;
        public binayTree()
        {
            root = null!;
        }
        public void Brest_fist()
        {
            if (root == null)
            {
                return;
            }
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Node currentNode = queue.Dequeue();
                Console.Write(currentNode.value + " ");

                if (currentNode.left != null)
                {
                    queue.Enqueue(currentNode.left);
                }
                if (currentNode.right != null)
                {
                    queue.Enqueue(currentNode.right);
                }
            }
        }
        public void Depth_preorder()
        {
            Stack<Node> stack_L = new Stack<Node>();
            stack_L.Push(root);
            var current = new Node();
            var current1 = new Node();
            current = root;
            while (stack_L.Count > 0)
            {
                if (current.left != null)
                {
                    stack_L.Push(current.left);
                    current = current.left;
                }
                else
                {
                    current1 = stack_L.Pop();
                    Console.WriteLine(current1.value);
                    if (current1.right != null)
                    {
                        stack_L.Push(current1.right);
                    }

                }
            }
        }
        public void insert(int val)
        {
            var node = new Node(val);
            if (root == null)
            {
                root = node;
            }
            else
            {
                var current = root;
                while (true)
                {
                    if (current.value > node.value)
                    {
                        if (current.left == null)
                        {
                            current.left = node;
                            break;
                        }
                        current = current.left;
                    }
                    else
                    {
                        if (current.right == null)
                        {
                            current.right = node;
                            break;
                        }
                        current = current.right;
                    }
                }

            }
            size++;
        }
        public void depth_pre()
        {
            Console.WriteLine(' ');
            depth_pre(root);
        }
        private void depth_pre(Node n)
        {
            if (n == null)
            { return; }
            Console.Write(n.value + " ");
            depth_pre(n.left);
            depth_pre(n.right);
        }
        public void depth_in()
        {
            Console.WriteLine(' ');
            depth_in(root);
        }
        private void depth_in(Node n)
        {
            if (n == null)
            { return; }
            depth_in(n.left);
            Console.Write(n.value + " ");
            depth_in(n.right);
        }
        public void depth_post()
        {
            Console.WriteLine(' ');
            depth_post(root);
        }
        private void depth_post(Node n)
        {
            if (n == null)
            { return; }
            depth_post(n.left);
            depth_post(n.right);
            Console.Write(n.value + " ");
        }
        public int Hight()
        {
            return Hight(root);
        }
        private int Hight(Node n)
        {
            if (n == null)
            {
                return -1;
            }
            if (n.left == null && n.right == null)
            { return 0; }
            return 1 + Math.Max(Hight(n.left!), Hight(n.right));
        }
        public bool find(int val)
        {
            var current = root;
            while (current != null)
            {
                if (current.value == val)
                {
                    return true;
                }
                else if (current.value > val)
                {
                    current = current.left;
                }
                else
                {
                    current = current.right;
                }
            }
            return false;
        }
        public int minval()
        {
            if (root == null)
            {
                return -1;
            }
            return Min_binarry(root);
        }
        private int minval(Node n)
        {
            if (n.left == null)
            { return n.value; }
            return minval(n.left);
        }
        public int max_val()
        {
            return max_val(root);
        }
        private int max_val(Node n)
        {
            if (n.right == null)
            {
                return n.value;
            }
            return max_val(n.right);
        }
        private int Min_binarry(Node n)
        {
            if (n.left == null || n.right == null)
            {
                return n.value;
            }
            var left = Min_binarry(n.left!);
            var right = Min_binarry(n.right);
            return Math.Min(Math.Min(left, right), n.value);
        }
        public bool equall(binayTree tree)
        {
            return equall(root, tree.root);
        }
        private bool equall(Node fist, Node second)
        {
            if (fist == null && second == null)
            { return true; }
            if (fist == null || second == null)
            {
                return false;
            }
            if (fist!.value == second!.value)
            {

                return equall(fist.left, second.left) && equall(fist.right, second.right);
            }
            return false;
        }
        public void swap_node()
        {
            var temp = root.left;
            root.left = root.right;
            root.right = temp;
        }
        public bool Binnary_tree()
        {
            return Binnary_tree(root, int.MinValue, int.MaxValue);
        }
        private bool Binnary_tree(Node n, int min, int max)
        {
            if (n == null)
            {
                return true;
            }
            if (n.value < min || n.value > max)
            {
                return false;
            }
            return Binnary_tree(n.left, min, n.value - 1)
                   && Binnary_tree(n.right, n.value + 1, max);
        }
        public List<int> node_kth(int n)
        {
            List<int> array = new List<int>();
            node_kth(root, n, array);
            return array;
        }
        private void node_kth(Node n, int distance, List<int> array)
        {
            if (n == null)
            {
                return;
            }
            if (distance == 0)
            {
                array.Add(n.value);
                return;
            }
            node_kth(n.left, distance - 1, array);
            node_kth(n.right, distance - 1, array);
        }
        public void tarverse_levelorder()
        {
            Console.WriteLine("\n");
            for (int i = 0; i <= Hight(); i++)
            {
                foreach (var value in node_kth(i))
                {
                    Console.Write(value + " ");
                }
            }
        }
        public int tree_size()
        {
            return tree_size(root);
        }
        private int tree_size(Node n)
        {
            if (n == null)
            {
                return size1;
            }
            if (n.left != null || n.right != null)
            {
                size1++;
            }
            tree_size(n.left!);
            tree_size(n.right!);
            return size1;
        }
        public int count_leave()
        {
            return count_leave(root);
        }
        private int count_leave(Node n)
        {
            if (n == null)
            {
                return count;
            }
            if (n.left != null && n.right != null)
            {
                count++;
            }
            count_leave(n.left!);
            count_leave(n.right!);
            return count;
        }
        public bool contain(int val)
        {
            return contain(root, val);
        }
        private bool contain(Node n, int val)
        {
            if (n == null)
            {
                return false;
            }
            if (n.value == val)
            {
                return true;
            }
            return contain(n.left!, val)
             || contain(n.right!, val);
        }
        public int issibling(int val)
        {
            count = 0;
            return issibling(root, val);
        }
        private int issibling(Node n, int val)
        {
            if (n == null)
            {
                return -1;
            }
            if (n.value == val)
            {
                Console.WriteLine("done");
                count++;

            }
            issibling(n.left!, val);
            issibling(n.right!, val);
            return count;
        }
        public List<int> ansestor(int val)
        {
            List<int> ans = new List<int>();
            ansestor(root, val, ans);
            return ans;
        }
        private List<int> ansestor(Node n, int val, List<int> ans)
        {
            if (n == null)
            {
                return ans;
            }
            if (n.value <= val)
            {
                ans.Add(n.value);
            }
            ansestor(n.left!, val, ans);
            ansestor(n.right!, val, ans);
            return ans;
        }
    }
    public class tree
    {
        static void Main(string[] args)
        {
            binayTree tree = new binayTree();
            tree.insert(20);
            tree.insert(10);
            tree.insert(30);
            tree.insert(6);
            tree.insert(14);
            tree.insert(24);
            tree.insert(3);
            tree.insert(8);
            tree.insert(26);
            tree.insert(23);
            tree.insert(23);
            tree.insert(23);
            foreach (var item in tree.ansestor(20))
            {
                Console.WriteLine(item);
            }
        }
    }
}

