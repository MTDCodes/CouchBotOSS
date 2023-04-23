using AutoMapper;
using CouchBotOSS.Accessors.Contracts;
using CouchBotOSS.Data.Models;
using CouchBotOSS.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CouchBotOSS.Accessors.Implementations
{
    public class DiscordUserAccessor : IDiscordUserAccessor
    {
        private readonly CouchContext _couchContext;
        private readonly IMapper _mapper;
        private readonly ILogger<DiscordUserAccessor> _logger;

        public DiscordUserAccessor(CouchContext couchContext,
            IMapper mapper,
            ILogger<DiscordUserAccessor> logger)
        {
            _couchContext = couchContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<DiscordUserDto>> ListAsync()
        {
            var discordUsers = await _couchContext.DiscordUsers.ToListAsync();

            return _mapper.Map<List<DiscordUserDto>>(discordUsers);
        }

        public async Task<DiscordUserDto> RetrieveAsync(string discordUserId)
        {
            var discordUser = await _couchContext.DiscordUsers.FirstOrDefaultAsync(x => x.DiscordUserId == discordUserId);

            return discordUser == null ? null : _mapper.Map<DiscordUserDto>(discordUser);
        }

        public async Task<DiscordUserDto> RetrieveAsync(long id)
        {
            var discordUser = await _couchContext.DiscordUsers.FirstOrDefaultAsync(x => x.Id == id);

            return discordUser == null ? null : _mapper.Map<DiscordUserDto>(discordUser);
        }

        public async Task UpdateAsync(DiscordUserDto discordUserDto)
        {
            var discordUser = await _couchContext.DiscordUsers.FirstOrDefaultAsync(x => x.Id == discordUserDto.Id);

            if (discordUser == null)
            {
                _logger.LogError("There was an issue retrieving a DiscordUser to update the allowance on, DiscordUser Id: {DiscordUserId}",
                    discordUserDto.Id);
                return;
            }

            discordUser.Allowance = discordUserDto.Allowance;
            _couchContext.DiscordUsers.Update(discordUser);
            await _couchContext.SaveChangesAsync();
        }
    }
}
