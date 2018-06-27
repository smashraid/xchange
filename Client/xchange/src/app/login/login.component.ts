import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { AuthenticationService } from '../authentication.service';
import { Login } from '../login';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  login: Login = new Login();

  constructor(private authenticationService: AuthenticationService,
    private router: Router) {
    this.login.userName = "smashraid@gmail.com";
    this.login.password = "P@$$123";
  }

  ngOnInit() {

  }

  onSubmit() {
    this.authenticationService.createToken(this.login)
    .subscribe(() => this.router.navigate(['/calculator']));   
  }
}
