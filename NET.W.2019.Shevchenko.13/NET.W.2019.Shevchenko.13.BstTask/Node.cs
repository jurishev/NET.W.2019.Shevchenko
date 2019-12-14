namespace NET.W2019.Shevchenko13.BstTask
{
    /// <summary>
    /// Represents a <see cref="BinarySearchTree{T}"/> node.
    /// </summary>
    /// <typeparam name="T">Type of values the node can contain.</typeparam>
    internal class Node<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Node{T}"/> class.
        /// </summary>
        /// <param name="value">Value to contain in the node.</param>
        public Node(T value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets or sets the value the node currently contains.
        /// </summary>
        /// <value>The value the node currently contains.</value>
        public T Value { get; set; }

        /// <summary>
        /// Gets or sets a reference to the parent node.
        /// </summary>
        /// <value>A reference to a parent node.</value>
        public Node<T> Parent { get; set; }

        /// <summary>
        /// Gets or sets a reference to the left node.
        /// </summary>
        /// <value>A reference to the left node.</value>
        public Node<T> Left { get; set; }

        /// <summary>
        /// Gets or sets a reference to the right node.
        /// </summary>
        /// <value>A reference to the right node.</value>
        public Node<T> Right { get; set; }
    }
}
