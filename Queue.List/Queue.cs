using System;

using LinkedList;

namespace Queue.List
{
    public class Queue<T>
    {
        private SingleLinkedList<T> _queue;

        #region Constructors
        /// <summary>
        /// Creates an empty queue
        /// </summary>
        public Queue()
        {
            _queue = new SingleLinkedList<T>();
        }

        /// <summary>
        /// Creates a queue and populates it with items
        /// </summary>
        /// <param name="items">An array of items to insert into the queue</param>
        public Queue(T[] items)
        {
            _queue = new SingleLinkedList<T>(items);
        }
        #endregion


        #region Queue Methods
        /// <summary>
        /// Determines the size of the queue
        /// </summary>
        /// <returns>An integer value representing the size of the queue</returns>
        public int Size()
        {
            return _queue.Count;
        }

        /// <summary>
        /// Determines whether the queue is empty or not
        /// </summary>
        /// <returns>A boolean value indicating whether the string </returns>
        public bool IsEmpty()
        {
            return Size() == 0;
        }

        /// <summary>
        /// Adds an item at the end of the queue
        /// </summary>
        /// <param name="item">Data property of node to be added</param>
        public void Enqueue(T item)
        {
            _queue.Add(item);
        }

        /// <summary>
        /// Removes and returns the first item on the queue
        /// </summary>
        /// <returns>The data property of the first node on the queue</returns>
        /// <exception cref="Exception"></exception>
        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new Exception("Cannot remove from empty queue");
            }
            var first = _queue.Head;
            _queue.RemoveFirst();

            return first.Data;
        }
        #endregion
    }
}
