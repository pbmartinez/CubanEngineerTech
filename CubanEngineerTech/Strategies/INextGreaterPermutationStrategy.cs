using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubanEngineerTech.Strategies
{
    public interface INextGreaterPermutationStrategy
    {
        T[] NextGreaterPermutation<T>(T[] array) where T : IComparable<T>; 
    }
}
