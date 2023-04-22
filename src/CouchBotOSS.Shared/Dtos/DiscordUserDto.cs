namespace CouchBotOSS.Shared.Dtos
{
    public class DiscordUserDto
    {
        public long Id { get; set; }

        public string DiscordUserId { get; set; }

        public string Discriminator { get; set; }

        public string Username { get; set; }

        public string Nickname { get; set; }

        public string CustomPing { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public long? Allowance { get; set; }

        public bool? AllowanceOverride { get; set; }

        public bool? PatreonExempt { get; set; }

        public long? DefaultPlatformId { get; set; }

        public string PatreonId { get; set; }
    }
}
