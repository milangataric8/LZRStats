import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';

import { PlayersService } from '../_services/players.service';
import { Player } from '../_models/player';
import { AppSettings } from '../constants';
import { DataTableSettings } from '../shared/data-table/settings/data-table-settings';
import { ColumnInfo } from '../shared/data-table/column-header-models/column-info';
import { DataTableService } from '../_services/data-table.service';
import { MasterDetailBaseComponent } from '../shared/master-detail-base/master-detail-base.component';
import { NumberSignPipe } from '../pipes/number-sign.pipe';
import { PercentPipe } from '@angular/common';
import { TableActionButton } from '../shared/data-table/settings/table-action-button';
import { ActionType } from '../shared/enums/enums';
import { MatDialog } from '@angular/material';

@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.css']
})
export class PlayersComponent extends MasterDetailBaseComponent implements OnInit {

  getTableDataUrl: string = this.apiUrl;
  @Output() deleteButtonClicked: EventEmitter<any> = new EventEmitter();

  constructor(dataTableService: DataTableService, private router: Router, public dialog: MatDialog) {
    super(`${AppSettings.API_ENDPOINT}players`, dataTableService, dialog);
  }

  ngOnInit() {
  }

  createTableOptions() {
    const firstName: ColumnInfo = new ColumnInfo('First name');
    const lastName: ColumnInfo = new ColumnInfo('Last name');
    const jerseyNumber: ColumnInfo = new ColumnInfo('Jersey number', NumberSignPipe);
    const mpg: ColumnInfo = new ColumnInfo('MPG');
    const ppg: ColumnInfo = new ColumnInfo('PPG');
    const apg: ColumnInfo = new ColumnInfo('APG');
    const rpg: ColumnInfo = new ColumnInfo('RPG');
    const spg: ColumnInfo = new ColumnInfo('SPG');
    const bpg: ColumnInfo = new ColumnInfo('BPG');
    const tpg: ColumnInfo = new ColumnInfo('TPG');
    const fgPct: ColumnInfo = new ColumnInfo('FG%', PercentPipe);
    const fg3Pct: ColumnInfo = new ColumnInfo('3PT%', PercentPipe);
    const headers = { firstName, lastName, jerseyNumber, mpg, ppg, apg, rpg, spg, bpg, tpg, fgPct, fg3Pct };
    const editBtn = new TableActionButton('edit', ActionType.Edit);
    const removeBtn = new TableActionButton('delete', ActionType.Remove);
    const settings = new DataTableSettings(headers, undefined, editBtn, removeBtn);

    return settings;
  }

  onRowSelected = (player: Player) => {
    this.router.navigateByUrl(`players/${player.id}`);
  }

  delete() {
    this.deleteButtonClicked.emit();
  }
}
