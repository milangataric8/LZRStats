import { Component, Inject, Output, EventEmitter } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { PlayersService } from 'src/app/_services/players.service';


@Component({
  selector: 'app-confirm-modal',
  templateUrl: 'confirm-modal.component.html',
  styleUrls: ['./confirm-modal.component.css']
})
export class ConfirmModalComponent {
  dialogTitle: string;
  dialogText: string;
  item: any;
  @Output() submitClicked = new EventEmitter<any>();

  constructor(private dialogRef: MatDialogRef<ConfirmModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
    this.dialogTitle = this.data.dialogTitle;
    this.dialogText = this.data.dialogText;
    this.item = this.data.item;
  }

  close() {
    this.dialogRef.close();
  }

  confirm = () => {
    console.log(this.item);
  }
}
