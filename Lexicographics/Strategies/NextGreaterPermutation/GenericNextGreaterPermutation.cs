using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicographics.Strategies.NextGreaterPermutation
{
    public class GenericNextGreaterPermutation : INextGreaterPermutation 
    {
        
        public T[] NextGreaterPermutation<T>(T[] array) where T : IComparable<T>
        {
            if (array == null || array.Length < 1)
                throw new ArgumentNullException(nameof(array));

            if (array.Length == 1) return array;

            int i = array.Length - 2;

            while (i >= 0 && array[i].CompareTo(array[i + 1]) >= 0) i--;
            if (i >= 0)
            {
                int j = array.Length - 1;
                while (array[j].CompareTo(array[i]) <= 0) j--;
                Swap(array, i, j);
            }
            Reverse(array, i + 1, array.Length - 1);

            return array;
        }
        /// <summary>
        /// Swap items in from the given positions
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="positionA"></param>
        /// <param name="positionB"></param>
        private static void Swap<T>(T[] array, int positionA, int positionB)
        {
            (array[positionB], array[positionA]) = (array[positionA], array[positionB]);
        }
        /// <summary>
        /// Reverses an array from startingPosition to endingPosition
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="startingPosition"></param>
        /// <param name="endingPosition"></param>
        private static void Reverse<T>(T[] array, int startingPosition, int endingPosition)
        {
            while (startingPosition < endingPosition)
                Swap(array, startingPosition++, endingPosition--);
        }
    }
}
