import { CommonModule } from '@angular/common';
import { Component, Input, signal } from '@angular/core';
import { TicTacToeService } from '../../services/tic-tac-toe';

@Component({
  selector: 'app-tic-tac-toe',
  imports: [CommonModule],
  templateUrl: './tic-tac-toe.html',
  styleUrl: './tic-tac-toe.sass',
})
export class TicTacToe {
  public board = signal(Array(9).fill(null));
  public currentPlayer = signal('X');
  public winner = signal<string | null>(null);
  @Input() public againstPlayer = false;
  @Input() public showGame = signal(false);

  constructor(private readonly ticTacToeService: TicTacToeService) {}

  public makeMove(index: number): void {
    if (!this.board()[index] && !this.winner()) {
      const newBoard = [...this.board()];
      newBoard[index] = this.currentPlayer();
      this.board.set(newBoard);
      this.checkWinner();
      this.currentPlayer.set(this.currentPlayer() === 'X' ? 'O' : 'X');
      if (!this.againstPlayer && !this.winner() && this.currentPlayer() === 'O') {
        this.makeComputerMove();
      }
    }
  }

  private makeComputerMove(): void {
    const availableMoves = this.board()
      .map((value, index) => (value === null ? index : null))
      .filter((index) => index !== null);

    if (availableMoves.length > 0) {
      const randomIndex = Math.floor(Math.random() * availableMoves.length);
      this.makeMove(availableMoves[randomIndex]);
    }
  }

  private checkWinner(): void {
    const winningCombinations = [
      [0, 1, 2],
      [3, 4, 5],
      [6, 7, 8], // rows
      [0, 3, 6],
      [1, 4, 7],
      [2, 5, 8], // columns
      [0, 4, 8],
      [2, 4, 6], // diagonals
    ];

    for (const combination of winningCombinations) {
      const [a, b, c] = combination;
      if (
        this.board()[a] &&
        this.board()[a] === this.board()[b] &&
        this.board()[a] === this.board()[c]
      ) {
        this.winner.set(this.board()[a]);
      }
    }

    if (!this.winner() && !this.board().includes(null)) {
      this.winner.set('D');
    }

    if (this.winner()) this.saveWinner();
  }

  public resetGame(): void {
    this.board.set(Array(9).fill(null));
    this.currentPlayer.set('X');
    this.winner.set(null);
    this.showGame.set(false);
  }

  private saveWinner(): void {
    if (this.winner()) {
      this.ticTacToeService.saveWinner(this.winner() as string).subscribe(() => {
        console.log('Winner saved successfully:', this.winner());
      });
    }
  }
}
