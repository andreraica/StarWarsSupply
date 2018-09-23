import { Component, OnInit } from '@angular/core';
import { StartshipService } from './startship.service';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'StarWarsSupply FrontEnd';
  starShips: any;
  mGLT: number;

  constructor(private startshipService: StartshipService,
    private spinner: NgxSpinnerService) {
  }

  public getResupplyStarShips() {
    this.starShips = null;
    this.spinner.show();
    this.startshipService.getResupplyStarShips(this.mGLT)
    .subscribe(data => {
      this.starShips = data;
      this.spinner.hide();
    });
  }

}
