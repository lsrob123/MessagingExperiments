using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RequestResponse.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            var someProxy = new SomeProxy();
            var testValue = Guid.NewGuid();
            var response = await someProxy.GetResponseAsync(testValue);
            Assert.IsNotNull(response);
            Assert.AreEqual(testValue, response.Data);

            Assert.IsTrue(response.Time > TimeSpan.Zero);
            Console.WriteLine($"Time = {response.Time.TotalMilliseconds}ms");
        }
    }
}