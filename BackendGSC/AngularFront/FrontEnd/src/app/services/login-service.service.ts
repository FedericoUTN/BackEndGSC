import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class LoginServiceService {
  
  
  constructor(private http : HttpClient) { }

  getToken(){
    let token : string = "";
    return this.http.post(environment.URL + 'api/Accounts/login', token);
  }
  isAuthenticated(): boolean{
    return !!localStorage.getItem('token');
    
  }
 

}


