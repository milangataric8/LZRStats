import { Component, OnInit, ViewChild } from '@angular/core';
import { DataTableService } from 'src/app/_services/data-table.service';
import { ButtonClickedItem } from '../data-table/event-models/button-clicked-item';
import { MatDialog, MatTable } from '@angular/material';
import { ConfirmModalComponent } from '../delete-modal/confirm-modal.component';
import { DataTableComponent } from '../data-table/data-table.component';
import { AddEditModalComponent } from '../add-edit-modal/add-edit-modal/add-edit-modal.component';

@Component({
  selector: 'app-master-detail-base',
  template: '',
  styles: ['']
})
export class MasterDetailBaseComponent implements OnInit {
  @ViewChild(DataTableComponent, { static: true }) table: DataTableComponent;
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
        this.ShowAddEditModal(item, 'Add item');
      },
      'Edit': () => {
        this.ShowAddEditModal(item, 'Edit item');
      },
      'Remove': () => {
        this.ShowDeleteModal(item);
      }
    };
    btnTypes[item.getActionType()]();
  }

  update(self: any) {
    self.dataTableService.update(self.apiUrl, this)
      .subscribe((x: any) => {
        // TODO show toast notification
        self.table.initData();
      }, (error: any) => console.log(error));
  }

  delete(self: any) {
    self.dataTableService.remove(self.apiUrl, this)
      .subscribe((x: any) => {
        // TODO show toast notification
        self.table.initData();
      }, (error: any) => console.log(error));
  }

  onItemClicked(event: any) {
    console.log(event);
  }

  openDialog(modalType: any, item: any, config: any, callback: (payload: any) => void) {
    this.dialog.open(modalType, config)
      .afterClosed().subscribe(result => {
        if (result) {
          callback.call(item, this);
        }
      });
  }

  private ShowAddEditModal(item: ButtonClickedItem, title: string) {
    const data = { dialogTitle: title, item: item.element };
    const config = {
      width: '350px',
      data: data
    };
    this.openDialog(AddEditModalComponent, item.element, config, this.update);
  }

  private ShowDeleteModal(item: ButtonClickedItem) {
    const data = { dialogTitle: 'Confirm delete', dialogText: `Are you sure you want to delete this item?`, item: item.element };
    const config = {
      width: '350px',
      data: data
    };
    this.openDialog(ConfirmModalComponent, item.element, config, this.delete);
  }
}
