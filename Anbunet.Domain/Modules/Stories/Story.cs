using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Actuals;
using Anbunet.Domain.Modules.Users;
using System.ComponentModel.DataAnnotations;

namespace Anbunet.Domain.Modules.Stories;

public class Story : Entity
{
    public long UserId { get; set; }

    [Url]
    public required string MediaUrl { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public DateTime ExpiryDate { get; set; } = DateTime.UtcNow.AddHours(24);

    public User? User { get; set; }

}

