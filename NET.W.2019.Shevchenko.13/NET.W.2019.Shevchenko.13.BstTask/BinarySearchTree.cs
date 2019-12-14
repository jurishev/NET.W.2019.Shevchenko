using System;
using System.Collections.Generic;

namespace NET.W2019.Shevchenko13.BstTask
{
    /// <summary>
    /// Implements Binary Search Tree data structure.
    /// May contain several copies of a value.
    /// </summary>
    /// <typeparam name="T">Type of values to be stored in the BST instance.</typeparam>
    public class BinarySearchTree<T>
    {
        private readonly Func<T, T, int> delegateComparer;
        private readonly IComparer<T> interfaceComparer;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// Uses the type's default comparer to compare values.
        /// If type of values to contain has no default comparer a custom comparer must be provided.
        /// </summary>
        public BinarySearchTree()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        /// <param name="comparer">Provides a method to compare values.</param>
        public BinarySearchTree(Func<T, T, int> comparer)
        {
            if (comparer is null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            this.delegateComparer = comparer;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        /// <param name="comparer">Accepts a comparer through the interface.</param>
        public BinarySearchTree(IComparer<T> comparer)
        {
            if (comparer is null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            this.interfaceComparer = comparer;
        }

        /// <summary>
        /// Gets overall number of nodes in the current BST instance.
        /// </summary>
        /// <value>Overall number of nodes in the current BST instance.</value>
        public int Count { get; private set; }

        private Node<T> Root { get; set; }

        /// <summary>
        /// Checks if the current BST contains the provided value.
        /// If value has several copies the search stop at first occurence.
        /// </summary>
        /// <param name="value">Value to look for.</param>
        /// <returns>true or false depending on the search result.</returns>
        public bool Contains(T value)
        {
            if (this.FindNode(this.Root, value) is null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gets smallest value in the current BST.
        /// </summary>
        /// <returns>The smallest value in the BST.</returns>
        public T GetMinValue()
        {
            if (this.Root is null)
            {
                return default;
            }

            return this.GetMin(this.Root);
        }

        /// <summary>
        /// Gets largest value in the current BST.
        /// </summary>
        /// <returns>The largest value in the BST.</returns>
        public T GetMaxValue()
        {
            if (this.Root is null)
            {
                return default;
            }

            return this.GetMax(this.Root);
        }

        /// <summary>
        /// Gets collection of the current BST values in preorder sequence.
        /// </summary>
        /// <returns>Collection of the current BST values.</returns>
        public IEnumerable<T> GetValuesPreorder()
        {
            return this.Preorder(this.Root);
        }

        /// <summary>
        /// Gets collection of the current BST values in inorder sequence.
        /// </summary>
        /// <returns>Collection of the current BST values.</returns>
        public IEnumerable<T> GetValuesInorder()
        {
            return this.Inorder(this.Root);
        }

        /// <summary>
        /// Gets collection of the current BST values in postorder sequence.
        /// </summary>
        /// <returns>Collection of the current BST values.</returns>
        public IEnumerable<T> GetValuesPostorder()
        {
            return this.Postorder(this.Root);
        }

        /// <summary>
        /// Inserts provided value into the current BST.
        /// If the value is greater than root's value it goes right.
        /// If the value is less or equals the root's value it goes left.
        /// </summary>
        /// <param name="value">Value to insert.</param>
        public void Insert(T value)
        {
            if (this.Root is null)
            {
                this.Root = new Node<T>(value);
                this.Count++;
            }
            else
            {
                this.InsertNode(this.Root, value);
            }
        }

        /// <summary>
        /// Removes provided value from the current BST.
        /// </summary>
        /// <param name="value">Value to remove.</param>
        /// <returns>
        /// True if the value has been found and removed.
        /// False if the value has not been found.
        /// </returns>
        public bool Remove(T value)
        {
            var toRemove = this.FindNode(this.Root, value);

            if (toRemove is null)
            {
                return false;
            }

            var parent = toRemove.Parent;

            if (toRemove.Left is null && toRemove.Right is null)
            {
                // Case #1: no subtrees
                if (parent is null)
                {
                    this.Root = null;
                }
                else if (this.CompareValues(toRemove.Value, parent.Value) <= 0)
                {
                    parent.Left = null;
                }
                else
                {
                    parent.Right = null;
                }
            }
            else if (toRemove.Left is null && toRemove.Right != null)
            {
                // Case #2: no left subtree
                if (parent is null)
                {
                    this.Root = this.Root.Right;
                    this.Root.Parent = null;
                }
                else
                {
                    if (this.CompareValues(toRemove.Value, parent.Value) <= 0)
                    {
                        parent.Left = toRemove.Right;
                    }
                    else
                    {
                        parent.Right = toRemove.Right;
                    }

                    toRemove.Right.Parent = parent;
                }
            }
            else if (toRemove.Left != null && toRemove.Right is null)
            {
                // Case #3: no right subtree
                if (parent is null)
                {
                    this.Root = this.Root.Left;
                    this.Root.Parent = null;
                }
                else
                {
                    if (this.CompareValues(toRemove.Value, parent.Value) <= 0)
                    {
                        parent.Left = toRemove.Left;
                    }
                    else
                    {
                        parent.Right = toRemove.Left;
                    }

                    toRemove.Left.Parent = parent;
                }
            }
            else
            {
                // Case #4: two subtrees
                var toPromote = toRemove.Left;

                // Find the largest value in the left subtree of toRemove
                while (toPromote.Right != null)
                {
                    toPromote = toPromote.Right;
                }

                // Get rid of the value donor node and keep the left tail if it exists
                if (toPromote.Left is null)
                {
                    if (this.CompareValues(toPromote.Value, toPromote.Parent.Value) <= 0)
                    {
                        toPromote.Parent.Left = null;
                    }
                    else
                    {
                        toPromote.Parent.Right = null;
                    }
                }
                else
                {
                    if (this.CompareValues(toPromote.Value, toPromote.Parent.Value) <= 0)
                    {
                        toPromote.Parent.Left = toPromote.Left;
                    }
                    else
                    {
                        toPromote.Parent.Right = toPromote.Left;
                    }

                    toPromote.Left.Parent = toPromote.Parent;
                }

                // Copy the value to the node to be 'deleted'
                toRemove.Value = toPromote.Value;
            }

            this.Count--;
            return true;
        }

        private int CompareValues(T left, T right)
        {
            if (this.delegateComparer != null)
            {
                return this.delegateComparer(left, right);
            }

            if (this.interfaceComparer != null)
            {
                return this.interfaceComparer.Compare(left, right);
            }

            if (left is IComparable<T>)
            {
                return (left as IComparable<T>).CompareTo(right);
            }
            else
            {
                throw new ArgumentException("The type of values has no default comparer and no custom comparer has been provided.");
            }
        }

        private Node<T> FindNode(Node<T> root, T value)
        {
            if (root is null)
            {
                return null;
            }

            if (this.CompareValues(root.Value, value) == 0)
            {
                return root;
            }

            if (this.CompareValues(value, root.Value) < 0)
            {
                return this.FindNode(root.Left, value);
            }
            else
            {
                return this.FindNode(root.Right, value);
            }
        }

        private T GetMax(Node<T> root)
        {
            if (root.Right is null)
            {
                return root.Value;
            }

            return this.GetMax(root.Right);
        }

        private T GetMin(Node<T> root)
        {
            if (root.Left is null)
            {
                return root.Value;
            }

            return this.GetMin(root.Left);
        }

        private void InsertNode(Node<T> current, T value)
        {
            if (this.CompareValues(value, current.Value) <= 0)
            {
                if (current.Left is null)
                {
                    current.Left = new Node<T>(value);
                    current.Left.Parent = current;

                    this.Count++;
                }
                else
                {
                    this.InsertNode(current.Left, value);
                }
            }
            else
            {
                if (current.Right is null)
                {
                    current.Right = new Node<T>(value);
                    current.Right.Parent = current;

                    this.Count++;
                }
                else
                {
                    this.InsertNode(current.Right, value);
                }
            }
        }

        private IEnumerable<T> Preorder(Node<T> root)
        {
            if (root != null)
            {
                yield return root.Value;

                foreach (var value in this.Preorder(root.Left))
                {
                    yield return value;
                }

                foreach (var value in this.Preorder(root.Right))
                {
                    yield return value;
                }
            }
        }

        private IEnumerable<T> Inorder(Node<T> root)
        {
            if (root != null)
            {
                foreach (var value in this.Inorder(root.Left))
                {
                    yield return value;
                }

                yield return root.Value;

                foreach (var value in this.Inorder(root.Right))
                {
                    yield return value;
                }
            }
        }

        private IEnumerable<T> Postorder(Node<T> root)
        {
            if (root != null)
            {
                foreach (var value in this.Postorder(root.Left))
                {
                    yield return value;
                }

                foreach (var value in this.Postorder(root.Right))
                {
                    yield return value;
                }

                yield return root.Value;
            }
        }
    }
}
