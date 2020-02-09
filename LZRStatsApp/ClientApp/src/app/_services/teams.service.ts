import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Team } from '../_models/team';
import { AppSettings } from '../constants';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

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

  findTeams(
    id:number, filter = '', sortOrder = 'asc',
    pageNumber = 0, pageSize = 3):  Observable<Team[]> {

    return this.http.get(`${AppSettings.API_ENDPOINT}teams`, {
        params: new HttpParams()
            .set('courseId', id.toString())
            .set('filter', filter)
            .set('sortOrder', sortOrder)
            .set('pageNumber', pageNumber.toString())
            .set('pageSize', pageSize.toString())
    }).pipe(
        map(res =>  res["payload"])
    );
}
}
