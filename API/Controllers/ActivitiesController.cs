using System;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers;

public class ActivitiesController(AppDbContext appDbContext) : BaseApiController
{
    // private readonly AppDbContext _dbContext;
    // public ActivitiesController(AppDbContext dbContext)
    // {
    //     this._dbContext = dbContext;
    // }

    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        var activities = await appDbContext.Activities.ToListAsync();
        return Ok(activities);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetActivityDetail(string id)
    {
        var activity = await appDbContext.Activities.FindAsync(id);

        if (activity == null) return NotFound(); //404 response // 
        
        return Ok(activity); //200 response
    }
    
}
