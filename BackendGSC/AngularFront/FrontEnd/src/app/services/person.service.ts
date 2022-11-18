import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import { Person } from '../entities/person';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Iperson } from '../entities/iperson';
@Injectable({
  providedIn: 'root'
})
export class PersonService {
  
  constructor(private http : HttpClient) { }

  addPerson(person : Person){
    return this.http.post<Person>(`${environment.URL}api/person`, person )
  }
  getAll():Observable<Person[]>{
    return this.http.get<Person[]>(`${environment.URL}api/person`)
  }
  deletePerson(id : number){
    return this.http.delete(`${environment.URL}api/person/${id}`)
  }
  getById(id : number){
    return this.http.get<Person>(`${environment.URL}api/person/${id}`)
  }
  updatePerson(person : any){
    return this.http.put(`${environment.URL}api/person`, person)
  }
}
