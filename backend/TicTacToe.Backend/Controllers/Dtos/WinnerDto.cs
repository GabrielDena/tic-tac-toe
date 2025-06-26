using System.ComponentModel.DataAnnotations;

namespace TicTacToe.Backend.Controllers.Dtos;

public class WinnerDto
{
    [Required]
    [RegularExpression("X|O|D", ErrorMessage = "Winner must be either 'X', 'O' or 'D'.")]
    public string Winner { get; set; }
}