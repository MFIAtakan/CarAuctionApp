# CarAuctionApp
A car auction application implemented using .NET Microservices and NextJS.

An car auction application I implemented by following a tutorial to understand basics of microservice architecture on ASP.NET API. For client application Next.js used.Application has mainly five services, 
that each of them working independantly in a docker container. These services are : 

- **AuctionService:** Handles CRUD operations for Auctions.
- **SearchService:** Handles Search operation.
- **IdentityService:** Handles user operations like register and login.
- **BidsService:** Handles bid operations.
- **NotificationService:** Handles notifications.


 Each service has their own roles and responsibilities in the application, and communicate each other using RabbitMQ, which provide us design and develop decoupled services. By using docker, we can host
 our services into different containers under same network. For gateway implementation YARP has been used in the project since Ocelot is not yet compatible with .NET 7.

Backend Technologies
----------------------

- **ASP.NET Core API**
- **Docker**
- **Postgre for Auction Service**
- **MongoDb for Search Service**
- **Automapper**
- **Identity Server**
- **JWT Token based session management**
- **Dependency Injection**
- **RabbitMQ for communication between services (publisher/consumer)**
- **Asynchronous Programming**
- **YARP Gateway (Ocelot is not fully up-to-date with .NET 7 currently)**

Frontend Technologies
----------------------
- **Next.js**
- **React Caching**
- **SignalR**
- **HTML&CSS (tailwind.css)**
- **AuthJS**
- **Toast Notification**
- **Component-based application development**


Application Setup 
------------------
You can run this application by following the instructions below;

1) First of al create a foler in your computer and clone the project using git command below.
   ```bash
   https://github.com/MFIAtakan/CarAuctionApp.git
2) Ensure that docker is already installed in your computer.
3) Execute the commands below in order.
   
   ```bash
   cd Carties
4) Now let`s build the docker files.
   ```bash
   docker compose build
5) Time to reflect build result to our docker application by using comand below.
   ```bash
   docker compose up -d

After these steps you will see in your docker desktop applition all services up and running. However, if some of the ports are already being used in your system from other services, you may need
to change ports in docker-compose.yml file and rebuild it.

To see the interface please go directory and run the client application. After starting client, you can use application on http://localhost:3000

  ```bash
  cd src/client/web-app

  ```bash
  npm run dev

