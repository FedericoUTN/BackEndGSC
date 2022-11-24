import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../entities/user';
import { LoginServiceService } from '../services/login-service.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit{
  constructor(
    private router : Router,
    private service : LoginServiceService
    //,private authserv : AuthenticationService
  ){}
    isAuth : boolean = true;
    user! : User;

    ngOnInit(): void {
      this.isAuth = this.service.isAuthenticated();
      
    }

}
