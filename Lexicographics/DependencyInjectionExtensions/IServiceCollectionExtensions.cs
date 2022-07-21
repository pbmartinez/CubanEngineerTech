using Lexicographics.Strategies.NextGreaterPermutation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicographics.DependencyInjectionExtensions
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds default implementation of INextGreaterPermutation to IServiceCollection. 
        /// Provide a Action<NextPermutationOptions> to override default implementation of INextGreaterPermutation.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="nextPermutationOptions"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public static void AddNextPermutationStrategy(this IServiceCollection services, Action<NextPermutationOptions>? nextPermutationOptions = null)
        {            
            var options = new NextPermutationOptions();
            nextPermutationOptions?.Invoke(options);
            services.Add(options.DefaultImplementation);
        }
    }
}
