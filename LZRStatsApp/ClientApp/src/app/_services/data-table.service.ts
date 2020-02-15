import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DataTableService {

  constructor(private httpClient:HttpClient) { }

  getData(apiUrl:string){
    return this.httpClient.get(apiUrl);
  }
}
