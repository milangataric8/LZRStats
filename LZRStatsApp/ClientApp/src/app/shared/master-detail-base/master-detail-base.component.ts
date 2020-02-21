import { Component, OnInit } from '@angular/core';
import { DataTableService } from 'src/app/_services/data-table.service';
import { ButtonClickedItem } from '../data-table/event-models/button-clicked-item';
import { ActionType } from '../enums/enums';

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

  onTableButtonClicked(event: any) {
    console.log(event);
    //TODO open edit dialog
    this.invokeButtonAction(event);
  }

  //TODO handle waaay diferently!!
  //switch alternative https://ultimatecourses.com/blog/deprecating-the-switch-statement-for-object-literals
  invokeButtonAction(item: ButtonClickedItem) {
    const btnTypes = {
      0: () => {
        //TODO show edit modal
      },
      1: () => {
        //TODO show confirm remove modal
      }
    };
    btnTypes[item.getActionType()]();
  }

  update(payload: any) {
    this.dataTableService.update(this.apiUrl, event)
      .subscribe(x => {
        //TODO after api call
      }, error => console.log(error));
  }

  delete(payload: any) {
    this.dataTableService.remove(this.apiUrl, event)
      .subscribe(x => {
        //TODO after api call
      }, error => console.log(error));
  }

  onItemClicked(event: any) {
    console.log(event);
  }
}
