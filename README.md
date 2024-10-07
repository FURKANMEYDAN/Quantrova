# Quantrova


**Quantrova** is an e-commerce application built using .NET Core with an Onion Architecture and CQRS pattern. The project aims to provide a platform for managing products, categories, and related details in a structured way.

## Technologies Used
- **Backend**: .NET Core
- **Database**: PostgreSQL
- **Frontend**(Currently working on it): React
- **ORM**: Entity Framework Core
- **Logging**: Serilog
-

## Features
- **Product Management**: CRUD operations for products.
- **Category Management**: Manage product categories and details.
- **Image Support**: Products can have associated images.
- **Admin Panel**: (Currently working on it) A simple admin panel to manage products and categories.

## Project Structure
- **Core**: Contains the domain entities and interfaces.
- **Application**: Contains the business logic, queries, and command handlers.
- **Infrastructure**: Contains the database context and repository implementations.
- **Presentation**: The API layer for handling requests and responses.

