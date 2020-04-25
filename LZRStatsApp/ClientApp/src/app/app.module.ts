import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { HttpClientModule, HTTP_INTERCEPTORS, HttpClient } from '@angular/common/http';
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
  MatSortModule, MatTableModule, MatFormFieldModule, MatCardModule, MatDialogModule, MatSelect, MatSelectModule, MatPaginatorIntl
} from '@angular/material';
import { DataTableComponent } from './shared/data-table/data-table.component';
import { NumberSignPipe } from './pipes/number-sign.pipe';
import { MasterDetailBaseComponent } from './shared/master-detail-base/master-detail-base.component';
import { DynamicPipe } from './pipes/dynamic.pipe';
import { PlayerComponent } from './players/player/player.component';
import { PlayerDetailComponent } from './player-detail/player-detail.component';
import { ConfirmModalComponent } from './shared/delete-modal/confirm-modal.component';
import { StatsUploadComponent } from './stats-upload/stats-upload.component';
import { AddEditModalComponent } from './shared/add-edit-modal/add-edit-modal/add-edit-modal.component';
import { TranslateLoader, TranslateModule, TranslateService } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { PercentSignPipe } from './pipes/percent-sign.pipe';
import { MatPaginatorI18nService } from './shared/data-table/mat-paginator-intl';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    TeamsComponent,
    PlayersComponent,
    DataTableComponent,
    NumberSignPipe,
    PercentSignPipe,
    MasterDetailBaseComponent,
    DynamicPipe,
    PlayerComponent,
    PlayerDetailComponent,
    ConfirmModalComponent,
    StatsUploadComponent,
    AddEditModalComponent
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
    MatDialogModule,
    MatSelectModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      },
      defaultLanguage: 'rs'
    })
  ],
  providers: [
    DatePipe,
    DecimalPipe,
    NumberSignPipe,
    PercentSignPipe,
    PercentPipe,
    AuthenticationService,
    UserService,
    { provide: HTTP_INTERCEPTORS, useClass: BasicAuthInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    {
      provide: MatPaginatorIntl,
      useClass: MatPaginatorI18nService,
    }
  ],
  bootstrap: [AppComponent],
  exports: [
    MatTableModule,
    MatSortModule,
    MatFormFieldModule,
    MatInputModule,
    MatPaginatorModule
  ],
  entryComponents: [ConfirmModalComponent, AddEditModalComponent]
})
export class AppModule { }

export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http);
}
