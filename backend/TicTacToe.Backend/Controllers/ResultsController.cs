using Microsoft.AspNetCore.Mvc;
using TicTacToe.Backend.Controllers.Dtos;
using TicTacToe.Backend.Entities;
using TicTacToe.Backend.Services;

namespace TicTacToe.Backend.Controllers;

[ApiController]
[Route("api/results")]
public class ResultsController(ILogger<ResultsController> logger, ResultsService service) : ControllerBase
{
   [HttpGet, Route("last")]
   public async Task<ActionResult<List<Result>>> Get()
   {
      logger.LogInformation("Received a GET request to TicTacToeController.");
      try
      {
         var results = await service.GetResultsAsync();
         return Ok(results);
      }
      catch (Exception ex)
      {
         logger.LogError(ex, "An error occurred while fetching results.");
         return StatusCode(500, "Internal server error");
      }
   }
   
   [HttpPost]
   public async Task<IActionResult> Post([FromBody] WinnerDto winnerDto)
   {
      logger.LogInformation("Received a POST request to TicTacToeController with winner: {Winner}", winnerDto.Winner);

      await service.SaveResultAsync(winnerDto.Winner);
      return Ok("Result saved successfully.");
   }
}