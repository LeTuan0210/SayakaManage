using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace BusinessServices.Repositories.ZaloWorkerServices
{
    public class ZaloBackgroundServices(IConfiguration _config) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested) 
            {
                try
                {
                    using (var Httpclient = new HttpClient { BaseAddress = new Uri(_config["HostAddress"]) })
                    {
                        var result = await Httpclient.GetAsync("api/send-zalo-promotion");
                    }
                }
                catch
                {
                }
                await Task.Delay(120000);
            }
        }
    }
}
