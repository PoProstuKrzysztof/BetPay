namespace Domain.Contracts;

public interface IRepositoryWrapper
{
    IEventRepository EventRepository { get; }

    IBetRepository BetRepository { get; }

    Task SaveAsync();
}