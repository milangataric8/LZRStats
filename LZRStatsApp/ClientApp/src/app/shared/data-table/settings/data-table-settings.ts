import { PageSizeSettings } from "./page-size-settings";

export class DataTableSettings {
    columnHeaders: object;
    pageSizeSettings: PageSizeSettings = new PageSizeSettings();
    showDetailsButton: boolean;
    showEditButton: boolean;
    showRemoveButton: boolean;
}