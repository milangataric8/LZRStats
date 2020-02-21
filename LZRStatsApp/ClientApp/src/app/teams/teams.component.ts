import { Component, OnInit, ViewChild } from '@angular/core';
import { TeamsService } from '../_services/teams.service';
import { Team } from '../_models/team';
import { AppSettings } from '../constants';
import { DataTableSettings } from '../shared/data-table/settings/data-table-settings';
import { ColumnInfo } from '../shared/data-table/column-header-models/column-info';
import { MasterDetailBaseComponent } from '../shared/master-detail-base/master-detail-base.component';
import { DataTableService } from '../_services/data-table.service';
import { TableActionButton } from '../shared/data-table/settings/table-action-button';
import { ActionType } from '../shared/enums/enums';

@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
  styleUrls: ['./teams.component.css']
})
export class TeamsComponent extends MasterDetailBaseComponent implements OnInit {
  getTableDataUrl: string = this.apiUrl;

  constructor(dataTableService: DataTableService) {
    super(`${AppSettings.API_ENDPOINT}teams`, dataTableService);
  }

  ngOnInit() {
  }

  createTableOptions(): DataTableSettings {
    const name: ColumnInfo = new ColumnInfo('Name');
    const wins: ColumnInfo = new ColumnInfo('Wins');
    const losses: ColumnInfo = new ColumnInfo('Losses');
    const headers = { name, wins, losses };
    const editBtn = new TableActionButton('edit', ActionType.Edit);
    const removeBtn = new TableActionButton('remove', ActionType.Remove);
    const settings = new DataTableSettings(headers, undefined, editBtn, removeBtn);

    return settings;
  }
}
