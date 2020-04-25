
import { Component, Inject, Output, EventEmitter } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-add-edit-modal',
  templateUrl: 'add-edit-modal.component.html',
  styleUrls: ['./add-edit-modal.component.css']
})
export class AddEditModalComponent {
  invalidProps = ['id', 'teamId', 'playerId', 'gameId'];
  dialogTitle: string;
  item: any;
  @Output() submitClicked = new EventEmitter<any>();

  constructor(private dialogRef: MatDialogRef<AddEditModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
    this.dialogTitle = this.data.dialogTitle;
    this.item = this.data.item;
  }

  close() {
    this.dialogRef.close();
  }

  onChange(prop: any) {
    if (typeof this.item[prop.key] === 'number') {
      this.item[prop.key] = +prop.value;
    } else {
      this.item[prop.key] = prop.value;
    }
  }

  propIsValid(prop: string): boolean {
    return this.invalidProps.indexOf(prop) === -1;
  }
}
