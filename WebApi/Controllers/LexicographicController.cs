using Lexicographics.Strategies.NextGreaterPermutation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using WebApi.Helpers;
using WebApi.Options;

namespace WebApi.Controllers
{
    [Route("lexicographic")]
    [ApiController]
    public class LexicographicController : ControllerBase
    {
        public readonly INextGreaterPermutation _nextGreaterPermutation;
        public readonly IMemoryCache _memoryCache;
        public readonly IOptions<CacheOptions> _cacheOptions;

        public LexicographicController(INextGreaterPermutation nextGreaterPermutation, IMemoryCache memoryCache, IOptions<CacheOptions> cacheOptions)
        {
            _nextGreaterPermutation = nextGreaterPermutation ?? throw new ArgumentNullException(nameof(nextGreaterPermutation));
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
            _cacheOptions = cacheOptions ?? throw new ArgumentNullException(nameof(cacheOptions));
        }

        [HttpGet("next-greater-permutation")]
        public ActionResult<int[]> Get([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<int> items) 
        {
            var array = items.ToArray();
            var key = string.Join(',', array);

            if (!_memoryCache.TryGetValue(key, out int[] cacheValue))
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(_cacheOptions.Value.TimeInHours));
                cacheValue = _nextGreaterPermutation.NextGreaterPermutation(array);
                _memoryCache.Set(key, cacheValue, cacheEntryOptions);
            }
            return Ok(cacheValue);
        }



    }
}
