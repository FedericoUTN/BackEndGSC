import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from './entities/user';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

private currentUserSubject: BehaviorSubject<User>;
public currentUser: Observable<User>;

constructor(private http: HttpClient) {
this.currentUserSubject = new BehaviorSubject<User>(
JSON.parse(localStorage.getItem('currentUser')!));
this.currentUser = this.currentUserSubject.asObservable();
}
public get currentUserValue(): User {
return this.currentUserSubject.value;
}

login(username: string, password: string) 
{
  return this.http.post<any>(`${environment.URL}api/Accounts/login`, { username, password })
  .pipe(map(user => {
  localStorage.setItem('currentUser', JSON.stringify(user));
  this.currentUserSubject.next(user);
  console.log(user); //quitar luego
  return user;
  }));
}
  
logout() 
{
  localStorage.removeItem('currentUser');
  this.currentUserSubject.next(<User>{});
}

}
