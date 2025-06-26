using TicTacToe.Backend.Repositories;
using TicTacToe.Backend.Repositories.Interfaces;

namespace TicTacToe.Backend.Services;

public class ResultsService(ILogger<ResultsService> logger, IResultsRepository repository)
{
    public async Task<List<Entities.Result>> GetResultsAsync()
    {
        logger.LogInformation("Fetching results from the repository.");
        return await repository.GetResultsAsync();
    }
    
    public async Task SaveResultAsync(string winner)
    {
        logger.LogInformation("Saving result with winner: {Winner}", winner);
        
        var result = new Entities.Result
        {
            Winner = winner,
            Datetime = DateTime.UtcNow
        };
        
        await repository.SaveResultAsync(result);
    }
}
