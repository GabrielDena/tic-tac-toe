using System.ComponentModel.DataAnnotations;

namespace TicTacToe.Backend.Controllers.Dtos;

public class WinnerDto
{
    [RegularExpression("X|O", ErrorMessage = "Winner must be either 'X' or 'O'.")]
    public string Winner { get; set; }
}