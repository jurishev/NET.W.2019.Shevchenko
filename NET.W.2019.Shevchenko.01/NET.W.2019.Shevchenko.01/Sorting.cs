using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Shevchenko._01
{
    /// <summary>
    /// Homework from Day 1 at EPAM training. Sorting algorithms.
    /// </summary>
    public static class Sorting
    {
        /// <summary>
        /// Sorts an array of integers in ascending order by comparing with a pivot
        /// </summary>
        public static int[] QuickSort( int[] data )
        {
            // Nothing to sort

            if ( data == null )
                throw new Exception();

            // Already sorted

            if ( data.Length < 2 )
                return data;

            // Swap if needed

            if ( data.Length == 2 ) {
                if ( data[ 0 ] > data[ 1 ] ) {
                    int temp = data[ 0 ];
                    data[ 0 ] = data[ 1 ];
                    data[ 1 ] = temp;
                }
                return data;
            }

            // Partition

            int pivot = data[ data.Length / 2 ];

            var less = new List<int>();
            var equal = new List<int>();
            var greater = new List<int>();

            foreach ( int i in data ) {
                if ( i < pivot )
                    less.Add( i );
                if ( i == pivot )
                    equal.Add( i );
                if ( i > pivot )
                    greater.Add( i );
            }

            // Concatenate

            return QuickSort( less.ToArray() ).Concat( equal )
                .Concat( QuickSort( greater.ToArray() ) ).ToArray();
        }

        /// <summary>
        /// Sorts an array of integers in ascending order by splitting and merging
        /// </summary>
        public static int[] MergeSort( int[] data )
        {
            // Nothing to sort

            if ( data == null )
                throw new Exception();

            // Already sorted

            if ( data.Length < 2 )
                return data;

            // Split

            var left = data.Take( data.Length / 2 ).ToArray();
            var right = data.Skip( data.Length / 2 ).ToArray();

            // Sort

            left = MergeSort( left );
            right = MergeSort( right );

            // Merge

            return MergeOrdered( left, right );

            int[] MergeOrdered( int[] lft, int[] rgt )
            {
                var merged = new List<int>();
                int li = 0, ri = 0;

                while ( li < lft.Length && ri < rgt.Length ) {
                    if ( lft[ li ] > rgt[ ri ] ) {
                        merged.Add( rgt[ ri++ ] );
                    }
                    else if ( lft[ li ] < rgt[ ri ] ) {
                        merged.Add( lft[ li++ ] );
                    }
                    else {
                        merged.Add( lft[ li++ ] );
                        merged.Add( rgt[ ri++ ] );
                    }
                }

                if ( li < lft.Length )
                    while ( li < lft.Length )
                        merged.Add( lft[ li++ ] );

                if ( ri < rgt.Length )
                    while ( ri < rgt.Length )
                        merged.Add( rgt[ ri++ ] );

                return merged.ToArray();
            }
        }
    }
}
