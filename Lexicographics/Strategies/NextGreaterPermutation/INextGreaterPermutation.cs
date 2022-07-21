using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicographics.Strategies.NextGreaterPermutation
{
    /// <summary>
    /// Defines operations for Next Greater Permutation
    /// </summary>
    public interface INextGreaterPermutation
    {
        /// <summary>
        /// Returns the next greater permutation from the given array of generic types. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        T[] NextGreaterPermutation<T>(T[] array) where T : IComparable<T>; 
    }
}
