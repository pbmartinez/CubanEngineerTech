using Lexicographics.Helpers;
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
                ArrayExtensions.Swap(array, i, j);
            }
            ArrayExtensions.Reverse(array, i + 1, array.Length - 1);

            return array;
        }
        
    }
}
