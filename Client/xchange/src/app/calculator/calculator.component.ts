import { Component, OnInit } from '@angular/core';
import { interval } from 'rxjs';
import { Router } from '@angular/router';

import { AuthenticationService } from '../authentication.service';
import { ConvertService } from '../convert.service';
import { Currency } from '../currency';
import { ConvertResponse } from '../convert-response';

@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.scss']
})
export class CalculatorComponent implements OnInit {
  currency: Currency = new Currency();
  fromAmount: number;
  toAmount: number;
  rate: number = 0;

  constructor(private authenticationService: AuthenticationService,
    private convertService: ConvertService,
    private router: Router) { }

  ngOnInit() {
    if(!this.authenticationService.isAuthenticated()){
      this.router.navigate(['/login']);
    }
    this.getRate();

    interval(600000).subscribe(n => this.getRate());
  }

  getRate(): void {
    this.convertService.getCurrencyAmount(this.currency)
      .subscribe((data: ConvertResponse) => {
        console.log(data);
        if (data.success) {
          this.rate = data.rate;
        }
      });
  }

  onSubmit(): void {
    this.toAmount = this.rate * +this.fromAmount;
  }

}
