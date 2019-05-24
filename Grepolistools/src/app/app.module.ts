import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {MaterialModule} from './material/material.module';
import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {WorldComponent} from './world/world.component';
import {ServerComponent} from './server/server.component';
import {HttpClientModule} from '@angular/common/http';
import {FlexLayoutModule} from '@angular/flex-layout';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {LayoutModule} from '@angular/cdk/layout';
import {RouterModule} from '@angular/router';
import {PageNotFoundComponent} from './page-not-found/page-not-found.component';
import {httpInterceptorProviders} from './interceptors';
import {UserModule} from './user/user.module';
import {
  MatButtonModule,
  MatIconModule,
  MatListModule,
  MatSidenavModule,
  MatSortModule,
  MatTableModule,
  MatToolbarModule
} from '@angular/material';
import {NavComponent} from './nav/nav.component';
import {AddCitybuilderComponent} from './citybuilder/add-citybuilder/add-citybuilder.component';
import {WorldsNavComponent} from './worlds-nav/worlds-nav.component';
import {PlayerComponent} from './player/player.component';
import { AllianceComponent } from './alliance/alliance.component';

@NgModule({
  declarations: [
    AppComponent,
    WorldComponent,
    ServerComponent,
    PageNotFoundComponent,
    NavComponent,
    AddCitybuilderComponent,
    WorldsNavComponent,
    PlayerComponent,
    AllianceComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MaterialModule,
    FlexLayoutModule,
    FormsModule,
    LayoutModule,
    ReactiveFormsModule,
    UserModule,
    MatToolbarModule,
    RouterModule,
    AppRoutingModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    MatTableModule,
    MatSortModule
  ],
  providers: [httpInterceptorProviders],
  bootstrap: [AppComponent]
})
export class AppModule
{
}
