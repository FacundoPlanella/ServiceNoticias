using ServiceNoticias;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddSingleton<AlphaVantageApiManager>();
builder.Services.AddHostedService<AlphaVantageWorker>();
builder.Services.AddMemoryCache();
var host = builder.Build();
host.Run();
