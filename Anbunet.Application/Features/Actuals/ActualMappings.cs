﻿using Anbunet.Application.Contracts.Actuals;
using Anbunet.Domain.Modules.Actuals;
using AutoMapper;

namespace Anbunet.Application.Features.Actuals;

public class ActualMappings : Profile
{
    public ActualMappings()
    {
        CreateMap<Actual, ProfileActualResponse>();
    }
}
