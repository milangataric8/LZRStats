import { ActionType } from '../../enums/enums';

export class ButtonClickedItem {
    constructor(private actionType: ActionType, public element: any) { }

    getActionType() {
        return this.actionType || ActionType.Add;
    }
}
