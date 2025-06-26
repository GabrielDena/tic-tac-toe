import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class TicTacToeService {
  constructor(private readonly http: HttpClient) {}

  public async saveWinner(winner: string): Promise<void> {
    try {
      await firstValueFrom(this.http.post('/api/save-winner', { winner }));
    } catch (error) {
      console.error('Error saving winner:', error);
    }
  }
}
