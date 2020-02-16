import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { PlayersService } from '../_services/players.service';
import { Player } from '../_models/player';
import { AppSettings } from '../constants';
import { DataTableSettings } from '../shared/data-table/settings/data-table-settings';
import { ButtonType } from '../shared/enums/enums';

@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.css']
})
export class PlayersComponent implements OnInit {
  getDataUrl: string = `${AppSettings.API_ENDPOINT}Players`;

  constructor(private playersService: PlayersService) { }

  ngOnInit() {
  }

  createTableOptions() {
    const headers = { firstName: 'First Name', lastName: 'Last Name', jerseyNumber: 'Jersey number', gamesPlayed: 'Games played'};
    const settings = new DataTableSettings(headers, undefined, ButtonType.Edit, ButtonType.Remove);

    return settings;
  }

  onEdit(event:Player){
    this.playersService.update(event);
  }

  onDelete(event:Player){
    this.playersService.remove(event);
  }

  onShowDetails(event:Player){
    //TODO player details pop-up or new page?
    console.log('details');
  }
}
