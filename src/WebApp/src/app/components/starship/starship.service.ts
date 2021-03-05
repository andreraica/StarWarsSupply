import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { StarShip } from './starship.model';
import { environment } from './../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StarshipService {
  constructor(private http:HttpClient) { }

  calculateResupplyStops(mGLT: number) : Observable<StarShip[]> {
    return this.http.get<StarShip[]>(`${environment.apiBaseUrl}/Starship/${mGLT}`);
  }
}
