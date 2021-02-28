import { Component, OnInit } from '@angular/core';
import { StarshipService } from 'src/app/components/starship/starship.service';
import { MatSnackBar } from '@angular/material/snack-bar'
import { StarShip } from 'src/app/components/starship/starship.model';

@Component({
  selector: 'app-resupply-calculator',
  templateUrl: './resupply-calculator.component.html',
  styleUrls: ['./resupply-calculator.component.css']
})
export class ResupplyCalculatorComponent implements OnInit {

  starShips!: StarShip[];
  mGLT: number = 1000000;
  displayedColumns: string[] = ['name', 'stops'];

  constructor(private starshipService: StarshipService,
    private snackBar:MatSnackBar) { }

  ngOnInit(): void {
  }

  calculate() : void {
    this.processingMessage();
    this.starshipService.calculateResupplyStops(this.mGLT).subscribe(data => {
      this.starShips = data;
      console.log(data);
    });
    
  }

  processingMessage(){
    this.snackBar.open('processing...', '', {
      duration: 3000,
      horizontalPosition: "right",
      verticalPosition: "top"
    })
  }

}
