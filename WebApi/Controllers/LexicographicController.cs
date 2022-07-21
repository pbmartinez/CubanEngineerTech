using Lexicographics.Strategies.NextGreaterPermutation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers;


namespace WebApi.Controllers
{
    [Route("lexicographic")]
    [ApiController]
    public class LexicographicController : ControllerBase
    {
        public readonly INextGreaterPermutation _nextGreaterPermutation;

        public LexicographicController(INextGreaterPermutation nextGreaterPermutation)
        {
            _nextGreaterPermutation = nextGreaterPermutation ?? throw new ArgumentNullException(nameof(nextGreaterPermutation));
        }
        
        [HttpGet("next-greater-permutation")]
        public ActionResult<int[]> Get([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<int> items) 
        {
            var array = items.ToArray();
            if (array == null || !array.Any())
                return BadRequest();
            return Ok(_nextGreaterPermutation.NextGreaterPermutation(array));
        }

    }
}
