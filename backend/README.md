# Tic Tac Toe Backend

.NET 8 Web API backend for the Tic Tac Toe game.

## Technology Stack

- **.NET 8** - Web API
- **Entity Framework Core 8.0.17** - ORM
- **PostgreSQL** - Database (via Npgsql.EntityFrameworkCore.PostgreSQL 8.0.11)
- **Swagger** - API Documentation

## Prerequisites

- **.NET 8 SDK** - [Download here](https://dotnet.microsoft.com/download/dotnet/8.0)
- **PostgreSQL** - [Download here](https://www.postgresql.org/download/) OR **Docker** - [Download here](https://www.docker.com/get-started)

## Database Setup

### Option 1: Using Docker Compose (Recommended)

If you have Docker installed, you can use the provided `docker-compose.yml` file from the root directory:

1. **Start the PostgreSQL container (from project root):**

   ```bash
   docker-compose up -d
   ```

2. **Initialize the database tables:**

   ```bash
   docker exec -i postgres-db psql -U root -d tic_tac_toe < TicTacToe.Backend/Data/Init.sql
   ```

### Option 2: Manual PostgreSQL Setup

1. **Install and start PostgreSQL**

2. **Create the database:**

   ```sql
   CREATE DATABASE tic_tac_toe;
   ```

3. **Create a user (optional, or use existing user):**

   ```sql
   CREATE USER root WITH PASSWORD 'root';
   GRANT ALL PRIVILEGES ON DATABASE tic_tac_toe TO root;
   ```

4. **Initialize the database tables:**

   ```bash
   psql -h localhost -p 5432 -U root -d tic_tac_toe -f TicTacToe.Backend/Data/Init.sql
   ```

## Backend Setup and Installation

1. **Navigate to the backend directory:**

   ```bash
   cd TicTacToe.Backend
   ```

2. **Restore NuGet packages:**

   ```bash
   dotnet restore
   ```

3. **Configure the database connection:**
   - The connection string is configured in `Properties/launchSettings.json`
   - Default connection: `Host=localhost;Port=5432;Database=tic_tac_toe;Username=root;Password=root`
   - Update the `POSTGRES_CONNECTION_STRING` environment variable if needed

## Running the Backend

To start the development server, run:

```bash
dotnet run
```

The API will be available at:

- HTTP: `http://localhost:5202`
- HTTPS: `https://localhost:7110`
- Swagger UI: `http://localhost:5202/swagger`

## Available Scripts

- `dotnet run` - Start the development server
- `dotnet build` - Build the project
- `dotnet test` - Run tests
- `dotnet watch` - Start development server with hot reload

## Project Structure

```text
TicTacToe.Backend/
├── Controllers/         # API controllers
├── Data/               # Database context and initialization scripts
├── Entities/           # Data models
├── Repositories/       # Data access layer
├── Services/           # Business logic
└── Properties/         # Launch settings
```

## API Endpoints

- `GET /api/results` - Get game results
- `POST /api/results` - Save game result

Visit `http://localhost:5202/swagger` for complete API documentation.

## Environment Variables

- `POSTGRES_CONNECTION_STRING` - PostgreSQL connection string
- `ASPNETCORE_ENVIRONMENT` - Environment (Development/Production)

## Configuration

The application uses the following configuration files:

- `appsettings.json` - Base configuration
- `appsettings.Development.json` - Development-specific settings
- `Properties/launchSettings.json` - Launch profiles and environment variables

## Troubleshooting

### Common Issues

1. **Database connection issues:**
   - **Docker:** Ensure Docker is running and container is up: `docker-compose ps` (from project root)
   - **Manual setup:** Ensure PostgreSQL is running
   - Verify connection string in `launchSettings.json`
   - Check database and user permissions

2. **Backend compilation issues:**
   - Ensure .NET 8 SDK is installed: `dotnet --version`
   - Restore packages: `dotnet restore`
   - Clean and rebuild: `dotnet clean && dotnet build`

3. **Port conflicts:**
   - If ports 5202 or 7110 are in use, update the `applicationUrl` in `launchSettings.json`

## Development Notes

- This project uses manual database schema setup (no Entity Framework migrations)
- CORS is enabled for development
- Swagger/OpenAPI documentation is available in development mode
- The application follows RESTful API design principles
