﻿namespace Anbunet.Application.Contracts.Actuals;

public record UpdateActualRequest
{
    public required string Name { get; set; }

    public long ActualId { get; set; }

}
