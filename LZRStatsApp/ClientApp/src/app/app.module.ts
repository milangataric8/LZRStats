import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { GridJoggingComponent } from './grid-jogging/grid-jogging.component';
import { AddOrUpdateJoggingComponent } from './add-or-update-jogging/add-or-update-jogging.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { WorkoutService } from './_services/workout.service';
import { DecimalPipe } from '@angular/common';
import { DatePipe } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import * as _ from 'lodash';
import { AuthenticationService } from './_services/authentication.service';
import { UserService } from './_services/user.service';
import { LoginComponent } from './login/login.component';
import { BasicAuthInterceptor, ErrorInterceptor } from './_helpers';
import { RouterModule, Routes } from '@angular/router';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    GridJoggingComponent,
    AddOrUpdateJoggingComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule
  ],
  providers: [WorkoutService, DatePipe, DecimalPipe, AuthenticationService, UserService,
  { provide: HTTP_INTERCEPTORS, useClass: BasicAuthInterceptor, multi: true },
  { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }
