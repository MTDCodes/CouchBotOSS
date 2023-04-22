using CouchBotOSS.Dalton.Models;
using CouchBotOSS.Dalton.Services.Hosted;
using CouchBotOSS.Shared.Mapping;
using CouchBotOSS.Shared.Models.Bot;
using MTD.CouchBot.Accessors.Contracts;
using MTD.CouchBot.Accessors.Implementations;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddAutoMapper(typeof(MappingProfile));
        services.Configure<PatreonConfiguration>(context.Configuration.GetSection(nameof(PatreonConfiguration)));
        services.Configure<TimerConfiguration>(context.Configuration.GetSection(nameof(TimerConfiguration)));
        services.AddMemoryCache();
        services.AddSingleton<IPatreonAccessor, PatreonAccessor>();
        services.AddHostedService<PatreonWorker>();
    })
    .Build();

host.Run();
