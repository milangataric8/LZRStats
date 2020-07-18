import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { HttpEventType, HttpErrorResponse } from '@angular/common/http';
import { StatsService } from '../_services/stats.service';
import { catchError, map } from 'rxjs/operators';
import { of } from 'rxjs';
import { SnackbarService } from '../_services/snackbar.service';
import { TranslateService } from '@ngx-translate/core';
import { SeasonService } from '../_services/season.service';

@Component({
  selector: 'app-stats-upload',
  templateUrl: './stats-upload.component.html',
  styleUrls: ['./stats-upload.component.css']
})
export class StatsUploadComponent implements OnInit {

  public progress: number;
  public message: string;
  public inProgress: boolean;
  public selectedSeason: any;
  public seasons: any;
  public selectedLeague: string;
  public leagues: string[];
  @Output() public UploadFinished = new EventEmitter();

  constructor(private statsService: StatsService, private snackbarService: SnackbarService, private translate: TranslateService,
    private seasonService: SeasonService) { }

  ngOnInit() {
    this.leagues = ['A', 'B'];
    this.seasonService.getAll()
      .subscribe((result) => {
        this.seasons = result;
      });
  }

  public uploadFile = (files: string | any[]) => {
    if (files.length === 0) {
      return;
    }
    this.inProgress = true;
    this.message = '';
    const filesToUpload = <File[]>files;
    const formData = new FormData();
    for (let index = 0; index < filesToUpload.length; index++) {
      const file = filesToUpload[index];
      formData.append('file' + file.name, file, file.name);
    }

    formData.append('season', this.selectedSeason);
    formData.append('league', this.selectedLeague);
    this.statsService.upload(formData).pipe(
      map(event => {
        switch (event.type) {
          case HttpEventType.UploadProgress:
            this.progress = Math.round(event.loaded * 100 / event.total);
            break;
          case HttpEventType.Response:
            this.inProgress = false;
            this.snackbarService.showInfo('Upload success');
            this.UploadFinished.emit(event.body);
            return event;
        }
      }),
      catchError((error: HttpErrorResponse) => {
        this.inProgress = false;
        this.snackbarService.showError('Upload failed');

        return of(`Upload failed.`);
      })).subscribe((event: any) => {
        if (typeof (event) === 'object') {
          console.log(event.body);
        }
      });
  }
}
