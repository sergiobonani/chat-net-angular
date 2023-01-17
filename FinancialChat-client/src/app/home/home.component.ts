import { Component } from '@angular/core';
import { Router, NavigationExtras } from '@angular/router';
import { ChatService } from 'src/app/services/chat.service';


@Component({
    selector: 'home-component',
    templateUrl: 'home.component.html',
    styleUrls: [ 'home.component.scss']
})
export class HomeComponent {

    private _chatService: ChatService;
    private _router: Router;
    private _hasInputError: boolean;

    constructor(router: Router, chatService: ChatService) {
        this._router = router;
        this._chatService = chatService;
        this._hasInputError = false;
    }

    public get hasInpurError(): boolean{
        return this._hasInputError;
    }

    public onEnterButtonClicked(userName: string): void {
        this._hasInputError = userName === '' || userName === undefined;

        if (this._hasInputError) {
            this._hasInputError = true;
        } else {
            this._chatService.setUserName(userName);
            const navigationExtras: NavigationExtras = {
                queryParams: {
                    userName
                }
            };
            this._router.navigate(['/chat'], navigationExtras);
        }
    }
}
