# CodeAgenda

CodeAgenda is a project designed to learn new technologies within the .NET environment. It serves as an example application for organizing programming projects.

## Key Features

- **Entity Framework Core**: CodeAgenda utilizes Entity Framework Core to handle data access.
- **Mediator**: Mediator is used to handle the communication between components in the application, promoting loose coupling and high cohesion.
- **CQRS (Command Query Responsibility Segregation)**: The application follows the CQRS pattern to separate the responsibilities of reading and writing data.

## Project Structure

The project is structured following the principles of CQRS and DDD (Domain-Driven Design):

- **Domain**: Contains the entities and business logic.
- **Application**: Contains the commands and queries, as well as their corresponding handlers.
- **Data Access**: Contains the database implementation using Entity Framework Core.
- **Tests**: Contains unit tests using xUnit to verify the functionality of 
