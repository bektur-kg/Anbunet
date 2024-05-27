using Anbunet.Domain.Modules.Chats;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anbunet.Infrastructure.Modules.Chats;

public class ChatConfiguration : IEntityTypeConfiguration<PrivateMessage>
{
    public void Configure(EntityTypeBuilder<PrivateMessage> builder)
    {
        builder
            .HasMany(p => p.Messages)
            .WithOne(c => c.PrivateMessage)
            .HasForeignKey(c => c.PrivateMessageId);
    }
}
