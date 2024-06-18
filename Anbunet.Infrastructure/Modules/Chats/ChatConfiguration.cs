namespace Anbunet.Infrastructure.Modules.Chats;

public class ChatConfiguration : IEntityTypeConfiguration<Chat>
{
    public void Configure(EntityTypeBuilder<Chat> builder)
    {
        builder
            .HasMany(p => p.Messages)
            .WithOne(c => c.Chat)
            .HasForeignKey(c => c.ChatId);
    }
}
