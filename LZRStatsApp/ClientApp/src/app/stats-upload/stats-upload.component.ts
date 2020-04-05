import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { HttpEventType, HttpErrorResponse } from '@angular/common/http';
import { StatsService } from '../_services/stats.service';
import { catchError, map } from 'rxjs/operators';
import { of } from 'rxjs';

@Component({
  selector: 'app-stats-upload',
  templateUrl: './stats-upload.component.html',
  styleUrls: ['./stats-upload.component.css']
})
export class StatsUploadComponent implements OnInit {

  public progress: number;
  public message: string;
  public inProgress: boolean;
  @Output() public UploadFinished = new EventEmitter();

  constructor(private statsService: StatsService) { }

  ngOnInit() {
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

    this.statsService.upload(formData).pipe(
      map(event => {
        switch (event.type) {
          case HttpEventType.UploadProgress:
            this.progress = Math.round(event.loaded * 100 / event.total);
            break;
          case HttpEventType.Response:
            this.inProgress = false;
            this.message = 'Upload success.';
            this.UploadFinished.emit(event.body);
            return event;
        }
      }),
      catchError((error: HttpErrorResponse) => {
        this.inProgress = false;
        this.message = 'Upload failed.';
        return of(`Upload failed.`);
      })).subscribe((event: any) => {
        if (typeof (event) === 'object') {
          console.log(event.body);
        }
      });
  }
}
