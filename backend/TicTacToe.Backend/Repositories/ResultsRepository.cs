using Microsoft.EntityFrameworkCore;
using TicTacToe.Backend.Data;
using TicTacToe.Backend.Entities;
using TicTacToe.Backend.Repositories.Interfaces;

namespace TicTacToe.Backend.Repositories;

public class ResultsRepository(TicTacToeContext context) : IResultsRepository
{
    public async Task<List<Result>> GetResultsAsync()
    {
        return await context.Results.Take(10).ToListAsync();
    }
    
    public async Task SaveResultAsync(Result result)
    {
        context.Results.Add(result);
        await context.SaveChangesAsync();
    }
}