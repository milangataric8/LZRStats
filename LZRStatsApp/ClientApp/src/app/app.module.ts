import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { WorkoutService } from './_services/workout.service';
import { DecimalPipe, PercentPipe } from '@angular/common';
import { DatePipe } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import * as _ from 'lodash';
import { AuthenticationService } from './_services/authentication.service';
import { UserService } from './_services/user.service';
import { LoginComponent } from './login/login.component';
import { BasicAuthInterceptor, ErrorInterceptor } from './_helpers';
import { RouterModule, Routes } from '@angular/router';
import { TeamsComponent } from './teams/teams.component';
import { PlayersComponent } from './players/players.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {
  MatInputModule, MatPaginatorModule, MatProgressSpinnerModule,
  MatSortModule, MatTableModule, MatFormFieldModule, MatCardModule, MatDialogModule
} from '@angular/material';
import { DataTableComponent } from './shared/data-table/data-table.component';
import { NumberSignPipe } from './pipes/number-sign.pipe';
import { MasterDetailBaseComponent } from './shared/master-detail-base/master-detail-base.component';
import { DynamicPipe } from './pipes/dynamic.pipe';
import { PlayerComponent } from './players/player/player.component';
import { PlayerDetailComponent } from './player-detail/player-detail.component';
import { DeleteModalComponent } from './shared/delete-modal/delete-modal.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    TeamsComponent,
    PlayersComponent,
    DataTableComponent,
    NumberSignPipe,
    MasterDetailBaseComponent,
    DynamicPipe,
    PlayerComponent,
    PlayerDetailComponent,
    DeleteModalComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatFormFieldModule,
    MatInputModule,
    MatPaginatorModule,
    MatProgressSpinnerModule,
    MatSortModule,
    MatCardModule,
    MatDialogModule
  ],
  providers: [
    WorkoutService,
    DatePipe,
    DecimalPipe,
    NumberSignPipe,
    PercentPipe,
    AuthenticationService,
    UserService,
    { provide: HTTP_INTERCEPTORS, useClass: BasicAuthInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
  ],
  bootstrap: [AppComponent],
  exports: [
    MatTableModule,
    MatSortModule,
    MatFormFieldModule,
    MatInputModule,
    MatPaginatorModule
  ],
  entryComponents: [DeleteModalComponent]
})
export class AppModule { }
