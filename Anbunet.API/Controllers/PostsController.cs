﻿using Anbunet.Application.Contracts.Posts;
using Anbunet.Application.Features.Posts.Create;
using Anbunet.Application.Features.Posts.GetById;
using Anbunet.Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Anbunet.API.Controllers;

[ApiController]
[Route("posts")]
[Authorize]
public class PostsController(ISender sender) : ControllerBase
{  
    [HttpPost]
    public async Task<ActionResult<Result>> Create(PostCreateRequest dto)
    {
        var command = new CreatePostCommand(dto);

        var response = await sender.Send(command);

        return response.IsSuccess ? Created() : BadRequest(response.Error);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<ValueResult<PostDetailedResponse>>> GetById(long id)
    {
        var query = new GetPostByIdQuery(id);

        var response = await sender.Send(query);

        return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
    }
}
