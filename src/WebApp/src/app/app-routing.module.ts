import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CreditsComponent } from './views/credits/credits.component';
import { ResupplyCalculatorComponent } from './views/resupply-calculator/resupply-calculator.component';

const routes: Routes = [
  {
    path: "",
    component: ResupplyCalculatorComponent
  },
  {
    path: "credits",
    component: CreditsComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
