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
    const teamName: ColumnInfo = new ColumnInfo('Team');
    const jerseyNumber: ColumnInfo = new ColumnInfo('Jersey number', NumberSignPipe);
    const gamesPlayed: ColumnInfo = new ColumnInfo('Games played'); // TODO align content right
    const mpg: ColumnInfo = new ColumnInfo('MPG');
    const ppg: ColumnInfo = new ColumnInfo('PPG');
    const apg: ColumnInfo = new ColumnInfo('APG');
    const rpg: ColumnInfo = new ColumnInfo('RPG');
    const spg: ColumnInfo = new ColumnInfo('SPG');
    const bpg: ColumnInfo = new ColumnInfo('BPG');
    const tpg: ColumnInfo = new ColumnInfo('TPG');
    const fgPercentage: ColumnInfo = new ColumnInfo('FG%'); // TODO show percent pipe
    const fG2Percentage: ColumnInfo = new ColumnInfo('2PT%');
    const fG3Percentage: ColumnInfo = new ColumnInfo('3PT%');
    const ftPercentage: ColumnInfo = new ColumnInfo('FT%');
    const fgm: ColumnInfo = new ColumnInfo('FGM');
    const fga: ColumnInfo = new ColumnInfo('FGA');
    const fG2M: ColumnInfo = new ColumnInfo('FG2M');
    const fG2A: ColumnInfo = new ColumnInfo('FG2A');
    const fG3M: ColumnInfo = new ColumnInfo('FG3M');
    const fG3A: ColumnInfo = new ColumnInfo('FG3A');
    const ftm: ColumnInfo = new ColumnInfo('FTM');
    const fta: ColumnInfo = new ColumnInfo('FTA');
    const headers = {
      firstName,
      lastName,
      jerseyNumber,
      teamName,
      gamesPlayed,
      mpg,
      ppg,
      apg,
      rpg,
      spg,
      bpg,
      tpg,
      fgm,
      fga,
      fgPercentage,
      fG2M,
      fG2A,
      fG2Percentage,
      fG3M,
      fG3A,
      fG3Percentage,
      ftm,
      fta,
      ftPercentage
    };
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
