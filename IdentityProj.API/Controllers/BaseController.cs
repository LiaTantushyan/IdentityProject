﻿using System.Security.Claims;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IdentityProj.Controllers;

[ApiController]
public class BaseController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public BaseController(
        IMapper mapper,
        IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    protected IMapper Mapper => _mapper;

    protected IMediator Mediator => _mediator;

    protected int? GetCurrentUserId()
    {
        if (int.TryParse(User.FindFirstValue("id"), out int userId))
        {
            return userId;
        }

        return null;
    }
}