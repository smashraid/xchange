import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';

import { LoginComponent } from './login/login.component';
import { CalculatorComponent } from './calculator/calculator.component';

const routes: Routes = [
  { path: "", redirectTo: "/login", pathMatch: "full" },  
  { path: "calculator", component: CalculatorComponent },  
  { path: "login", component: LoginComponent }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
