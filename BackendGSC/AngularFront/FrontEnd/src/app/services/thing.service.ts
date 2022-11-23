import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Thing } from '../entities/thing';

@Injectable({
  providedIn: 'root'
})
export class ThingService {

  constructor(
    private http : HttpClient
  ) { }
  getAll(){
    return this.http.get<Thing[]>(`${environment.URL}api/ThingAPI`)
  }


}
