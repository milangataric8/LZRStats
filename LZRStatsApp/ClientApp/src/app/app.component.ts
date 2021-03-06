import { Component } from '@angular/core';
import { AuthenticationService } from './_services/authentication.service';
import { Router } from '@angular/router';
import { User } from './_models/user';
import { TranslateService } from '@ngx-translate/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  currentUser: User;
  languages = [{code:'rs', resourceName:'HOME.serbian'}, {code:'en', resourceName:'HOME.english'}];
  selectedLanguage: string;
  constructor(private authService: AuthenticationService, private router: Router, private translate: TranslateService) {
    this.authService.currentUser.subscribe(x => this.currentUser = x);
    this.selectedLanguage = this.languages[0].code;
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['login']);
  }

  changeLanguage() {
    this.translate.setDefaultLang(this.selectedLanguage);
  }
}
