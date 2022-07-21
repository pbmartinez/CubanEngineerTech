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

        public static void AddNextPermutationStrategy(this IServiceCollection services, Action<NextPermutationOptions>? nextPermutationOptions = null)
        {            
            services.Configure(nextPermutationOptions);
            var options = new NextPermutationOptions();
            nextPermutationOptions?.Invoke(options);
            switch (options.LifeCycle)
            {
                case NextPermutationStrategyLifeCycle.Singleton:
                    services.AddSingleton<INextGreaterPermutation, GenericNextGreaterPermutation>();
                    break;
                case NextPermutationStrategyLifeCycle.Scoped:
                    services.AddScoped<INextGreaterPermutation, GenericNextGreaterPermutation>();
                    break;
                case NextPermutationStrategyLifeCycle.Transient:
                    services.AddTransient<INextGreaterPermutation, GenericNextGreaterPermutation>();
                    break;
                default:
                    throw new InvalidOperationException(Localization.Resource.message_InvalidaConfigurationOnLifeCycle);
            }
        }
    }
}
