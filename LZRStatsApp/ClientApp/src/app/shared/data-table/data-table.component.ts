import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { MatSort, MatTableDataSource, MatTable, MatPaginator } from '@angular/material';
import { DataTableService } from 'src/app/_services/data-table.service';
import { Observable } from 'rxjs';
import { DataTableSettings } from './settings/data-table-settings';

@Component({
  selector: 'data-table',
  templateUrl: './data-table.component.html',
  styleUrls: ['./data-table.component.css']
})
export class DataTableComponent implements OnInit {
  @Input() tableDataUrl: string;
  @Input() tableSettings: DataTableSettings;

  objectKeys = Object.keys;
  dataSource: MatTableDataSource<any>;

  @ViewChild(MatSort, { static: false }) sort: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;

  constructor(private dataTableService: DataTableService) { }

  ngOnInit() {
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
    console.log('showDetails clicked');
    console.log(element);
  }

  edit(element: any) {
    console.log('edit clicked'); //TODO event emitter
    console.log(element);
  }

  remove(element: any) {
    console.log('remove clicked');
    console.log(element);
  }

  private isActionColumn(dataSubject: string): string {
    return dataSubject !== 'action' ? dataSubject : null;
  }
}