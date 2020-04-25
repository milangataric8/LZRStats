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
import { PercentPipe, DecimalPipe } from '@angular/common';
import { TableActionButton } from '../shared/data-table/settings/table-action-button';
import { ActionType } from '../shared/enums/enums';
import { MatDialog } from '@angular/material';
import { PercentSignPipe } from '../pipes/percent-sign.pipe';

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
    const firstName: ColumnInfo = new ColumnInfo('firstName');
    const lastName: ColumnInfo = new ColumnInfo('lastName');
    const jerseyNumber: ColumnInfo = new ColumnInfo('jerseyNumber', NumberSignPipe);
    // const teamName: ColumnInfo = new ColumnInfo('Team'); // TODO add abreviation
    const gamesPlayed: ColumnInfo = new ColumnInfo('gamesPlayed'); // TODO align content right
    const mpg: ColumnInfo = new ColumnInfo('mpg');
    const ppg: ColumnInfo = new ColumnInfo('ppg');
    const apg: ColumnInfo = new ColumnInfo('apg');
    const rpg: ColumnInfo = new ColumnInfo('rpg');
    const spg: ColumnInfo = new ColumnInfo('spg');
    const bpg: ColumnInfo = new ColumnInfo('bpg');
    const tpg: ColumnInfo = new ColumnInfo('tpg');
    const fgPercentage: ColumnInfo = new ColumnInfo('fg%', PercentSignPipe); // TODO show percent pipe
    const fG2Percentage: ColumnInfo = new ColumnInfo('fg2%', PercentSignPipe);
    const fG3Percentage: ColumnInfo = new ColumnInfo('fg3%', PercentSignPipe);
    const ftPercentage: ColumnInfo = new ColumnInfo('ft%', PercentSignPipe);

    const headers = {
      firstName,
      lastName,
      jerseyNumber,
      // teamName,
      gamesPlayed,
      mpg,
      ppg,
      apg,
      rpg,
      spg,
      bpg,
      tpg,
      fgPercentage,
      fG2Percentage,
      fG3Percentage,
      ftPercentage
    };
    const editBtn = new TableActionButton('edit', ActionType.Edit);
    const removeBtn = new TableActionButton('delete', ActionType.Remove);
    const settings = new DataTableSettings(headers, undefined, editBtn, removeBtn);

    return settings;
  }

  onRowSelected = (player: Player) => {
    this.router.navigate([`playerDetails`], { queryParams: { player } });
  }

  delete() {
    this.deleteButtonClicked.emit();
  }

  addRow() {
    this.ShowAddEditModal(new Player(), 'addItem', this.add);
  }
}
