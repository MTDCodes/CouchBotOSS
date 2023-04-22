using AutoMapper;
using CouchBotOSS.Accessors.Contracts;
using CouchBotOSS.Data.Models;
using CouchBotOSS.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace CouchBotOSS.Accessors.Implementations
{
    public class DiscordUserAccessor : IDiscordUserAccessor
    {
        private readonly CouchContext _couchContext;
        private readonly IMapper _mapper;

        public DiscordUserAccessor(CouchContext couchContext, 
            IMapper mapper)
        {
            _couchContext = couchContext;
            _mapper = mapper;
        }

        public async Task<List<DiscordUserDto>> ListAsync()
        {
            var discordUsers = await _couchContext.DiscordUsers.ToListAsync();

            return _mapper.Map<List<DiscordUserDto>>(discordUsers);
        }

        public async Task<DiscordUserDto> RetrieveAsync(string discordUserId)
        {
            var discordUser = await _couchContext.DiscordUsers.FirstOrDefaultAsync(x => x.DiscordUserId == discordUserId);

            if(discordUser == null)
            {
                return null;
            }

            return _mapper.Map<DiscordUserDto>(discordUser);
        }

        public async Task<DiscordUserDto> RetrieveAsync(long id)
        {
            var discordUser = await _couchContext.DiscordUsers.FirstOrDefaultAsync(x => x.Id == id);

            if (discordUser == null)
            {
                return null;
            }

            return _mapper.Map<DiscordUserDto>(discordUser);
        }
    }
}
