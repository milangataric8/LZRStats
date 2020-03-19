import { Component, Inject, Output, EventEmitter } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { PlayersService } from 'src/app/_services/players.service';


@Component({
  selector: 'app-delete-modal',
  templateUrl: 'delete-modal.component.html',
  styleUrls: ['./delete-modal.component.css']
})
export class DeleteModalComponent {
  dialogTitle: string;
  dialogText: string;
  item: any;
  @Output() submitClicked = new EventEmitter<any>();
  constructor(
    private dialogRef: MatDialogRef<DeleteModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public playersService: PlayersService) {
    this.dialogTitle = this.data.dialogTitle;
    this.dialogText = this.data.dialogText;
    this.item = this.data.item;
  }

  close() {
    this.dialogRef.close();
  }

  delete = () => {
    console.log(this.item);
    this.playersService.deletePlayer(this.item.id)
      .subscribe(
        x => {
          this.close();
        },
        error => {
          console.error('Player deleting failed!');
        });
  }
}
