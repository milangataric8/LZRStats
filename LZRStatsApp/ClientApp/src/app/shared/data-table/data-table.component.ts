import { Component, OnInit, ViewChild, Input, Output, EventEmitter } from '@angular/core';
import { MatSort, MatTableDataSource, MatTable, MatPaginator } from '@angular/material';
import { DataTableService } from 'src/app/_services/data-table.service';
import { DataTableSettings } from './settings/data-table-settings';
import { AuthenticationService } from 'src/app/_services/authentication.service';
import { ButtonClickedItem } from './event-models/button-clicked-item';
import { ActionType } from '../enums/enums';

@Component({
  selector: 'data-table',
  templateUrl: './data-table.component.html',
  styleUrls: ['./data-table.component.css']
})
export class DataTableComponent implements OnInit {
  @Input() tableDataUrl: string;
  @Input() tableSettings: DataTableSettings;
  @Output() itemClicked: EventEmitter<any> = new EventEmitter();
  @Output() tableButtonClicked: EventEmitter<any> = new EventEmitter();

  objectKeys = Object.keys;
  dataSource: MatTableDataSource<any>;
  isUserLoggedIn: boolean;
  isLoading: boolean;

  @ViewChild(MatSort, { static: false }) sort: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;

  constructor(private dataTableService: DataTableService, private authService: AuthenticationService) { }

  ngOnInit() {
    this.isLoading = true;
    this.isUserLoggedIn = this.authService.isAuthenticated();
    this.initData();
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  initData() {
    this.dataTableService.getData(this.tableDataUrl).subscribe(x => {
      this.dataSource = new MatTableDataSource(x as object[]);
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
      this.isLoading = false;
    },
      error => this.isLoading = false);
  }

  onActionButtonClicked(element: any, actionType: ActionType) {
    this.tableButtonClicked.emit(new ButtonClickedItem(actionType, element));
  }

  cellClicked(element: any) {
    this.itemClicked.emit(element);
  }

  private isActionColumn(dataSubject: string): string {
    return dataSubject !== 'action' ? dataSubject : null;
  }

  refresh() {
    this.initData();
  }
}
