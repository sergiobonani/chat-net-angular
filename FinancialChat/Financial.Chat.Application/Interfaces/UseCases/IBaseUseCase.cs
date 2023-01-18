namespace Financial.Chat.Application.Interfaces.UseCases
{
    public interface IBaseUseCase<T>
    {
        Task ExecuteAsync(T entity);
    }
}
