namespace Application.Contracts;

public interface IRepositoryWrapper
{
    IEventRepository EventRepository { get; }

    IBetRepository BetRepository { get; }

    IBookmakerRepository BookmakerRepository { get; }

    ICategoryRepository CategoryRepository { get; }

    IEventTypeRepository EventTypeRepostiory { get; }

    Task SaveAsync();
}