﻿using System;

namespace API.Controllers;

using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

//[ApiController]
//[Route("api/[controller]")]
//[Authorize]
public class UsersController : BaseApiController
{
    private readonly DataContext _dataContext;
    public UsersController(DataContext dataContext)
    {
        this._dataContext = dataContext;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        return await _dataContext.Users.ToListAsync();
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<AppUser?>> GetUser(int id)
    {
        return await _dataContext.Users.FindAsync(id);
    }
}
