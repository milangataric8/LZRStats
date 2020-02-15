import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { MatSort, MatTableDataSource, MatTable } from '@angular/material';
import { DataTableService } from 'src/app/_services/data-table.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'data-table',
  templateUrl: './data-table.component.html',
  styleUrls: ['./data-table.component.css']
})
export class DataTableComponent implements OnInit {
  @Input() tableDataUrl: string;
  @Input() columnHeader: any;

  objectKeys = Object.keys;
  dataSource: MatTableDataSource<any>;

  @ViewChild(MatSort, { static: false }) sort: MatSort;

  constructor(private dataTableService: DataTableService) { }

  ngOnInit() {
    const data = this.getData();
    this.setData(data);
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  setData(data: Observable<object>) {
    data.subscribe(x => {
      this.dataSource = new MatTableDataSource(x as any[]);
      this.dataSource.sort = this.sort;
    });
  }

  getData(): Observable<object> {
    return this.dataTableService.getData(this.tableDataUrl);
  }
}