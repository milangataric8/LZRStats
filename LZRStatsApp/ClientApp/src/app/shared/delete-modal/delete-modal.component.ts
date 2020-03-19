import { Component } from "@angular/core";
import { MatDialogRef } from "@angular/material";
import { PlayersService } from "src/app/_services/players.service";


@Component({
    selector: 'app-delete-modal',
    templateUrl: 'delete-modal.component.html',
    styleUrls: ['./delete-modal.component.css']
  })
  export class DeleteModalComponent {

    constructor(private dialogRef: MatDialogRef<DeleteModalComponent>, private playersService: PlayersService) {

    }

    close() {
      this.dialogRef.close();
    }

    delete = (playerId: Number) => {
      this.playersService.deletePlayer(playerId)
        .subscribe(
          x => {
            this.close();
          },
          error => { console.error('Player deleting failed!');
        });
    }
  }
