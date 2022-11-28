import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth.guard';
import { DetailsPersonComponent } from './CRUD/details-person/details-person.component';
import { LoanComponent } from './CRUD/loan/loan.component';
import { PersonComponent } from './CRUD/person/person.component';
import { LoginMenuComponent } from './login-menu/login-menu.component';

const routes: Routes = [
  { path: 'login', component: LoginMenuComponent},
  { path: 'loans/:id', component: LoanComponent},
  { path: 'person/:id', component: DetailsPersonComponent},
  { path: 'person', component: PersonComponent, canActivate:[AuthGuard]},
  { path: '', redirectTo: '/login', pathMatch:'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
