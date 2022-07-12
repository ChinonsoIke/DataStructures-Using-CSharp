using System;

namespace LinkedList
{
    public class SingleLinkedList<T>
    {
        #region Node Class
        public class ListNode
        {
            public T Data { get; set; }
            public ListNode Next { get; set; }

            public ListNode(T data)
            {
                Data = data;
                Next = null;
            }
        }
        #endregion

        public ListNode Head { get; set; }
        public ListNode Tail { get; set; } 
        public int Count;

        #region Constructors
        /// <summary>
        /// Creates an empty linked list
        /// </summary>
        public SingleLinkedList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        /// <summary>
        /// Creates a linked list and populates it with items
        /// </summary>
        /// <param name="items">an array of values to be stored as node data</param>
        public SingleLinkedList(T[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                Add(items[i]);
            }
        }
        #endregion

        #region Indexer
        /// <summary>
        /// Enables accessing nodes in the linked list using an index
        /// </summary>
        /// <param name="index">Index position of node to return</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public ListNode this[int index]
        {
            get
            {
                if (index >= Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                var currentNode = Head;
                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next;
                }
                return currentNode;
            }
            set
            {
                if (index >= Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                var currentNode = Head;
                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Data = value.Data;
            }
        }
        #endregion

        #region LinkedList Methods
        /// <summary>
        /// Adds a node at the end of the list
        /// </summary>
        /// <param name="item">Value to stored as node data</param>
        /// <returns>The count of the linked list</returns>
        public int Add(T item)
        {
            // 1st case: list is empty
            if (Head == null)
            {
                Head = new ListNode(item);
                Tail = Head;
            }
            else
            {
                // 2nd case: list is not empty
                ListNode newNode = new ListNode(item);
                Tail.Next = newNode;
                Tail = newNode;
            }

            Count++;
            return Count;
        }

        /// <summary>
        /// Removes a node from the linked list
        /// </summary>
        /// <param name="item">Data property of the target node</param>
        /// <returns>returns a boolean value</returns>
        public bool Remove(T item)
        {
            // make sure list is not empty
            if (Head != null)
            {
                var currentNode = Head;
                ListNode previousNode = null;

                while (currentNode != null)
                {
                    if (object.Equals(currentNode.Data, item))
                    {
                        if (previousNode != null)
                        {
                            previousNode.Next = currentNode.Next;
                        }
                        else
                        {
                            Head = null;
                            Tail = null;
                        }

                        Count--;
                        return true;
                    }
                    previousNode = currentNode;
                    currentNode = currentNode.Next;
                }
            }

            return false;
        }

        /// <summary>
        /// Removes the last node of the linked list
        /// </summary>
        public void RemoveLast()
        {
            if (Count == 1)
            {
                Head = null;
                Tail = null;
                Count--;
            }
            else
            {
                Tail = this[Count - 2];
                Tail.Next = null;
                Count--;
            }
        }

        /// <summary>
        /// Removes the first node of the linked list
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void RemoveFirst()
        {
            if(Head != null)
            {
                if (Count == 1)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    Head = Head.Next;
                }
                Count--;
            }
            else
            {
                throw new Exception("List is empty");
            }
        }

        /// <summary>
        /// Checks if an node is present in the linked lsit
        /// </summary>
        /// <param name="item">Data property of target node</param>
        /// <returns></returns>
        public bool Check(T item)
        {
            return IndexOf(item) != -1;
        }

        /// <summary>
        /// Determines the index of a node in the linked list
        /// </summary>
        /// <param name="item">Data property of the target node</param>
        /// <returns>The index of the target node or -1 if target node is not found</returns>
        public int IndexOf(T item)
        {
            // make sure list is not empty
            if (Head != null)
            {
                int currentIndex = 0;
                var currentNode = Head;

                while (currentNode != null)
                {
                    if (object.Equals(currentNode.Data, item))
                    {
                        return currentIndex;
                    }
                    currentNode = currentNode.Next;
                    currentIndex++;
                }
            }

            return -1;
        }
#endregion
    }
}
