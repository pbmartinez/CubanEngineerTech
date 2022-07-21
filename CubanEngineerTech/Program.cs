

using CubanEngineerTech.Strategies;

INextGreaterPermutationStrategy strategy = new GenericNextGreaterPermutationStrategy();

var intArray = new int[] { 1, 2, 3 };
var stringArray = new string[] {"1","2","3"};

var nextIntArray = strategy.NextGreaterPermutation(intArray);
var nextStringArray = strategy.NextGreaterPermutation(intArray);
Console.WriteLine();