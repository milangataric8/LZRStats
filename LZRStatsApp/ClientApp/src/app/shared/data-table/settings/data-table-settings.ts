import { PageSizeSettings } from "./page-size-settings";
import { TableActionButton } from "./table-action-button";

export class DataTableSettings {
    pageSizeSettings: PageSizeSettings = new PageSizeSettings();
    actionButtons: TableActionButton[] = [];
    protected showDetailsButton: boolean;
    protected showEditButton: boolean;
    protected showRemoveButton: boolean;

    constructor(private columnHeaders: any, pageSizeSettings?:PageSizeSettings, ...actionButtons:TableActionButton[]){
        this.pageSizeSettings = pageSizeSettings || this.pageSizeSettings; //if empty use default
        this.showButtons(...actionButtons);
    }

    showButtons(...buttons: TableActionButton[]) {
        this.actionButtons = buttons;
        this.columnHeaders.action = 'Action'; 
        //TODO handle this better https://stackoverflow.com/a/44441178
    }
}

