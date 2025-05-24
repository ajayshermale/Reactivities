using System;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities.Command;

public class EditActivity
{

    public class Command : IRequest<string>
    {
        public required Activity Activity { get; set; }

    }

    public class Handler(AppDbContext appContext, IMapper mapper) : IRequestHandler<Command, string>
    {
        public async Task<string> Handle(Command request, CancellationToken cancellationToken)
        {
            var activity = await appContext.Activities.FindAsync(request.Activity.Id) ?? throw new KeyNotFoundException($"Activity with ID {request.Activity.Id} not found.");

            //Use auto mapper 

            mapper.Map(request.Activity, activity); 
            await appContext.SaveChangesAsync();

            return "Updated Successfully :"+activity.Id;
        }
    }
}
    



