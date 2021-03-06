import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AppSettings } from '../constants';
import { User } from '../_models';

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    private currentUserSubject: BehaviorSubject<User>;
    public currentUser: Observable<User>;

    constructor(private http: HttpClient) {
        this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
        this.currentUser = this.currentUserSubject.asObservable();
    }

    public get currentUserValue(): User {
        return this.currentUserSubject.value;
    }

    isAuthenticated(): boolean {
        return !!this.currentUserSubject.value; // !! to force boolean
    }

    login(username: string, password: string) {
        const user = { username: username, password: password };
        return this.http.post<any>(`${AppSettings.API_ENDPOINT}users/authenticate`, user)
            .pipe(map(result => {
                // store user details and basic auth credentials in local storage to keep user logged in between page refreshes
                result.authdata = window.btoa(username + ':' + password);
                localStorage.setItem('currentUser', JSON.stringify(result));
                this.currentUserSubject.next(result);
                return user;
            }));
    }

    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem('currentUser');
        this.currentUserSubject.next(null);
    }
}
