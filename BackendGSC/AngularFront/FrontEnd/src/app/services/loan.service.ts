import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Loan } from '../entities/loan';

@Injectable({
  providedIn: 'root'
})
export class LoanService {

  constructor(private http : HttpClient) { }

  getAllbyIdPerson(id : number){
    return this.http.get<Loan[]>(environment.URL + `api/Loan?id=${id}`)
  }

  addLoan(loan : Loan){
    return  this.http.post<Loan>(environment.URL + `api/Loan`, loan);
  }
}
