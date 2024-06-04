﻿using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Stories;
using Anbunet.Domain.Modules.Users;
using System.ComponentModel.DataAnnotations;

namespace Anbunet.Domain.Modules.Actuals;

public class Actual : Entity
{
    [MaxLength(ActualAttributeConstants.MAX_NAME_LENGTH)]
    public required string Name { get; set; }

    public long UserId { get; set; }

    public List<Story>? Stories { get; set; } = [];

    public User? User { get; set; }
}

