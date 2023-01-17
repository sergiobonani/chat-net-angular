import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MessageTypeEnum } from 'src/app/enums/message-type.enum';
import { Message } from 'src/app/models/message.model';
import { IconDefinition } from '@fortawesome/fontawesome-svg-core';
import { faArrowAltCircleRight, faSignOutAlt } from '@fortawesome/free-solid-svg-icons';
import { ChatService } from 'src/app/services/chat.service';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { User } from '../models/user.model';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss']
})
export class ChatComponent implements OnInit {

  public messageTypeEnumRef: typeof MessageTypeEnum;
    public chatMessages: Message[];
    public sendMessageIcon: IconDefinition;
    public leaveChatIcon: IconDefinition;
    public liveChatOn: boolean;

    @ViewChild('messagesContainer')
    private _messagesContainer!: ElementRef;
    private _chatService: ChatService;
    private _router: Router;
    private _activatedRoute: ActivatedRoute;

    constructor(chatService: ChatService, router: Router, route: ActivatedRoute){
        this.chatMessages = [];
        this.messageTypeEnumRef = MessageTypeEnum;
        this._activatedRoute = route;
        this._chatService = chatService;
        this._router = router;
        this.liveChatOn = false;
        this.sendMessageIcon = faArrowAltCircleRight;
        this.leaveChatIcon = faSignOutAlt;
    }

    public ngAfterViewChecked(): void {
        if (this._messagesContainer && this.chatMessages.length > 0){
            this.scrollPageToBottom()
        }
    }

    public ngOnInit(): void {
        this._activatedRoute.queryParams.subscribe((params: Params) => {
            const userName = params['userName'];
            this._chatService.initializeNewUserConnectionAsync(userName)
                .then(() => {
                    this.liveChatOn = true;
                });
        });

        this._chatService.newMessageReceivedEvent.subscribe((newMessage: Message) => {
            this.chatMessages.push(newMessage);
        });
    }

    public sendNewMessage(messageInput: HTMLInputElement | HTMLTextAreaElement): void {
        const messageContent = messageInput.value;
        const currentUserName = this._chatService.CurrentUserName;
        const user = new User(currentUserName, '1', '1', new Date());
        const newMessage = new Message(user, messageContent, MessageTypeEnum.CurrentUserMessage);
        this.chatMessages.push(newMessage);
        this._chatService.sendNewMessage(messageContent);
        messageInput.value = '';
    }

    public leaveChatAsync(): void {
        this._chatService.leaveChatAsync()
        .then(() => {
            this.liveChatOn = false;
            this._router.navigate(['']);
        });
    }

    private scrollPageToBottom(): void {
        this._messagesContainer.nativeElement.scrollTop =
        this._messagesContainer.nativeElement.scrollHeight;
    }

}
