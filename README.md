# Study Room Reservation System Web Services

This solution is developed for final year module called Distributed Systems. This poroject developed based on Service Oriented Architecture. This solution is consist with four web services with one API gateway. Each service is a restfull web service.

> Technologies Used

- .Net core 3.1
- Ocelot( As the API gateway)
- Docker
- SQL Server 2012
- Entity framework
- Swagger for API documentation

> Docker hub Repository Links

- Normal User Web Service - [Nuser API Docker image](https://hub.docker.com/r/hivi99/nusersapi)
- Admin User Web Service - [Admin user API Docker image](https://hub.docker.com/r/hivi99/adminuserapi)
- Reservation Web service - [Reservation API Docker image](https://hub.docker.com/r/hivi99/bookingapi)
- Study Room Web service - [Study room API Docker image](https://hub.docker.com/r/hivi99/studyroomapi)
- API Gateway - [Ocelot API Gateway Docker image](https://hub.docker.com/r/hivi99/ocelotapigateway)

> Required applications to run this application successfully

- Visual Studio 2019
- Docker Desktop

> Steps to run application successfully

  - Open visual studio 2019 and clone this repository
  - Build the application
  - Right click on Docker compose file -> Open file in file explorer
  - Type ```cmd ``` on the top url bar
  - Type following line of code to build Docker containers
  ``` docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d ```
  - Then test each service using Postman


> Developers Engaged

- @Hivindu Amaradeva
- @Dasuni Rupesinghe
- @Nitharshan Jayasooriya
- @Uthpala Denipitiya
- @Nidula Chithwara
- @Sandani Chamika
