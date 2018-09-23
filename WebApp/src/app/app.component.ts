import { Component, OnInit } from '@angular/core';
import { StartshipService } from './startship.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'StarWarsSupply FrontEnd';
  starShips: any;
  mGLT: number;

  constructor(private startshipService: StartshipService) {
  }

  public getResupplyStarShips() {
    this.startshipService.getResupplyStarShips(this.mGLT)
    .subscribe((data: any) => this.starShips = data);
  }

}
