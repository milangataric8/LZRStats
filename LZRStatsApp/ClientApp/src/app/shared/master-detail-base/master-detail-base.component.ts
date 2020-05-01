import { Component, OnInit, ViewChild } from '@angular/core';
import { DataTableService } from 'src/app/_services/data-table.service';
import { ButtonClickedItem } from '../data-table/event-models/button-clicked-item';
import { MatDialog, MatTable } from '@angular/material';
import { ConfirmModalComponent } from '../confirm-modal/confirm-modal.component';
import { DataTableComponent } from '../data-table/data-table.component';
import { AddEditModalComponent } from '../add-edit-modal/add-edit-modal/add-edit-modal.component';
import { SnackbarService } from 'src/app/_services/snackbar.service';

@Component({
  selector: 'app-master-detail-base',
  template: '',
  styles: ['']
})
export class MasterDetailBaseComponent implements OnInit {
  @ViewChild(DataTableComponent, { static: true }) table: DataTableComponent;
  constructor(public readonly apiUrl: string, private dataTableService: DataTableService, public dialog: MatDialog,
    private snackbarService: SnackbarService) { }

  ngOnInit() {
  }

  onTableButtonClicked(event: any) {
    console.log(event);
    this.invokeButtonAction(event);
  }

  // TODO handle waaay differently!!
  // switch alternative https://ultimatecourses.com/blog/deprecating-the-switch-statement-for-object-literals
  invokeButtonAction(item: ButtonClickedItem) {
    const btnTypes = {
      'Edit': () => {
        this.ShowAddEditModal(item.element, 'Edit item', this.update);
      },
      'Remove': () => {
        this.ShowDeleteModal(item.element);
      }
    };
    btnTypes[item.getActionType()]();
  }

  add(self: any) {
    self.dataTableService.add(self.apiUrl, this)
      .subscribe((x: any) => {
        self.snackbarService.showInfo('Successfully added item!');
        self.table.initData();
      }, (error: any) => self.snackbarService.showError('Error occured!'));
  }

  update(self: any) {
    self.dataTableService.update(self.apiUrl, this)
      .subscribe((x: any) => {
        self.snackbarService.showInfo('Successfully updated item!');
        self.table.initData();
      }, (error: any) => self.snackbarService.showError('Error occured!'));
  }

  delete(self: any) {
    self.dataTableService.remove(self.apiUrl, this)
      .subscribe((x: any) => {
        self.snackbarService.showInfo('Successfully deleted item!');
        self.table.initData();
      }, (error: any) => self.snackbarService.showError('Error occured!')
      );
  }

  openDialog(modalType: any, item: any, config: any, callback: (payload: any) => void) {
    this.dialog.open(modalType, config)
      .afterClosed().subscribe(result => {
        if (result) {
          callback.call(item, this);
        }
      });
  }

  ShowAddEditModal(item: any, title: string, callback: (payload: any) => void) {
    const data = { dialogTitle: title, item: item };
    const config = {
      width: '350px',
      data: data
    };
    this.openDialog(AddEditModalComponent, item, config, callback);
  }

  ShowDeleteModal(item: any) {
    const data = { dialogTitle: 'Confirm delete', dialogText: `Are you sure you want to delete this item?`, item: item };
    const config = {
      width: '350px',
      data: data
    };
    this.openDialog(ConfirmModalComponent, item, config, this.delete);
  }
}
