import { PageSizeSettings } from "./page-size-settings";
import { ButtonType } from "../../enums/enums";

export class DataTableSettings {
    columnHeaders: any = {}; //TODO handle this better https://stackoverflow.com/a/44441178
    pageSizeSettings: PageSizeSettings = new PageSizeSettings();
    protected showDetailsButton: boolean;
    protected showEditButton: boolean;
    protected showRemoveButton: boolean;

    showButtons(...buttonTypes: ButtonType[]) {
        buttonTypes.forEach(btn => {
            switch (btn) {
                case ButtonType.Edit:
                    this.showEditButton = true;
                    break;
                case ButtonType.Remove:
                    this.showRemoveButton = true;
                    break;
                case ButtonType.Details:
                    this.showDetailsButton = true;
                    break;
            }
        });
        this.columnHeaders.action = 'Action';
    }
}