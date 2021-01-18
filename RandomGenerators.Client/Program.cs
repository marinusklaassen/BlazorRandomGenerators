using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RandomGenerators.Travesty;
using RandomGenerators.EAN13MockGenerator;
using Blazored.Toast;

namespace RandomGenerators.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            // Register our own injectables
            builder.Services.AddSingleton<ITravestyGenerator, TravestyGenerator>();
            builder.Services.AddSingleton<IEAN13MockGenerator, EAN13MockGenerator.EAN13MockGenerator>();
            builder.Services.AddSingleton<IClipboardService, ClipboardService>();
            builder.Services.AddBlazoredToast();

            await builder.Build().RunAsync();
        }
    }
}
