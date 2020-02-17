import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { PlayersService } from '../_services/players.service';
import { Player } from '../_models/player';
import { AppSettings } from '../constants';
import { DataTableSettings } from '../shared/data-table/settings/data-table-settings';
import { ButtonType, ColumnType } from '../shared/enums/enums';
import { ColumnInfo } from '../shared/data-table/column-header-models/column-info';
import { DataTableService } from '../_services/data-table.service';
import { MasterDetailBaseComponent } from '../shared/master-detail-base/master-detail-base.component';

@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.css']
})
export class PlayersComponent extends MasterDetailBaseComponent implements OnInit {
  getTableDataUrl: string = this.apiUrl;

  constructor(dataTableService: DataTableService) {
    super(`${AppSettings.API_ENDPOINT}players`, dataTableService);
  }

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
}
