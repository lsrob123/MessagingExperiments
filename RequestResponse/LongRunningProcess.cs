using System;
using System.Threading.Tasks;

namespace RequestResponse
{
    public class LongRunningProcess
    {
        public SomeResponse Result { get; set; }

        public async Task ProcessAsync(SomeRequest request)
        {
            var response = new SomeResponse {Data = request.Data};
            await Task.Delay(500);
            Result = response;
        }
    }
}