using CouchBotOSS.Accessors.Contracts;
using CouchBotOSS.Accessors.Implementations;
using CouchBotOSS.Dalton.Models;
using CouchBotOSS.Dalton.Services.Hosted;
using CouchBotOSS.Data.Models;
using CouchBotOSS.Shared.Mapper;
using CouchBotOSS.Shared.Models.Bot;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<CouchContext>(options =>
            options.UseNpgsql(context.Configuration.GetConnectionString("CouchContext")));
        services.AddAutoMapper(typeof(MappingProfile));
        services.Configure<PatreonConfiguration>(context.Configuration.GetSection(nameof(PatreonConfiguration)));
        services.Configure<TimerConfiguration>(context.Configuration.GetSection(nameof(TimerConfiguration)));
        services.AddMemoryCache();
        services.AddScoped<IDiscordUserAccessor, DiscordUserAccessor>();
        services.AddScoped<IPatreonAccessor, PatreonAccessor>();
        services.AddHostedService<PatreonWorker>();
    })
    .Build();

host.Run();
