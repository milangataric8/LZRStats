import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppSettings } from '../constants';

@Injectable({
  providedIn: 'root'
})
export class StatsService {

  constructor(private http: HttpClient) { }

  upload(formData: FormData) {
    return this.http.post(`${AppSettings.API_ENDPOINT}statsImport`, formData, { reportProgress: true, observe: 'events' });
  }
}
