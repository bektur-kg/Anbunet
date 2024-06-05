global using System.Text;
global using System.Text.Json.Serialization;

global using Microsoft.OpenApi.Models;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.SignalR;
global using Microsoft.Extensions.Options;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Authentication.JwtBearer;

global using Anbunet.Application.Hubs;
global using Anbunet.Application.OptionsSetup;
global using Anbunet.Application.Extensions;
global using Anbunet.Application.Services;
global using Anbunet.Domain.Abstractions;
global using Anbunet.Infrastructure.Extensions;

global using MediatR;