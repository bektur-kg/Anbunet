﻿using Anbunet.Application.Contracts.Users;
using Anbunet.Application.Features.Users.GettingUsersByLogin;
using Anbunet.Application.Features.Users.GetUserProfile;
using Anbunet.Application.Features.Users.Login;
using Anbunet.Application.Features.Users.Register;
using Anbunet.Application.Features.Users.Update;

namespace Anbunet.Application.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController(ISender sender) : ControllerBase
{
    [HttpPost("register")]
    public async Task<ActionResult<Result>> RegisterUser(RegisterUserRequest request)
    {
        var command = new RegisterUserCommand(request);

        var response = await sender.Send(command);

        return response.IsSuccess ? Created() : BadRequest(response.Error);
    }

    [HttpPost("login")]
    public async Task<ActionResult<ValueResult<string>>> LoginUser(LoginUserRequest request)
    {
        var query = new LoginUserQuery(request);

        var response = await sender.Send(query);

        return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<ValueResult<string>>> GetUserProfile(long id)
    {
        var query = new GetUserProfileQuery(id);

        var response = await sender.Send(query);

        return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);

    }

    [HttpGet]
    public async Task<ActionResult<ValueResult<UserDetailedResponse>>> GetUsersByLogin(string login)
    {
        var query = new GettingUsersByLoginQuery(login);

        var response = await sender.Send(query);

        return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);

    }

    [HttpPatch("update")]
    public async Task<ActionResult<Result>> UpdateUser(UpdateUserRequest request)
    {
        var query = new UpdateUserCommand(request);
        var response = await sender.Send(query);
        return response.IsSuccess ? Ok(response) : BadRequest(response.Error);
    }
}
