using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RequestResponse
{
    public class SomeProxy
    {
        public async Task<SomeResponse> GetResponseAsync(Guid testValue)
        {
            var request = new SomeRequest {Data = testValue};

            SomeResponse response = null;

            var process = new LongRunningProcess();

            var stopwatch=new Stopwatch();
            stopwatch.Start();
            await process.ProcessAsync(request).ContinueWith(task =>
            {
                while (process.Result.Data != request.Data)
                {
                    Task.Delay(1);
                }

                response = process.Result;
                stopwatch.Stop();
                response.Time = stopwatch.Elapsed;
            });


            return response;
        }
    }
}