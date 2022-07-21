using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubanEngineerTech.Strategies
{
    public class GenericNextGreaterPermutationStrategy : INextGreaterPermutationStrategy 
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

        private void Swap<T>(T[] array, int positionA, int positionB)
        {
            var tmp = array[positionA];
            array[positionA] = array[positionB];
            array[positionB] = tmp;
        }

        private void Reverse<T>(T[] array, int startingPosition, int endingPosition)
        {
            while (startingPosition < endingPosition) 
                Swap(array, startingPosition++, endingPosition--);
        }
    }
}
