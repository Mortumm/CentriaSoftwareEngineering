public class BinarySearchTree
{
    private TreeNode root;

    public void Add(int x)
    {
        if (root == null)
        {
            root = new TreeNode(x);
        }
        else
        {
            root.AddChild(x);
        }
    }

    public int Height()
    {
        return root != null ? root.GetHeight() : 0;
    }
}