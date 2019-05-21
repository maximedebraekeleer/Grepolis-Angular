import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {PageNotFoundComponent} from './page-not-found/page-not-found.component';
import {LoginComponent} from './user/login/login.component';
import {RegisterComponent} from './user/register/register.component';
import {HomeComponent} from './home/home.component';
import {AddCitybuilderComponent} from './citybuilder/add-citybuilder/add-citybuilder.component';
import {AuthGuard} from './user/auth.guard';

const routes: Routes = [
  { path: 'home', component: HomeComponent},
  { path: 'citybuilder/add', component: AddCitybuilderComponent, canActivate: [AuthGuard]},
  { path: '', redirectTo: 'home', pathMatch: 'full'},
  { path: '**', component: PageNotFoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
