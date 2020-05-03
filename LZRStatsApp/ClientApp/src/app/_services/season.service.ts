import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppSettings } from '../constants';

@Injectable({
  providedIn: 'root'
})
export class SeasonService {
  private accessPointUrl = `${AppSettings.API_ENDPOINT}Seasons`;
  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get(this.accessPointUrl);
  }
}
