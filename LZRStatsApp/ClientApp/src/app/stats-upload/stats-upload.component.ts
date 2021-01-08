import { Component, OnInit, EventEmitter, Output, ViewChild, ElementRef } from '@angular/core';
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
  public gameTypes = [{ name: 'Regular season', value: 0 }, { name: 'Playoff game', value: 1 }];
  public gameType: number;
  @Output() public UploadFinished = new EventEmitter();
  @ViewChild('file', {static: true})
  filesInput: ElementRef;
  fileImportResults: any[];
  constructor(private statsService: StatsService,
    private snackbarService: SnackbarService,
    private translate: TranslateService,
    private seasonService: SeasonService) { }

  ngOnInit() {
    this.leagues = ['A', 'B']; // TODO read from config file or db
    this.selectedLeague = this.leagues[0];
    this.seasonService.getAll()
      .subscribe((result: any[]) => { // TODO create season model
        this.seasons = result;
        this.selectedSeason = result[result.length - 1].id;
      });
      this.gameType = this.gameTypes[0].value;
      this.fileImportResults = [{ name: 'file1', imported: true}, { name: 'file2', imported: false}]; // TODO remove
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

    formData.append('seasonId', this.selectedSeason);
    formData.append('league', this.selectedLeague);
    this.statsService.import(formData).pipe(
      map(event => {
        // TODO return file import results
        switch (event.type) {
          case HttpEventType.UploadProgress:
            this.progress = Math.round(event.loaded * 100 / event.total);
            break;
          case HttpEventType.Response:
            this.inProgress = false;
            this.snackbarService.showInfo('Upload success');
            this.UploadFinished.emit(event.body);
            this.resetFilesInput();
            return event;
        }
      }),
      catchError((error: HttpErrorResponse) => {
        this.inProgress = false;
        this.snackbarService.showError('Upload failed');
        this.resetFilesInput();
        return of(`Upload failed.`);
      })).subscribe((event: any) => {
        if (typeof (event) === 'object') {
          console.log(event.body);
        }
      });
  }

  private resetFilesInput(){
    this.filesInput.nativeElement.value = "";
  }
}
