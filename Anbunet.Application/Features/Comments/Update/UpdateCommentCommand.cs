﻿using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Comments;
using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Comments.Update;

public record UpdateCommentCommand(UpdateCommentRequest Data) : ICommand<Result>;