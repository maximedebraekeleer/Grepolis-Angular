import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {PageNotFoundComponent} from './page-not-found/page-not-found.component';
import {AddCitybuilderComponent} from './citybuilder/add-citybuilder/add-citybuilder.component';
import {AuthGuard} from './user/auth.guard';
import {PlayerComponent} from './player/player.component';
import {ServerComponent} from './server/server.component';
import {WorldComponent} from './world/world.component';

const routes: Routes = [
  {path: 'citybuilder/add', component: AddCitybuilderComponent, canActivate: [AuthGuard]},
  {path: 'server/:server', component: ServerComponent},
  {path: 'server', component: ServerComponent},
  {path: 'world/:server/:world', component: WorldComponent},
  {path: 'player/:server/:world/:name', component: PlayerComponent},
  {path: '', redirectTo: 'server', pathMatch: 'full'},
  {path: '**', component: PageNotFoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {onSameUrlNavigation: 'reload'})],
  exports: [RouterModule]
})
export class AppRoutingModule
{
}
