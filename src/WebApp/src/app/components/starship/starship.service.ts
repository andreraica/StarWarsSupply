import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { StarShip } from './starship.model';

@Injectable({
  providedIn: 'root'
})
export class StarshipService {

  constructor(private http:HttpClient) { }

  calculateResupplyStops(mGLT: number) : Observable<StarShip[]> {
    return this.http.get<StarShip[]>(`http://localhost:44351/api/Starship/${mGLT}`);
  }
}
