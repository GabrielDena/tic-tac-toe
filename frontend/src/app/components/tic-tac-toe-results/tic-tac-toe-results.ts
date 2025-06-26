import { CommonModule } from '@angular/common';
import { Component, effect, Input, signal } from '@angular/core';
import { IResult } from '../../interfaces/result';
import { TicTacToeService } from '../../services/tic-tac-toe';

@Component({
  selector: 'app-tic-tac-toe-results',
  imports: [CommonModule],
  templateUrl: './tic-tac-toe-results.html',
  styleUrl: './tic-tac-toe-results.sass',
})
export class TicTacToeResults {
  public lastResults = signal<IResult[]>([]);
  @Input() public updateResults = signal(false);

  constructor(private readonly ticTacToeService: TicTacToeService) {
    effect(() => {
      if (this.updateResults()) {
        this.loadPastWinners();
      }
    });
  }

  private loadPastWinners(): void {
    this.ticTacToeService.getPastWinners().subscribe((data) => {
      this.lastResults.set(data);
      this.updateResults.set(false);
    });
  }
}
