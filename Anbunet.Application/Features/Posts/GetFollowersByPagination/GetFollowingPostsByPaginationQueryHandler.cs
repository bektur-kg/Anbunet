﻿using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Posts;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Posts;
using Anbunet.Domain.Modules.Users;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Security.Claims;

namespace Anbunet.Application.Features.Posts.GetFollowersByPagination;

public class GetFollowingPostsByPaginationQueryHandler
    (
        IUserRepository userRepository,
        IPostRepository postRepository,
        IHttpContextAccessor httpContextAccessor,
        IMapper mapper
    )
    : IQueryHandler<GetFollowingPostsByPaginationQuery, ValueResult<List<PostDetailedResponse>>>
{
    private readonly HttpContext httpContext = httpContextAccessor.HttpContext!;
    public async Task<ValueResult<List<PostDetailedResponse>>> Handle(GetFollowingPostsByPaginationQuery request, CancellationToken cancellationToken)
    {
        var userId = long.Parse(httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var followingIds = await userRepository.GetFollowingsIds(userId);
        if (followingIds == null || !followingIds.Any())
        {
            return ValueResult<List<PostDetailedResponse>>.Success(new List<PostDetailedResponse> { });
        }

        var followingPosts = await postRepository.GetPostsByUserIdsWithInclude(request.Page, request.Quantity, followingIds, includeUser:true, includeComments:true, includeLikes:true);
        var mappedPosts = mapper.Map<List<PostDetailedResponse>>(followingPosts);

        return ValueResult<List<PostDetailedResponse>>.Success(mappedPosts);
    }
}
