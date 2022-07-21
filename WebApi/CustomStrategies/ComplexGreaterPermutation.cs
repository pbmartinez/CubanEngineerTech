using Lexicographics.Strategies.NextGreaterPermutation;

namespace WebApi.CustomStrategies
{
    /// <summary>
    /// Custom strategie to point out how override default implementation
    /// </summary>
    public class ComplexGreaterPermutation : INextGreaterPermutation
    {
        public T[] NextGreaterPermutation<T>(T[] array) where T : IComparable<T>
        {
            // Implement custom behavior here
            throw new NotImplementedException();
        }
    }
}
