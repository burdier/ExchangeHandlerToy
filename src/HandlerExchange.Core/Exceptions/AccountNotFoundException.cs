using HandlerExchange.Shared;

namespace HandlerExchange.Core.DAL.Repositories
{
    public  class AccountNotFoundException : AppException
    {
        public AccountNotFoundException(string message) : base(message)
        {
        }

        public AccountNotFoundException(string message, params object[] args) : base(message, args)
        {
        }
    }
}