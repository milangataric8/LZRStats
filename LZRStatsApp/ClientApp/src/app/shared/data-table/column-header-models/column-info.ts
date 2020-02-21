import { Pipe } from "@angular/core";

export class ColumnInfo {
    constructor(private value: any, private pipe: Pipe = undefined, private pipeArgs: string[] = []) { }
}