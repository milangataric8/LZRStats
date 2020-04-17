import { Component, OnInit, ViewChild } from '@angular/core';
import { DataTableService } from 'src/app/_services/data-table.service';
import { ButtonClickedItem } from '../data-table/event-models/button-clicked-item';
import { MatDialog, MatTable } from '@angular/material';
import { ConfirmModalComponent } from '../delete-modal/confirm-modal.component';
import { DataTableComponent } from '../data-table/data-table.component';

@Component({
  selector: 'app-master-detail-base',
  template: '',
  styles: ['']
})
export class MasterDetailBaseComponent implements OnInit {
  @ViewChild(DataTableComponent, {static: true}) table: DataTableComponent;
  constructor(public readonly apiUrl: string, private dataTableService: DataTableService, public dialog: MatDialog) { }

  ngOnInit() {
  }

  onCreate(event: any) {
    console.log(this.apiUrl);
    // TODO show empty modal dialog(***MUST use the same dialog for add/edit!!!)
  }

  add(payload: any) {
    this.dataTableService.add(this.apiUrl, payload)
      .subscribe(x => {
        // TODO open edit dialog
      }, error => console.log(error));
  }

  onTableButtonClicked(event: any) {
    console.log(event);
    // TODO open edit dialog
    this.invokeButtonAction(event);
  }

  // TODO handle waaay differently!!
  // switch alternative https://ultimatecourses.com/blog/deprecating-the-switch-statement-for-object-literals
  invokeButtonAction(item: ButtonClickedItem) {
    const btnTypes = {
      'Add': () => {
        // TODO show add modal
        console.log('add');
      },
      'Edit': () => {
        // TODO show edit modal
        console.log('edit');
      },
      'Remove': () => {
        this.openDialog(item.element, 'Confirm delete', `Are you sure you want to delete this item?`, this.delete);
      }
    };
    btnTypes[item.getActionType()]();
  }

  update(payload: any) {
    this.dataTableService.update(this.apiUrl, payload)
      .subscribe(x => {
        // TODO after api call
      }, error => console.log(error));
  }

  delete(self: any) {
    self.dataTableService.remove(self.apiUrl, this)
      .subscribe((x: any) => {
        // TODO after api call refresh table
        //self.table.renderRows();
        //self.table.dataSource.data.pop(this)
      }, (error: any) => console.log(error));
  }

  onItemClicked(event: any) {
    console.log(event);
  }


  openDialog(item: any, title: string, text: string, func: (payload: any) => void) {
    this.dialog.open(ConfirmModalComponent, {
      width: '350px',
      data: { dialogTitle: title, dialogText: text, item: item }
    })
      .afterClosed().subscribe(result => {
        if (result) {
          func.call(item, this);
        }
      });
  }
}
