import { Component, OnInit, ViewChild } from '@angular/core';
import { TeamsService } from '../_services/teams.service';
import { Team } from '../_models/team';
import { MatTableDataSource, MatSort, MatPaginator } from '@angular/material';

@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
  styleUrls: ['./teams.component.css']
})
export class TeamsComponent implements OnInit {
  //TODO common datatable component?
  public displayedColumns = ['name', 'wins', 'losses'];
  public dataSource = new MatTableDataSource<Team>();
  @ViewChild(MatSort, null) sort: MatSort;
  @ViewChild(MatPaginator, null) paginator: MatPaginator;
  
  constructor(private teamsService: TeamsService) { }

  ngOnInit() {
    this.getAllTeams();
  }

  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  public doFilter = (value: string) => {
    this.dataSource.filter = value.trim().toLocaleLowerCase();
  }

  private getAllTeams() {
    this.teamsService.getAll()
      .subscribe(x => {
        this.dataSource.data = x as Team[];
      });
  }
}
