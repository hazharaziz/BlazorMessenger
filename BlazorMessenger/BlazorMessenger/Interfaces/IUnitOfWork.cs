using System;

namespace BlazorMessenger.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IMessageRepository Messages { get; }
        IFollowerRepository Followers { get; }
        int Save();
    }
}
