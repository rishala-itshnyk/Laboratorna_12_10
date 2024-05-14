using System;
using System.IO;

public class TreeNode
{
    public int Value { get; set; }
    public TreeNode Left { get; set; }
    public TreeNode Right { get; set; }

    public TreeNode(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}

public class BinaryTree
{
    private TreeNode root;

    public BinaryTree()
    {
        root = null;
    }

    public void AddNode(int value)
    {
        root = AddNodeRecursive(root, value);
    }

    private TreeNode AddNodeRecursive(TreeNode current, int value)
    {
        if (current == null)
        {
            return new TreeNode(value);
        }

        if (value < current.Value)
        {
            current.Left = AddNodeRecursive(current.Left, value);
        }
        else if (value > current.Value)
        {
            current.Right = AddNodeRecursive(current.Right, value);
        }

        return current;
    }

    public void Print()
    {
        PrintRecursive(root, 0);
    }

    private void PrintRecursive(TreeNode current, int level)
    {
        if (current != null)
        {
            PrintRecursive(current.Right, level + 1);
            Console.WriteLine(new string(' ', 4 * level) + current.Value);
            PrintRecursive(current.Left, level + 1);
        }
    }

    public int MaxDepth()
    {
        return MaxDepthRecursive(root);
    }

    private int MaxDepthRecursive(TreeNode node)
    {
        if (node == null)
        {
            return 0;
        }

        int leftDepth = MaxDepthRecursive(node.Left);
        int rightDepth = MaxDepthRecursive(node.Right);

        return Math.Max(leftDepth, rightDepth) + 1;
    }

    public void PrintPathToLeaves()
    {
        PrintPathToLeavesRecursive(root, "");
    }

    private void PrintPathToLeavesRecursive(TreeNode node, string path)
    {
        if (node != null)
        {
            if (node.Left == null && node.Right == null) // Якщо поточний вузол - листок
            {
                Console.WriteLine($"Path: {path} {node.Value}");
            }
            else
            {
                // Рекурсивно виводимо шлях до листків для лівого та правого піддерева
                PrintPathToLeavesRecursive(node.Left, path + " " + node.Value);
                PrintPathToLeavesRecursive(node.Right, path + " " + node.Value);
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        BinaryTree tree = new BinaryTree();
        string fileName = "tree_values.txt";

        try
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (int.TryParse(line, out int value))
                    {
                        tree.AddNode(value);
                    }
                    else
                    {
                        Console.WriteLine($"Invalid value in the file: {line}");
                    }
                }
            }

            Console.WriteLine("Tree printed:");
            tree.Print();

            int maxDepth = tree.MaxDepth();
            Console.WriteLine($"Maximum depth of the tree: {maxDepth}");

            tree.PrintPathToLeaves();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
