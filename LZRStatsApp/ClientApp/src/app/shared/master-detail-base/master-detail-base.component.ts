import { Component, OnInit } from '@angular/core';
import { DataTableService } from 'src/app/_services/data-table.service';

@Component({
  selector: 'app-master-detail-base',
  template: '',
  styles: ['']
})
export class MasterDetailBaseComponent implements OnInit {

  constructor(public readonly apiUrl: string, private dataTableService: DataTableService) { }

  ngOnInit() {
  }

  onCreate(event: any) {
    console.log(this.apiUrl);
    //TODO show empty modal dialog(***MUST use the same dialog for add/edit!!!)
  }

  add(payload: any) {
    this.dataTableService.add(this.apiUrl, event)
      .subscribe(x => {
        //TODO open edit dialog
      }, error => console.log(error));
  }

  onEdit(event: any) {
    console.log(this.apiUrl);
    //TODO open edit dialog
  }

  update(payload: any) {
    this.dataTableService.update(this.apiUrl, event)
      .subscribe(x => {
        //TODO after api call
      }, error => console.log(error));
  }

  onDelete(event: any) {
    console.log(event);
    //TODO show confirm dialog
  }

  delete(payload: any) {
    this.dataTableService.remove(this.apiUrl, event)
      .subscribe(x => {
        //TODO after api call
      }, error => console.log(error));
  }

  onShowDetails(event: any) {
    console.log(event);
  }

  onItemClicked(event: any) {
    console.log(event);
  }
}
