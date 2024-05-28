public class TreeNode
{
  public TreeNode leftChild;
  public TreeNode rightChild;
  private int value;

  public TreeNode(int value)
  {
    this.leftChild = null;
    this.rightChild = null;
    this.value = value;
  }

  public void AddChild(int x)
  {
    if (x < value)
    {
      if (leftChild == null)
      {
        leftChild = new TreeNode(x);
      }
      else
      {
        leftChild.AddChild(x);
      }
    }
    else if (x > value)
    {
      if (rightChild == null)
      {
        rightChild = new TreeNode(x);
      }
      else
      {
        rightChild.AddChild(x);
      }
    }
  }

  public int GetHeight()
  {
    int leftHeight = (leftChild != null) ? leftChild.GetHeight() + 1 : 0;
    int rightHeight = (rightChild != null) ? rightChild.GetHeight() + 1 : 0;
    return Math.Max(leftHeight, rightHeight);
  }
}