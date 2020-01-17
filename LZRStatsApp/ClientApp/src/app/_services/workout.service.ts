import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AppSettings } from '../constants';
@Injectable({
  providedIn: 'root'
})
export class WorkoutService {
  private headers: HttpHeaders;
  private accessPointUrl: string;
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
    this.accessPointUrl = AppSettings.API_ENDPOINT + 'Workouts';
  }

  public get() {
    // Get all jogging data
    return this.http.get(this.accessPointUrl, this.httpOptions);
  }

  public add(workout) {
    workout.id = 0;
    return this.http.post(this.accessPointUrl, workout, this.httpOptions);
  }

  public remove(payload) {
    return this.http.delete(this.accessPointUrl + '/' + payload.id, { headers: this.headers });
  }

  public update(payload) {
    return this.http.put(this.accessPointUrl + '/' + payload.id, payload, { headers: this.headers });
  }
}
