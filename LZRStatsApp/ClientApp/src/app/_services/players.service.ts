import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AppSettings } from '../constants';
import { Player } from '../_models/player';

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
}
