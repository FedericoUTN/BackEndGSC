
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs';
import { AuthenticationService } from '../authentication.service';
import { LoginServiceService } from '../services/login-service.service';

@Component({
  selector: 'app-login-menu',
  templateUrl: './login-menu.component.html',
  styleUrls: ['./login-menu.component.css']
})
export class LoginMenuComponent implements OnInit {

  loading = false;
  submitted = false;
  returnUrl!: string;
  

  loginGroup = this.formBuilder.group({
    usernameControl : ['', Validators.required],
    passwordControl : ['', Validators.required]
  })
 
  constructor(
  private formBuilder : FormBuilder,
  private route : Router,
  private activedRoute: ActivatedRoute,
  private router: Router,
  private authenticationService: AuthenticationService,
  private service : LoginServiceService) {
    
   }

  ngOnInit(): void {
    if (this.authenticationService.currentUserValue) {
      this.router.navigate(['/']);
      };
      this.returnUrl = this.activedRoute.snapshot.queryParams['returnUrl'] || '/person';
  }
  get f() { return this.loginGroup.controls; }

  onSubmit() : void{
    
    this.submitted = true;
  
 
    if (this.loginGroup.invalid) {
      return;
      }
      this.loading = true;
      this.authenticationService.login(this.f.usernameControl.value!, this.f.passwordControl.value!)
      .pipe(first())
      .subscribe(
      {
        complete: ()=>{
          console.log('login correcto');
      this.router.navigate([this.returnUrl]);
        }
        
      });
      }
  
  
  Reset() : void{
      this.loginGroup.reset();
  }


}
