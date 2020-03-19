import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { HttpEventType } from '@angular/common/http';
import { StatsService } from '../_services/stats.service';

@Component({
  selector: 'app-stats-upload',
  templateUrl: './stats-upload.component.html',
  styleUrls: ['./stats-upload.component.css']
})
export class StatsUploadComponent implements OnInit {

  public progress: number;
  public message: string;
  @Output() public UploadFinished = new EventEmitter();

  constructor(private statsService: StatsService) { }

  ngOnInit() {
  }

  public uploadFile = (files: string | any[]) => {
    if (files.length === 0) {
      return;
    }

    const fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);
    this.statsService.upload(formData).subscribe(event => {
      if (event.type === HttpEventType.UploadProgress) {
        this.progress = Math.round(100 * event.loaded / event.total);
      } else
        if (event.type === HttpEventType.Response) {
          this.message = 'Upload success.';
          this.UploadFinished.emit(event.body);
        }
    });
  }
}
