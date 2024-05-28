﻿using Anbunet.Application.Contracts.Follows;
using Anbunet.Application.Features.Follows.GetFollowers;
using Anbunet.Application.Features.Follows.GetFollowings;
using Anbunet.Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Anbunet.API.Controllers;
[Authorize]
[ApiController]
public class FollowController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpGet("/followers/{userId}")]
    public async Task<ActionResult<ValueResult<List<FollowResponse>>>> GetAllFollowers(long userId)
    {
        var command = new GetUserFollowersQuery(userId);

        var response = await sender.Send(command);

        return response.IsSuccess ? Ok(response) : BadRequest(response.Error);
    }

    [HttpGet("/followings/{userId}")]
    public async Task<ActionResult<ValueResult<List<FollowResponse>>>> GetAllFollowings(long userId)
    {
        var command = new GetUserFollowingsQuery(userId);

        var response = await sender.Send(command);

        return response.IsSuccess ? Ok(response) : BadRequest(response.Error);
    }

}
