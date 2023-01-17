export class User{
    public name: string;
    public id: string;
    public connectionId: string;
    public connectionDate: Date;

    constructor(userName: string, id: string, connectionId: string, date : Date) {
        this.name = userName;
        this.id = id;
        this.connectionId = connectionId;
        this.connectionDate = date;
    }
}