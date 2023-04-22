using CouchBotOSS.Dalton.Models;
using CouchBotOSS.Dalton.Services.Hosted;
using CouchBotOSS.Shared.Models.Bot;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.Configure<PatreonConfiguration>(context.Configuration.GetSection(nameof(PatreonConfiguration)));
        services.Configure<TimerConfiguration>(context.Configuration.GetSection(nameof(TimerConfiguration)));
        services.AddMemoryCache();
        services.AddHostedService<PatreonWorker>();
    })
    .Build();

host.Run();
