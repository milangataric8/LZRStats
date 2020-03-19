import { ActionType } from "../../enums/enums";

export class TableActionButton {
    // tslint:disable-next-line:max-line-length
    constructor(private iconName: string, private actionType: ActionType, private title: string = actionType.toString(), private classes: string = 'material-icons clickable') {

    }
}