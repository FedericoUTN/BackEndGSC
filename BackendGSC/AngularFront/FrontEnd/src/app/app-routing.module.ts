import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DetailsPersonComponent } from './CRUD/details-person/details-person.component';
import { PersonComponent } from './CRUD/person/person.component';
import { LoginMenuComponent } from './login-menu/login-menu.component';

const routes: Routes = [
  { path: 'login', component: LoginMenuComponent},
  { path: 'person/:id', component: DetailsPersonComponent},
  { path: 'person', component: PersonComponent},
  { path: '', redirectTo: '/login', pathMatch:'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
