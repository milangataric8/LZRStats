import { Component } from '@angular/core';
import { AuthenticationService } from './_services/authentication.service';
import { Router } from '@angular/router';
import { User } from './_models/user';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  currentUser: User;

  constructor(private authService: AuthenticationService, private router: Router, private translate: TranslateService) {
    this.authService.currentUser.subscribe(x => this.currentUser = x);
    translate.setDefaultLang('rs');
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['login']);
  }
}
