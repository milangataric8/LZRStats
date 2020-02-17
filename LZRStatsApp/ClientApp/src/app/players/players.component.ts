import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { PlayersService } from '../_services/players.service';
import { Player } from '../_models/player';
import { AppSettings } from '../constants';
import { DataTableSettings } from '../shared/data-table/settings/data-table-settings';
import { ButtonType, ColumnType } from '../shared/enums/enums';
import { ColumnInfo } from '../shared/data-table/column-header-models/column-info';

@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.css']
})
export class PlayersComponent implements OnInit {
  getTableDataUrl: string = `${AppSettings.API_ENDPOINT}Players`;

  constructor(private playersService: PlayersService) { }

  ngOnInit() {
  }

  createTableOptions() {
    const firstName: ColumnInfo = new ColumnInfo('First name', ColumnType.Link);
    const lastName: ColumnInfo = new ColumnInfo('Last name');
    const jerseyNumber: ColumnInfo = new ColumnInfo('Jersey number', ColumnType.Number);
    const headers = { firstName, lastName, jerseyNumber };

    const settings = new DataTableSettings(headers, undefined, ButtonType.Edit, ButtonType.Remove);

    return settings;
  }

  onEdit(event: Player) {
    this.playersService.update(event);
  }

  onDelete(event: Player) {
    this.playersService.remove(event);
  }

  onShowDetails(event: Player) {
    //TODO player details pop-up or new page?
    console.log('details');
  }

  onItemClicked(event: Player) {
    //TODO show player details like on show details btn(maybe remove show details btn?)
    console.log(event);
  }
}
