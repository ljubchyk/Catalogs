using MediatR;

namespace Catalogs.Application
{
    public class RemoveProductCommand : IRequest
    {
        private readonly Guid id;

        public RemoveProductCommand(Guid id)
        {
            this.id = id;
        }

        public Guid Id => id;
    }
}
