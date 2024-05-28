namespace Exercise004;
using System;
using System.Collections.Generic;

public class Order
{
    public int[] Create(int[] a, int[] b)
    {
        Dictionary<int, int> indexMap = new Dictionary<int, int>();
        for (int i = 0; i < b.Length; i++)
        {
            indexMap[b[i]] = i;
        }

        List<int> PostOrder(int preStart, int preEnd, int inStart, int inEnd)
        {
            if (preStart > preEnd)
            {
                return new List<int>();
            }

            int rootValue = a[preStart];
            int rootIndexInOrder = indexMap[rootValue];

            List<int> leftSubtree = PostOrder(preStart + 1, preStart + rootIndexInOrder - inStart, inStart, rootIndexInOrder - 1);
            List<int> rightSubtree = PostOrder(preStart + rootIndexInOrder - inStart + 1, preEnd, rootIndexInOrder + 1, inEnd);

            List<int> postOrder = new List<int>();
            postOrder.AddRange(leftSubtree);
            postOrder.AddRange(rightSubtree);
            postOrder.Add(rootValue);

            return postOrder;
        }

        return PostOrder(0, a.Length - 1, 0, b.Length - 1).ToArray();
    }
}

