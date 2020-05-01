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
import { MatDialog } from '@angular/material';
import { SnackbarService } from '../_services/snackbar.service';

@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
  styleUrls: ['./teams.component.css']
})
export class TeamsComponent extends MasterDetailBaseComponent implements OnInit {
  getTableDataUrl: string = this.apiUrl;

  constructor(dataTableService: DataTableService, public dialog: MatDialog, snackbarService: SnackbarService) {
    super(`${AppSettings.API_ENDPOINT}teams`, dataTableService, dialog, snackbarService);
  }

  ngOnInit() {
  }

  createTableOptions(): DataTableSettings {
    const name: ColumnInfo = new ColumnInfo('teamName');
    const wins: ColumnInfo = new ColumnInfo('wins');
    const losses: ColumnInfo = new ColumnInfo('losses');
    const headers = { name, wins, losses };
    const editBtn = new TableActionButton('edit', ActionType.Edit);
    const removeBtn = new TableActionButton('delete', ActionType.Remove);
    const settings = new DataTableSettings(headers, undefined, editBtn, removeBtn);

    return settings;
  }

  addRow() {
    const team = new Team();
    this.ShowAddEditModal(team, 'Add item', this.add);
  }
}
