import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { PlayersService } from '../_services/players.service';
import { Player } from '../_models/player';
import { AppSettings } from '../constants';
import { DataTableSettings } from '../shared/data-table/settings/data-table-settings';

@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.css']
})
export class PlayersComponent implements OnInit {
  getDataUrl: string = `${AppSettings.API_ENDPOINT}Players`;
  tableSettings: DataTableSettings = new DataTableSettings();

  constructor(private playersService: PlayersService) { }

  ngOnInit() {
    this.createTableOptions();
  }

  createTableOptions() {
    this.tableSettings.columnHeaders = { firstName: 'First Name', lastName: 'Last Name', jerseyNumber: 'Jersey number' };
  }
}
