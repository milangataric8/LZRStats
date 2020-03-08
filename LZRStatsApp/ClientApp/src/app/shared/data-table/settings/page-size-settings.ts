export class PageSizeSettings {
    pageSizeOptions: number[] = [10, 25, 50];
    currentPageSize: number = this.pageSizeOptions[0]; // take the first option as default
}