import { EventEmitter, Injectable } from '@angular/core';
import { Message } from '../models/message.model';
import * as signalR from '@microsoft/signalr';
import { MessageTypeEnum } from '../enums/message-type.enum';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class ChatService {

  public onConnectionSuccessfully: EventEmitter<void>;
    public newMessageReceivedEvent: EventEmitter<Message>;
    public userEnteredEvent: EventEmitter<Message>;
    public userExitEvent: EventEmitter<Message>;

    private _hubConnection!: signalR.HubConnection;
    private _currentUserName: string;

    constructor() {
        this.newMessageReceivedEvent = new EventEmitter<Message>();
        this.userEnteredEvent = new EventEmitter<Message>();
        this.userExitEvent = new EventEmitter<Message>();
        this.onConnectionSuccessfully = new EventEmitter();
        this._currentUserName = '';
    }

    public get CurrentUserName(): string {
        return this._currentUserName;
    }

    public initializeNewUserConnectionAsync(userName: string): Promise<void> {
        this._currentUserName = userName;
        this._hubConnection = new signalR.HubConnectionBuilder()
                                .withUrl('https://localhost:7192/chatHub')
                                .build();

        this.assignNewMessageReceived();
        this.assignOnUserEnterChatAsync();
        this.assignOnUserExitChatAsync();

        return this._hubConnection.start().then(() => {
            this.onConnectionSuccessfully.emit();
            this._hubConnection.send('OnEnterChatAsync', this.CurrentUserName);
        });
    }

    public leaveChatAsync(): Promise<void> {
        return this._hubConnection.send('OnExitChatAsync', this.CurrentUserName)
                .then(() => {
                    this._hubConnection.stop();
                });
    }

    public sendNewMessage(message: string): void{
        const user = new User(this.CurrentUserName, '1', '1', new Date());
        const newMessage = new Message(user, message, MessageTypeEnum.OtherUser);
        this._hubConnection.send('OnNewMessageAsync', this.CurrentUserName, message);
    }

    public setUserName(name: string): void {
        localStorage.setItem('username', name);
    }

    private assignNewMessageReceived(): void {
        this._hubConnection.on('OnNewMessageAsync', (userName: string, messageContent: string) => {
            const user = new User(userName, '1', '1', new Date());
            const newMessage = new Message(user, messageContent, MessageTypeEnum.OtherUser);
            this.newMessageReceivedEvent.emit(newMessage);
        });
    }

    private assignOnUserEnterChatAsync(): void {
        this._hubConnection.on('OnEnterChatAsync', (userName: string) => {
            const user = new User(userName, '1', '1', new Date());
            const newMessage = new Message(user, `${userName} joined chat`, MessageTypeEnum.ChatActions);
            this.newMessageReceivedEvent.emit(newMessage);
        });
    }

    private assignOnUserExitChatAsync(): void {
        this._hubConnection.on('OnExitChatAsync', (userName: string) => {
            const user = new User(userName, '1', '1', new Date());
            const newMessage = new Message(user, `${userName} left chat`, MessageTypeEnum.ChatActions);
            this.newMessageReceivedEvent.emit(newMessage);
        });
    }
}
