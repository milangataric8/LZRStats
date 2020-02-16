import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../_services/authentication.service';
import { Router } from '@angular/router';
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  currentUser: User;

  constructor(private userService: UserService, private authService: AuthenticationService, private router: Router) {
    this.authService.currentUser.subscribe(x => this.currentUser = x);
  }

  ngOnInit() {
    this.userService.getAll().subscribe(x => console.log(x));
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['login']);
  }
}
