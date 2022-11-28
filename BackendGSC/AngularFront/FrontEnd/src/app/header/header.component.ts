import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../authentication.service';
import { User } from '../entities/user';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit{
  constructor(
    private router : Router,
    private service : AuthenticationService
    
  ){}
    private _isAuth : boolean = false;
    user! : User;

    get isAuth(): boolean{
      return this._isAuth
    }
    set isAuth(value : boolean){
      this._isAuth = value;
    }
    ngOnInit(): void {
      this.isLogged(); 
    }
    isLogged(){
      this.service.currentUser.subscribe(res=>{
        if(res.token){
          this.isAuth = true;
          this.user = this.service.currentUserValue;
          return;
        }
          this.isAuth = false;
      })
      
    }
    logOut(){
      this.service.logout();
      this.isAuth = false;
      this.router.navigate(['/login']);
    }
    

}
