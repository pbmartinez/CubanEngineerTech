
using Lexicographics.Strategies.NextGreaterPermutation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicographics.DependencyInjectionExtensions
{
    public class NextPermutationOptions
    {
        public NextPermutationStrategyLifeCycle LifeCycle { get; set; } = NextPermutationStrategyLifeCycle.Scoped;
        public INextGreaterPermutation DefaultStrategy { get; set; } = new GenericNextGreaterPermutation();  
    }
}
