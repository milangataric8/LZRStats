import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AppSettings } from '../constants';
import { Player } from '../_models/player';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PlayersService {
  private headers: HttpHeaders;
  private accessPointUrl = `${AppSettings.API_ENDPOINT}Players`;
  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  }

  getAll() {
    return this.http.get(this.accessPointUrl);
  }

  getBy = (playerId: Number): Observable<any> =>{
    return this.http
      .get(`${AppSettings.API_ENDPOINT}Players/${playerId}`);
  }

  deletePlayer(playerId: Number) {
    return this.http.delete(`${AppSettings.API_ENDPOINT}Players/${playerId}`);
  }
}
