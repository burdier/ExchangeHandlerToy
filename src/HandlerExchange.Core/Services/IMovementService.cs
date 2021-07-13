using System.Threading.Tasks;
using HandlerExchange.Core.Entities;

namespace HandlerExchange.Core.Services
{
    public interface IMovementService
    {
        Task Add(Movement movement);
        Task Browse();
    }

    internal  class MovementService : IMovementService
    {
        public Task Add(Movement movement)
        {
            throw new System.NotImplementedException();
        }

        public Task Browse()
        {
            throw new System.NotImplementedException();
        }
    }
}