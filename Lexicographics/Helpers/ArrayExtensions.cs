using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicographics.Helpers
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// Swap items in from the given positions
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="positionA"></param>
        /// <param name="positionB"></param>
        public static void Swap<T>(T[] array, int positionA, int positionB)
        {
            ArgumentNullException.ThrowIfNull(array, nameof(array));
            array.GuardAgainstIndexOutOfRange(positionA, positionB);            
            (array[positionB], array[positionA]) = (array[positionA], array[positionB]);
        }
        /// <summary>
        /// Reverses an array from startingPosition to endingPosition
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="startingPosition"></param>
        /// <param name="endingPosition"></param>
        public static void Reverse<T>(T[] array, int startingPosition, int endingPosition)
        {
            ArgumentNullException.ThrowIfNull(array,nameof(array));
            array.GuardAgainstIndexOutOfRange(startingPosition, endingPosition);
            while (startingPosition < endingPosition)
                Swap(array, startingPosition++, endingPosition--);
        }


        public static void GuardAgainstIndexOutOfRange<T>(this T[] array, int position)
        {
            if (position < 0 || position >= array.Length)
                throw new IndexOutOfRangeException(nameof(array));
        }

        public static void GuardAgainstIndexOutOfRange<T>(this T[] array, params int [] positions)
        {
            foreach (var position in positions)
                array.GuardAgainstIndexOutOfRange(position);
        }
    }
}
