import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AppSettings } from '../constants';
import { Player } from '../_models/player';

@Injectable({
  providedIn: 'root'
})
export class PlayersService {
  private headers: HttpHeaders;
  private accessPointUrl: string = `${AppSettings.API_ENDPOINT}Players`;
  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  }

  getAll() {
    return this.http.get(`${AppSettings.API_ENDPOINT}Players`);
  }

  public add(payload: Player) {
    return this.http.post(this.accessPointUrl, payload, {headers: this.headers});
  }

  public remove(payload: Player) {
    return this.http.delete(`${this.accessPointUrl}/${payload.id}`, {headers: this.headers});
  }

  public update(payload: Player) {
    return this.http.put(`${this.accessPointUrl}/${payload.id}`, payload, {headers: this.headers});
  }
}
