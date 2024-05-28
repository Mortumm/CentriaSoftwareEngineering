namespace Exercise001
{
    using System.Text;

    public class LinkedList
    {
        private Node head;
        private Node tail;
        private int count;

        public LinkedList()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public void AddFirst(int n)
        {
            Node newNode = new Node(n, head, null);
            if (head != null)
            {
                head.previous = newNode;
            }
            else
            {
                tail = newNode;
            }
            head = newNode;
            count++;
        }

        public void AddLast(int n)
        {
            Node newNode = new Node(n, null, tail);
            if (tail != null)
            {
                tail.next = newNode;
            }
            else
            {
                head = newNode;
            }
            tail = newNode;
            count++;
        }

        public void RemoveFirst()
        {
            if (head == null)
            {
                throw new NullReferenceException("Cannot remove from an empty list.");
            }

            if (head.next == null)
            {
                // Only one element in the list
                head = null;
                tail = null;
            }
            else
            {
                head = head.next;
                head.previous = null;
            }

            count--;
        }



        public void RemoveLast()
        {
            if (tail == null)
            {
                throw new NullReferenceException("Cannot remove from an empty list.");
            }

            tail = tail.previous;
            if (tail != null)
            {
                tail.next = null;
            }
            else
            {
                head = null;
            }
            count--;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Node current = head;
            while (current != null)
            {
                sb.Append(current.value).Append(' ');
                current = current.next;
            }
            return sb.ToString().Trim();
        }

        public int GetNode(int x)
        {
            if (x >= 0 && x < count)
            {
                Node current = head;
                for (int i = 0; i < x; i++)
                {
                    current = current.next;
                }
                return current.value;
            }
            return -1;
        }

        public int Count
        {
            get { return count; }
        }
    }
}
