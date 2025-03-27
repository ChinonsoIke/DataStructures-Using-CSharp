using System;
using LinkedList;

namespace Stack
{
    public class Stack<T>
    {
        private SingleLinkedList<T> _stack;

        #region Constructors
        /// <summary>
        /// Creates an empty stack
        /// </summary>
        public Stack()
        {
            _stack = new SingleLinkedList<T>();
        }

        /// <summary>
        /// Creates a stack and populates it with items
        /// </summary>
        /// <param name="items">An array of values to be stored in the data property of the items on the stack</param>
        public Stack(T[] items)
        {
            _stack = new SingleLinkedList<T>(items);
        }
        #endregion

        #region Stack Methods
        /// <summary>
        /// Checks if the stack is empty or not
        /// </summary>
        /// <returns>A boolean value indicating whether the stack is empty or not</returns>
        public bool IsEmpty()
        {
            return Size() == 0;
        }

        /// <summary>
        /// Adds an item to the top of the stack
        /// </summary>
        /// <param name="item">Value to be stored in the data property of the stack item</param>
        public void Push(T item)
        {
            _stack.Add(item);
        }

        /// <summary>
        /// Determines the size of the stack
        /// </summary>
        /// <returns>An integer value representing the size of the stack</returns>
        public int Size()
        {
            return _stack.Count;
        }

        /// <summary>
        /// Gets the top item on the stack
        /// </summary>
        /// <returns>The data property of the top item on the stack</returns>
        public T Peek()
        {
            return _stack.Tail.Data;
        }

        /// <summary>
        /// Removes and returns the top item on the stack
        /// </summary>
        /// <returns>The data property of the top item on the stack</returns>
        /// <exception cref="Exception"></exception>
        public T Pop()
        {
            if (IsEmpty())
            {
                throw new Exception("Stack is empty");
            }

            var tail = _stack.Tail;
            _stack.RemoveLast();

            return tail.Data;
        }
        #endregion
    }
}
