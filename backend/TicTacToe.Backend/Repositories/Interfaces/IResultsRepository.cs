using TicTacToe.Backend.Entities;

namespace TicTacToe.Backend.Repositories.Interfaces;

public interface IResultsRepository
{
    Task<List<Result>> GetResultsAsync();
    Task SaveResultAsync(Result result);
}