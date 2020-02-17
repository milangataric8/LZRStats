import { Component, OnInit, ViewChild } from '@angular/core';
import { TeamsService } from '../_services/teams.service';
import { Team } from '../_models/team';
import { AppSettings } from '../constants';
import { DataTableSettings } from '../shared/data-table/settings/data-table-settings';
import { ColumnInfo } from '../shared/data-table/column-header-models/column-info';
import { ButtonType, ColumnType } from '../shared/enums/enums';

@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
  styleUrls: ['./teams.component.css']
})
export class TeamsComponent implements OnInit {
  getTableDataUrl: string = `${AppSettings.API_ENDPOINT}teams`;
  
  constructor(private teamsService: TeamsService) { }

  ngOnInit() {
    this.createTableOptions();
  }

  createTableOptions() : DataTableSettings {
    const name: ColumnInfo = new ColumnInfo('Name');
    const wins: ColumnInfo = new ColumnInfo('Wins');
    const losses: ColumnInfo = new ColumnInfo('Losses');
    const headers = { name, wins, losses };

    const settings = new DataTableSettings(headers, undefined, ButtonType.Edit, ButtonType.Remove);

    return settings;
  }
}
