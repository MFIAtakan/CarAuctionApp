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



