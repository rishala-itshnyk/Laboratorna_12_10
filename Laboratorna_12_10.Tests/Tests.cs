namespace Laboratorna_12_10.Tests;

public class Tests
{
    [Test]
    public void TestAddNodeAndPrint()
    {
        BinaryTree tree = new BinaryTree();
        tree.AddNode(5);
        tree.AddNode(3);
        tree.AddNode(8);
        tree.AddNode(1);
        tree.AddNode(4);
        tree.AddNode(7);
        tree.AddNode(9);

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            tree.Print();

            string expected =
                "        9" + Environment.NewLine +
                "    8" + Environment.NewLine +
                "        7" + Environment.NewLine +
                "5" + Environment.NewLine +
                "        4" + Environment.NewLine +
                "    3" + Environment.NewLine +
                "        1" + Environment.NewLine;

            Assert.AreEqual(expected, sw.ToString());
        }
    }

    [Test]
    public void TestMaxDepth()
    {
        BinaryTree tree = new BinaryTree();
        tree.AddNode(5);
        tree.AddNode(3);
        tree.AddNode(8);
        tree.AddNode(1);
        tree.AddNode(4);
        tree.AddNode(7);
        tree.AddNode(9);

        Assert.AreEqual(3, tree.MaxDepth());
    }
}