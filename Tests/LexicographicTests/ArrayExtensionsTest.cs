using Lexicographics.Helpers;
using NUnit.Framework;
using FluentAssertions;
using System;

namespace Tests.LexicographicTests
{
    [TestFixture]
    public class ArrayExtensionsTest
    {

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 4, new int[] { 5, 2, 3, 4, 1 })]
        public void Swap(int[] array, int posA, int posB, int[] expectedResult)
        {
            ArrayExtensions.Swap(array, posA, posB);
            array.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        [TestCase(null, 0, 0)]
        public void Throw_NullArgumentException_OnSwap(int[] array, int posA, int posB)
        {
            var action = () => { ArrayExtensions.Swap(array, posA, posB); };
            action.Should().Throw<ArgumentNullException>();
        }


        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 4, new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 1, new int[] { 2, 1, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 1, new int[] { 2, 1, 3, 4, 5 })]
        public void Reverse(int[] array, int posA, int posB, int[] expectedResult)
        {
            ArrayExtensions.Reverse(array, posA, posB);
            array.Should().BeEquivalentTo(expectedResult);
        }


        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -1, -1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -1, 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, -1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 10, 10)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 10, 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, 10)]
        public void Throw_OutOfRangeException_OnSwap(int[] array, int posA, int posB)
        {
            var action = () => { ArrayExtensions.Swap(array, posA, posB); };
            action.Should().Throw<IndexOutOfRangeException>();
        }



        [Test]
        [TestCase(null, 0, 0)]
        public void Throw_NullArgumentException_OnReverse(int[] array, int posA, int posB)
        {
            var action = () => { ArrayExtensions.Reverse(array, posA, posB); };
            action.Should().Throw<ArgumentNullException>();
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -1, -1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -1, 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, -1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 10, 10)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 10, 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, 10)]
        public void Throw_OutOfRangeException_OnReverse(int[] array, int posA, int posB)
        {
            var action = () => { ArrayExtensions.Reverse(array, posA, posB); };
            action.Should().Throw<IndexOutOfRangeException>();
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, 2)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 3)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, 4)]
        public void DoNotThrow_OutOfRangeException_OnGuard_IfRangeIsOk(int[] array, int posA, int posB)
        {
            var action = () => 
            { 
                array.GuardAgainstIndexOutOfRange( posA); 
                array.GuardAgainstIndexOutOfRange( posB); 
                array.GuardAgainstIndexOutOfRange( posA, posB); 
            };
            action.Should().NotThrow<IndexOutOfRangeException>();
        }




    }
}
