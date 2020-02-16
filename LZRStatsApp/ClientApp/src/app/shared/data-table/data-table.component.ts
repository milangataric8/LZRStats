import { Component, OnInit, ViewChild, Input, Output, EventEmitter } from '@angular/core';
import { MatSort, MatTableDataSource, MatTable, MatPaginator } from '@angular/material';
import { DataTableService } from 'src/app/_services/data-table.service';
import { Observable } from 'rxjs';
import { DataTableSettings } from './settings/data-table-settings';
import { AuthenticationService } from 'src/app/_services/authentication.service';

@Component({
  selector: 'data-table',
  templateUrl: './data-table.component.html',
  styleUrls: ['./data-table.component.css']
})
export class DataTableComponent implements OnInit {
  @Input() tableDataUrl: string;
  @Input() tableSettings: DataTableSettings;
  @Output() editItem: EventEmitter<any> = new EventEmitter();
  @Output() removeItem: EventEmitter<any> = new EventEmitter();
  @Output() details: EventEmitter<any> = new EventEmitter();

  objectKeys = Object.keys;
  dataSource: MatTableDataSource<any>;
  isUserLoggedIn:boolean;

  @ViewChild(MatSort, { static: false }) sort: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;

  constructor(private dataTableService: DataTableService, private authService: AuthenticationService) { }

  ngOnInit() {
    this.isUserLoggedIn = this.authService.isAuthenticated();
    console.log(this.isUserLoggedIn);
    this.initData();
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  initData() {
    this.dataTableService.getData(this.tableDataUrl).subscribe(x => {
      this.dataSource = new MatTableDataSource(x as any[]);
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
    });
  }

  showDetails(element: any) {
    this.details.emit(element);
  }

  edit(element: any) {
    this.editItem.emit(element);
  }

  remove(element: any) {
    this.removeItem.emit(element);
  }

  private isActionColumn(dataSubject: string): string {
    return dataSubject !== 'action' ? dataSubject : null;
  }
}