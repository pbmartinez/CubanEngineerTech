using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Controllers;
using WebApi.Helpers;

namespace Tests.WebApiTests
{
    [TestFixture]
    public class LexicographicControllerTest
    {
        private static WebApiApplication Application { get; set; } = WebApiApplication.GetWebApiApplication();
        private HttpClient HttpClient { get; set; } = Application.CreateClient();
        private static readonly object[] ItemsWithResponses =
        {
            new object[] { null!, StatusCodes.Status400BadRequest, null! },
            new object[] { new int[] { 1 }, StatusCodes.Status200OK, new int[] { 1 } },
            new object[] { new int[] { 1,2,3 }, StatusCodes.Status200OK, new int[] { 1,3,2 } },
            new object[] { new int[] { 3,2,1 }, StatusCodes.Status200OK, new int[] { 1,2,3 } },
            new object[] { new int[] { 1,1,5 }, StatusCodes.Status200OK, new int[] { 1,5,1 } },
        };

        [Test]
        [TestCaseSource(nameof(ItemsWithResponses))]
        public async Task Get_Next_Greater_Permutation(int[] array, HttpStatusCode statusCode, int[] expectedResult)
        {
            var response = await HttpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get,
                ApiEndpoints.Get.Lexicographic(array)));

            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(statusCode);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.ReadContentAsAsync<int[]>();
                    result.Should().BeEquivalentTo(expectedResult);
                }
            }
        }
    }
}
