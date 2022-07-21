using Lexicographics.Strategies.NextGreaterPermutation;
using NUnit.Framework;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.LexicographicTests
{
    [TestFixture]
    public class GenericNextGreaterPermutationTest
    {
        private static readonly GenericNextGreaterPermutation _sut = new();

        [Test]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 3, 2 })]
        [TestCase(new int[] { 3, 2, 1 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 1, 5 }, new int[] { 1, 5, 1 })]
        public void Next_Greater_Permutation(int[] inputArray, int[] expectedResult)
        {
            _sut.NextGreaterPermutation(inputArray);
            inputArray.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        [TestCase(null)]
        public void Throw_NullArgumentExpception_On(int[] inputArray)
        {
            var action = () => { _sut.NextGreaterPermutation(inputArray); };
            action.Should().Throw<ArgumentNullException>();
        }



    }
}
