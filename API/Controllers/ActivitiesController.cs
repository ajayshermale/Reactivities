using System.Reflection.Metadata;
using Application.Activities.Command;
using Application.Activities.Queries;
using Domain;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;

public class ActivitiesController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        return await Mediator.Send(new GetActivityList.Query());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivityDetail(string id)
    {
        return await Mediator.Send(new GetActivityDetail.Query { Id = id });
    }


    [HttpPost]
    public async Task<ActionResult<string>> Createactivity(Activity activity)
    {
        return await Mediator.Send(new CreateActivity.Command { activity = activity });
    }

    [HttpPut]
    public async Task<ActionResult<string>> EditActivity(Activity activity)
    {
        return await Mediator.Send(new EditActivity.Command { Activity = activity });
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult<string>> DeleteActivity(string id)
    {
      return await Mediator.Send(new DeleteActivity.Command { Id = id });
    }
}
