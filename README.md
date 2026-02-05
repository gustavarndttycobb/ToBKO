# Facility Management API

A .NET 9 Web API for managing users, facilities, equipments and with a hierarchical structure.

## Overview

This project implements a Clean Architecture API for managing industrial facilities. It supports:
- **Facilities**: Hierarchical structure (Parent/Children) and tracking of operational status.
- **Equipments**: 1:N relationship with facilities.
- **Users**: Authentication.
- **Security**: JWT Authentication.

## Dependencies

- **Framework**: .NET 9
- **Database**: MySQL 8.0
- **ORM**: Entity Framework Core 8.0 (Pomelo.EntityFrameworkCore.MySql)
- **Auth**: JWT Bearer
- **Hashing**: BCrypt.Net-Next
- **Documentation**: Swagger/OpenAPI

## Getting Started

### Prerequisites
- .NET 9 SDK
- MySQL Server (if running locally without Docker)
- Docker Desktop (optional, for containerized run)

### Running Locally

1.  **Configure Database**:
    Ensure your `appsettings.json` points to a valid MySQL instance.
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;Database=bkodb;User=YOUR_USER;Password=YOUR_PASSWORD;"
    }
    ```

2.  **Apply Migrations**:
    ```bash
    dotnet ef database update
    ```

3.  **Run the API**:
    ```bash
    dotnet run
    ```
    The API will be available at `http://localhost:5248` (or the port configured in launchSettings).
    Swagger UI: `http://localhost:5248/swagger`

4.  **Database Population (Optional)**:
    You can use the scripts in the `scripts/` folder to populate sample data:
    - `scripts/populate_users.sql`
    - `scripts/populate_facilities_equipments.sql`

### Running with Docker

1.  **Build and Run**:
    ```bash
    docker-compose up --build
    ```

2.  **Access**:
    The API will be available at `http://localhost:5000`.
    Swagger UI: `http://localhost:5000/swagger`

    *Note: The database container (`bko-mysql`) is configured to listen on port 3306.*

## Database Scripts

Located in `scripts/`:
- `clean_database.sql`: Truncates all tables.
- `populate_users.sql`: Adds sample users.
- `populate_facilities_equipments.sql`: Adds a sample facility hierarchy with equipments.