import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { LoginMenuComponent } from './login-menu/login-menu.component';
import { PersonComponent, PizzaPartyAnnotatedComponent } from './CRUD/person/person.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { DetailsPersonComponent } from './CRUD/details-person/details-person.component';
import { JwtInterceptor } from './jwt.interceptor';
import { AuthGuard } from './auth.guard';
import { LoanComponent } from './CRUD/loan/loan.component';
import { FooterComponent } from './footer/footer.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatButtonModule} from '@angular/material/button';
import {MatSelectModule} from '@angular/material/select';
import {MatInputModule} from '@angular/material/input';
import {MatCardModule} from '@angular/material/card';
import {MatTableModule} from '@angular/material/table';
import {MatChipsModule} from '@angular/material/chips';
import {MatExpansionModule} from '@angular/material/expansion';
import {MatIconModule} from '@angular/material/icon';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {MatMenuModule} from '@angular/material/menu';


@NgModule({
  declarations: [
    HeaderComponent,
    AppComponent,
    LoginMenuComponent,
    PersonComponent,
    DetailsPersonComponent,
    LoanComponent,
    FooterComponent,
    PizzaPartyAnnotatedComponent
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatFormFieldModule,
    MatButtonModule,
    MatSelectModule,
    MatInputModule,
    BrowserAnimationsModule,
    MatCardModule,
    MatTableModule,
    MatChipsModule,
    MatExpansionModule,
    MatIconModule,
    MatSnackBarModule,
    MatMenuModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
