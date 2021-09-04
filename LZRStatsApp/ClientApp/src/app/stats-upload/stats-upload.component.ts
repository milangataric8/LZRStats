import { Component, OnInit, EventEmitter, Output, ViewChild, ElementRef } from '@angular/core';
import { HttpEventType, HttpErrorResponse } from '@angular/common/http';
import { StatsService } from '../_services/stats.service';
import { catchError, map } from 'rxjs/operators';
import { of } from 'rxjs';
import { SnackbarService } from '../_services/snackbar.service';
import { TranslateService } from '@ngx-translate/core';
import { SeasonService } from '../_services/season.service';
import { Season } from '../_models/season';
import { AppSettings } from '../constants';

@Component({
  selector: 'app-stats-upload',
  templateUrl: './stats-upload.component.html',
  styleUrls: ['./stats-upload.component.css']
})
export class StatsUploadComponent implements OnInit {

  public progress: number;
  public message: string;
  public inProgress: boolean;
  public selectedSeasonId: number;
  public seasons: Season[];
  public selectedLeague: string = AppSettings.DEFAULT_LEAGUE;
  public leagues: string[] = AppSettings.LEAGUES;
  public gameTypes = AppSettings.GAME_TYPES;
  public gameType: number = AppSettings.DEFAULT_GAME_TYPE;
  @ViewChild('file', { static: true })
  filesInput: ElementRef;
  fileImportResults: any[];
  constructor(private statsService: StatsService,
    private snackbarService: SnackbarService,
    private translate: TranslateService,
    private seasonService: SeasonService) { }

  ngOnInit() {
    this.seasonService.getAll()
      .subscribe((result: Season[]) => {
        this.seasons = result;
        this.selectedSeasonId = result[result.length - 1].id;
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

    formData.append('seasonId', this.selectedSeasonId.toString());
    formData.append('league', this.selectedLeague);
    this.statsService.import(formData).subscribe((result: any) => {
        // TODO return file import results
        this.inProgress = false;
        this.snackbarService.showInfo('Upload success');
        this.resetFilesInput();
      },
      (error) => {
        this.inProgress = false;
        this.snackbarService.showError('Upload failed');
        this.resetFilesInput();
      });
  }

  private resetFilesInput() {
    this.filesInput.nativeElement.value = '';
  }
}
