import { CommonModule } from '@angular/common';
import { Component, signal } from '@angular/core';
import { TicTacToeResults } from './components/tic-tac-toe-results/tic-tac-toe-results';
import { TicTacToe } from './components/tic-tac-toe/tic-tac-toe';

@Component({
  selector: 'app-root',
  imports: [TicTacToe, CommonModule, TicTacToeResults],
  templateUrl: './app.html',
  styleUrl: './app.sass',
})
export class App {
  protected title = 'ticTacToe';
  public showGame = signal(false);
  public showGameModes = signal(false);
  public againstPlayer = signal(false);
  public showGameResults = signal(false);
  public updateResults = signal(false);

  public selectGameMode(mode: 'player' | 'computer'): void {
    this.againstPlayer.set(mode === 'player');
    this.showGame.set(true);
  }

  public toggleGameResults(): void {
    this.showGameResults.set(!this.showGameResults());
    if (this.showGameResults()) this.updateResults.set(true);
  }

  public startGame(): void {
    this.showGameModes.set(true);
    this.updateResults.set(false);
    this.showGameResults.set(false);
  }
}
