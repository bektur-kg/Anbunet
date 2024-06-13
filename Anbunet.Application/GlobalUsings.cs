global using MediatR;
global using AutoMapper;

global using System.Reflection;
global using System.Security.Claims;
global using System.ComponentModel.DataAnnotations;

global using Microsoft.AspNetCore.Http;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.Extensions.DependencyInjection;

global using Anbunet.Application.Services;
global using Anbunet.Application.Abstractions;
global using Anbunet.Application.Contracts.Likes;
global using Anbunet.Application.Contracts.Users;
global using Anbunet.Application.Contracts.Posts;
global using Anbunet.Application.Contracts.Actuals;
global using Anbunet.Application.Contracts.Stories;
global using Anbunet.Application.Contracts.Follows;
global using Anbunet.Application.Contracts.Comments;
global using Anbunet.Application.Features.Users;
global using Anbunet.Application.Features.Posts;
global using Anbunet.Application.Features.Stories;

global using Anbunet.Domain.Abstractions;
global using Anbunet.Domain.Modules.Users;
global using Anbunet.Domain.Modules.Posts;
global using Anbunet.Domain.Modules.Likes;
global using Anbunet.Domain.Modules.Actuals;
global using Anbunet.Domain.Modules.Stories;
global using Anbunet.Domain.Modules.Comments;