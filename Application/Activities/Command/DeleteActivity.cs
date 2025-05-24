using System;
using MediatR;
using Persistence;

namespace Application.Activities.Command;

public class DeleteActivity
{
    public class Command : IRequest<string>
    {
        public required string Id { get; set; }
    }

    public class Handler(AppDbContext appDbContext) : IRequestHandler<Command, string>
    {

        public async Task<string> Handle(Command request, CancellationToken cancellationToken)
        {
            if (request.Id == null) throw new ArgumentNullException(request.Id, "Activity Id cannot be null");

            var activity = await appDbContext.Activities.FindAsync(request.Id);

            if (activity == null) throw new KeyNotFoundException("Activity not found: " + request.Id);

            appDbContext.Activities.Remove(activity);

            await appDbContext.SaveChangesAsync();

            return "Deleted Successfully: " + request.Id;      

        }
    }

}
