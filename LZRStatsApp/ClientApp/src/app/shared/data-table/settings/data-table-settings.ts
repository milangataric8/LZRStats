import { PageSizeSettings } from "./page-size-settings";
import { ButtonType } from "../../enums/enums";

export class DataTableSettings {
    columnHeaders: any = {};
    pageSizeSettings: PageSizeSettings = new PageSizeSettings();
    protected showDetailsButton: boolean;
    protected showEditButton: boolean;
    protected showRemoveButton: boolean;

    constructor(headers: any, pageSizeSettings?:PageSizeSettings, ...buttonTypes:ButtonType[]){
        this.columnHeaders = headers;
        this.pageSizeSettings = pageSizeSettings || this.pageSizeSettings; //if empty use default
        this.showButtons(...buttonTypes);
    }

    showButtons(...buttonTypes: ButtonType[]) {
        buttonTypes.forEach(btn => {
            this.setButtonVisibility(btn);
        });
        this.columnHeaders.action = 'Action'; //TODO handle this better https://stackoverflow.com/a/44441178
    }

    //switch alternative https://ultimatecourses.com/blog/deprecating-the-switch-statement-for-object-literals
    setButtonVisibility(buttonType: ButtonType) {
        const self = this;
        const btnTypes = {
            'Edit': function () {
                self.showEditButton = true;
            },
            'Remove': function () {
                self.showRemoveButton = true;
            },
            'Details': function () {
                self.showDetailsButton = true;
            },
        };
        btnTypes[buttonType]();
    }
}

