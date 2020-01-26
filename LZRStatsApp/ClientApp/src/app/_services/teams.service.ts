import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Team } from '../_models/team';
import { AppSettings } from '../constants';

@Injectable({
  providedIn: 'root'
})
export class TeamsService {
  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<Team[]>(`${AppSettings.API_ENDPOINT}teams`);
  }

  getById(id:number){
    return this.http.get<Team>(`${AppSettings.API_ENDPOINT}teams/${id}`);
  }
}
