
using Lexicographics.Strategies.NextGreaterPermutation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicographics.DependencyInjectionExtensions
{
    /// <summary>
    /// Options builder used to override default behaviors
    /// </summary>
    public class NextPermutationOptions
    {
        public ServiceDescriptor DefaultImplementation { get; set; } = 
            new ServiceDescriptor(typeof(INextGreaterPermutation), typeof(GenericNextGreaterPermutation), ServiceLifetime.Scoped);
    }
}
