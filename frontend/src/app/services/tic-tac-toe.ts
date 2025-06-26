import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, of } from 'rxjs';
import { environment } from '../../environments/environment';
import { IResult } from '../interfaces/result';

@Injectable({
  providedIn: 'root',
})
export class TicTacToeService {
  private baseUrl = environment.apiUrl + '/results';
  constructor(private readonly http: HttpClient) {}

  public saveWinner(winner: string): Observable<void> {
    return this.http.post<void>(`${this.baseUrl}`, { winner }).pipe(
      catchError((error) => {
        console.error('Error saving winner:', error);
        return of();
      }),
    );
  }

  public getPastWinners(): Observable<IResult[]> {
    return this.http.get<IResult[]>(`${this.baseUrl}/last`).pipe(
      catchError((error) => {
        console.error('Error fetching past winners:', error);
        return of([]);
      }),
    );
  }
}
