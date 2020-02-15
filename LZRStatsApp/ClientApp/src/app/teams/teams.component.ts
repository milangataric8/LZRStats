import { Component, OnInit, ViewChild } from '@angular/core';
import { TeamsService } from '../_services/teams.service';
import { Team } from '../_models/team';
import { AppSettings } from '../constants';
import { DataTableSettings } from '../shared/data-table/settings/data-table-settings';

@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
  styleUrls: ['./teams.component.css']
})
export class TeamsComponent implements OnInit {
  getDataUrl: string = `${AppSettings.API_ENDPOINT}teams`;
  tableSettings: DataTableSettings = new DataTableSettings();
  
  constructor(private teamsService: TeamsService) { }

  ngOnInit() {
    this.createTableOptions();
  }

  createTableOptions() {
    this.tableSettings.columnHeaders = { name: 'Name', wins: 'Wins', losses: 'Losses' };
  }
}
