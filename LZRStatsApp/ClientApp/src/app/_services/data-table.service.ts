import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DataTableService {
  private headers: HttpHeaders;

  constructor(private httpClient: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  }

  getData(accessPointUrl: string){
    return this.httpClient.get(accessPointUrl);
  }

  add(accessPointUrl: string, payload: any) {
    return this.httpClient.post(accessPointUrl, payload, { headers: this.headers });
  }

  remove(accessPointUrl: string, payload: any) {
    return this.httpClient.delete(`${accessPointUrl}/${payload.id}`, { headers: this.headers });
  }

  update(accessPointUrl: string, payload: any) {
    return this.httpClient.put(`${accessPointUrl}/${payload.id}`, payload, { headers: this.headers });
  }
}
