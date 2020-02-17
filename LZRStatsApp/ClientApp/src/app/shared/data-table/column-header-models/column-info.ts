import { ColumnType } from "../../enums/enums";

export class ColumnInfo {
    constructor(private value: any, private type: ColumnType = ColumnType.Text) { }
}