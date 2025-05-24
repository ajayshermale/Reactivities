using Domain;
using MediatR;
using Persistence;

namespace Application.Activities.Command;

public class CreateActivity
{
    public class Command : IRequest<string>
    {
        public required Activity activity { get; set; }
    }

    public class Handler(AppDbContext appDbContext) : IRequestHandler<Command, string>
    {
        public async Task<string> Handle(Command request, CancellationToken cancellationToken)
        {
            if (request.activity == null)
            {
                throw new ArgumentNullException(nameof(request.activity), "Activity cannot be null");
            }

            appDbContext.Activities.Add(request.activity);
            await appDbContext.SaveChangesAsync(cancellationToken);
            return request.activity.Id;
        }
    }

}
