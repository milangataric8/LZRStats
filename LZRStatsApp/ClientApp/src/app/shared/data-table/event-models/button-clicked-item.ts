import { ActionType } from "../../enums/enums";

export class ButtonClickedItem{
    constructor(private actionType:ActionType, private element:any){}

    getActionType(){
        return this.actionType;
    }
}