import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {NavComponent} from './nav/nav.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { WorldComponent } from './world/world.component';
import { ServerComponent } from './server/server.component';
import {HttpClientModule} from '@angular/common/http';
import {MatSidenavModule, MatToolbarModule, MatButtonModule, MatIconModule, MatListModule, MatSelectModule} from '@angular/material';
import { FlexLayoutModule } from '@angular/flex-layout';
import {FormsModule} from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    WorldComponent,
    ServerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatSidenavModule,
    FlexLayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatListModule,
    MatSelectModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
