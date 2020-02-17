import { ColumnType } from "../../enums/enums";

export class ColumnInfo {
    value: any;
    type: ColumnType;
    isClickable: boolean;

    constructor(value: any, type: ColumnType = ColumnType.Text, isClickable: boolean = false) {
        this.value = value;
        this.type = type;
        this.isClickable = isClickable;
    }
}