using System;
using System.Collections.Generic;

namespace TicTacToe.Backend.Entities;

public partial class Result
{
    public int Id { get; set; }

    public string? Winner { get; set; }

    public DateTime? Datetime { get; set; }
}
