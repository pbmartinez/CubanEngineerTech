using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.WebApiTests
{
    public static class ApiEndpoints
    {
        static string BASE_URL = "https://localhost:7190";

        #region GET Methods
        public static class Get
        {
            public static string Lexicographic(string items)
            {
                return $"{BASE_URL}/lexicographic/next-greater-permutation?items={items}";
            }
            public static string Lexicographic(int[] items)
            {
                var ca = $"{BASE_URL}/lexicographic/next-greater-permutation?items={string.Join(',', items??new int[] { })}";
                return $"{BASE_URL}/lexicographic/next-greater-permutation?items={string.Join(',',items ?? new int[] { })}";
            }
        }
        #endregion
    }
}
