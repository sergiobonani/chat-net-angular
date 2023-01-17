import { MessageTypeEnum } from "../enums/message-type.enum";
import { User } from "./user.model";
import { UUID } from 'angular2-uuid';

export class Message{
    public user: User;
    public content: string;
    public Destination: string;
    public timestamp: Date;
    public type: MessageTypeEnum;

    constructor(user: User, content: string, type: MessageTypeEnum) {
        this.user = user;
        this.content = content;
        this.type = type;
        this.Destination = UUID.UUID();
        this.timestamp = new Date();
    }
}