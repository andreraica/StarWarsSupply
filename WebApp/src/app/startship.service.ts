import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class StartshipService {

  constructor(private http: HttpClient) {}

  public getResupplyStarShips(mGLT): Observable<any> {
    return this.http.get(`https://localhost:44351/api/Starship/${mGLT}`);
  }

}
