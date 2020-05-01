import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material';

@Injectable({
  providedIn: 'root'
})
export class SnackbarService {

  constructor(private _snackBar: MatSnackBar) { }

  showInfo(message: string, action: string = 'Close'): void {
    this.open(message, action, 'snackbar-info');
  }

  showWarning(message: string, action: string = 'Close'): void {
    this.open(message, action, 'snackbar-warning');
  }

  showError(message: string, action: string = 'Close'): void {
    this.open(message, action, 'snackbar-error');
  }

  private open(message: string, action: string, panelClass: string) {
    this._snackBar.open(message, action, {
      duration: 4500,
      horizontalPosition: 'right',
      verticalPosition: 'bottom',
      panelClass: [panelClass]
    });
  }
}
