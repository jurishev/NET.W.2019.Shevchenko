namespace NET.W2019.Shevchenko13.QueueTask
{
    /// <summary>
    /// Implements simple generic Queue data structure.
    /// Uses singly linked list to keep items inside.
    /// Allows its items to be iterated by foreach statement.
    /// </summary>
    /// <typeparam name="T">Type to store in the collection.</typeparam>
    public class Queue<T>
    {
        private Item head;
        private Item tail;

        private Item current;

        /// <summary>
        /// Gets value of the inner linked list's item the iterator cursor currently points to.
        /// </summary>
        /// <value>Current value from the inner linked list.</value>
        public T Current
        {
            get
            {
                if (this.current is null)
                {
                    return default;
                }

                return this.current.Value;
            }
        }

        /// <summary>
        /// Adds a value to the tail of the queue.
        /// </summary>
        /// <param name="value">Value to be added.</param>
        public void Enqueue(T value)
        {
            var item = new Item(value);

            if (this.head is null)
            {
                this.head = item;
                this.tail = item;
            }
            else
            {
                this.tail.Next = item;
                this.tail = item;
            }
        }

        /// <summary>
        /// Gets a value from the head of the queue and removes its container from the inner linked list.
        /// </summary>
        /// <returns>Head value of the queue.</returns>
        public T Dequeue()
        {
            if (this.head is null)
            {
                return default;
            }

            T value = this.head.Value;
            this.head = this.head.Next;

            this.Reset();

            return value;
        }

        /// <summary>
        /// Gets a value from the head of the queue without removing its container from the inner linked list.
        /// </summary>
        /// <returns>Head value of the queue.</returns>
        public T Peek()
        {
            if (this.head is null)
            {
                return default;
            }

            return this.head.Value;
        }

        /// <summary>
        /// Moves the iterator cursor to the next item of the inner linked list.
        /// </summary>
        /// <returns>
        /// True if a next item exists and the cursor has been moved.
        /// False if there is no next item.
        /// </returns>
        public bool MoveNext()
        {
            if (this.head is null)
            {
                return false;
            }

            if (this.current is null)
            {
                this.current = this.head;
                return true;
            }

            if (this.current.Next != null)
            {
                this.current = this.current.Next;
                return true;
            }

            this.Reset();

            return false;
        }

        /// <summary>
        /// Gets object for enumeration.
        /// </summary>
        /// <returns>Current instance.</returns>
        public Queue<T> GetEnumerator()
        {
            return this;
        }

        private void Reset()
        {
            this.current = null;
        }

        private class Item
        {
            public Item(T value)
            {
                this.Value = value;
            }

            public T Value { get; }

            public Item Next { get; set; }
        }
    }
}
