import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { PlayersService } from '../_services/players.service';
import { Player } from '../_models/player';
import { AppSettings } from '../constants';
import { PlayersTableHeader } from '../shared/data-table/column-header-models/players-table-header';

@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.css']
})
export class PlayersComponent implements OnInit {
  tableData: Player[] = [];
  getDataUrl: string = `${AppSettings.API_ENDPOINT}Players`;
  columnHeader: PlayersTableHeader;

  constructor(private playersService: PlayersService) { }

  ngOnInit() {
    this.setColumnHeaders();
  }

  setColumnHeaders(){
    this.columnHeader = { firstName: 'First Name', lastName: 'Last Name', jerseyNumber: 'Jersey number' };
  }
}
