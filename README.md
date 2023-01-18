# Financial Chat 

## Solution

### Backend: .Net 6

* It was created 3 backend applications with the following roles:
    - `ChatApi:` a real-time chat functionality and API to be consumed by Consumer.
    - `BotApi:` can be invoke for the commands will be executed and added into a queue
    - `Consumer:` listener/consumer that takes the commands that were queued and calls a Chat API with the response.

##### Progress
- One room
- Command to get stocks prices via `/stock=stock_code`
- Swagger for APIs

##### What do need to finish?
- To do multiple rooms
- To save messages into Database so a new user could read previous messages
- Authentication of users with .NET identity
- Unit Tests
- To improve the tiers, exception helpers, logs,  and to apply better SOLID concepts

### FrontEnd: Angular 14
* It was created a simple UI, just to test the send and receive messages

##### Progress
- One room
- Command to get stocks prices via `/stock=stock_code`
- Multiples users

##### What do need to finish?
- To do multiple rooms
- Authentication of users

## Requirements
You must have *docker* installed on your operating system (Linux, Windows or Mac).  

# Steps to run the application (To be finish)

*Obs.: Go to root folder, where you'll see the docker-compose file

Run the command:
- ` docker-compose up --build` 

 After that , access http://localhost:9000 into a web-browser and start to using the Financial Chat.

 To stop the execution inside console ('detached' mode):
- ` docker-compose down` 

 
# Steps to debug the application

1. Run the following commands to start RabbitMQ and MySQL:  
    - `docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3.11-management`  
1. Open the solution with Visual Studio  
2. Right-click into the Solution -> `Properties`  
3. Check `Multiple startup projects` and set Action as *Start* the projects bellow:  
    - Financial.Bot.Api
    - Financial.Chat.Api
    - FinancialChat.Consumer
4. Click on `► Start`  
