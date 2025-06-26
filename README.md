# Tic Tac Toe Game

A full-stack Tic Tac Toe game built with Angular frontend and .NET 8 backend, using PostgreSQL database.

## Technology Stack

### Backend

- **.NET 8** - Web API
- **Entity Framework Core 8.0.17** - ORM
- **PostgreSQL** - Database (via Npgsql.EntityFrameworkCore.PostgreSQL 8.0.11)
- **Swagger** - API Documentation

### Frontend

- **Angular 20** - Frontend Framework
- **Node.js v20** - Runtime Environment
- **TypeScript** - Programming Language
- **SASS** - Styling

## Prerequisites

Before running this project, ensure you have the following installed:

- **.NET 8 SDK** - [Download here](https://dotnet.microsoft.com/download/dotnet/8.0)
- **Node.js v20** - [Download here](https://nodejs.org/)
- **PostgreSQL** - [Download here](https://www.postgresql.org/download/) OR **Docker** - [Download here](https://www.docker.com/get-started)

## Database Setup

### Option 1: Using Docker Compose (Recommended)

If you have Docker installed, you can use the provided `docker-compose.yml` file to run PostgreSQL in a container:

1. **Start the PostgreSQL container:**

   ```bash
   docker-compose up -d
   ```

   This will:
   - Start a PostgreSQL container on port 5432
   - Create the database `tic_tac_toe`
   - Set up user `root` with password `root`
   - Persist data using Docker volumes

2. **Initialize the database tables:**

   ```bash
   docker exec -i postgres-db psql -U root -d tic_tac_toe < backend/TicTacToe.Backend/Data/Init.sql
   ```

3. **To stop the database:**

   ```bash
   docker-compose down
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
   - Run the SQL script located at `backend/TicTacToe.Backend/Data/Init.sql`
   - You can execute this using psql or your preferred PostgreSQL client:

   ```bash
   psql -h localhost -p 5432 -U root -d tic_tac_toe -f backend/TicTacToe.Backend/Data/Init.sql
   ```

## Backend Setup (.NET 8 API)

1. **Navigate to the backend directory:**

   ```bash
   cd backend/TicTacToe.Backend
   ```

2. **Restore NuGet packages:**

   ```bash
   dotnet restore
   ```

3. **Configure the database connection:**
   - The connection string is configured in `Properties/launchSettings.json`
   - Default connection: `Host=localhost;Port=5432;Database=tic_tac_toe;Username=root;Password=root`
   - Update the `POSTGRES_CONNECTION_STRING` environment variable if needed

4. **Run the backend:**

   ```bash
   dotnet run
   ```

   The API will be available at:
   - HTTP: `http://localhost:5202`
   - HTTPS: `https://localhost:7110`
   - Swagger UI: `http://localhost:5202/swagger`

## Frontend Setup (Angular 20)

1. **Navigate to the frontend directory:**

   ```bash
   cd frontend
   ```

2. **Install dependencies:**

   ```bash
   npm ci
   ```

3. **Configure the API endpoint:**
   - Update `src/environments/environment.ts` if your backend API is running on a different URL
   - Default configuration:

     ```typescript
     export const environment = {
       production: false,
       apiUrl: 'http://localhost:5202/api',
     };
     ```

4. **Start the development server:**

   ```bash
   npm start
   # or
   ng serve
   ```

   The frontend will be available at: `http://localhost:4200`

## Running the Full Application

1. **Start PostgreSQL service:**
   - **Using Docker:** `docker-compose up -d`
   - **Manual installation:** Start your PostgreSQL service

2. **Start the backend API:**

   ```bash
   cd backend/TicTacToe.Backend
   dotnet run
   ```

3. **Start the frontend (in a new terminal):**

   ```bash
   cd frontend
   npm start
   ```

## Available Scripts

### Backend Scripts

- `dotnet run` - Start the development server
- `dotnet build` - Build the project

### Frontend Scripts

- `npm start` - Start development server
- `npm run build` - Build for production
- `npm run watch` - Build in watch mode

## Project Structure

```text
├── README.md                    # Main project documentation
├── docker-compose.yml           # PostgreSQL database container setup
├── backend/
│   ├── README.md               # Backend-specific documentation
│   └── TicTacToe.Backend/
│       ├── Controllers/        # API controllers
│       ├── Data/              # Database context and SQL scripts
│       ├── Entities/          # Data models
│       ├── Repositories/      # Data access layer
│       ├── Services/          # Business logic
│       ├── Properties/        # Launch settings and configurations
│       ├── Program.cs         # Application entry point
│       ├── appsettings.json   # Application configuration
│       └── *.csproj           # Project file
└── frontend/
    ├── README.md              # Frontend-specific documentation
    ├── package.json           # Node.js dependencies and scripts
    ├── angular.json           # Angular CLI configuration
    ├── tsconfig.json          # TypeScript configuration
    └── src/
        ├── index.html         # Main HTML file
        ├── main.ts            # Application bootstrap
        ├── styles.sass        # Global styles
        ├── app/
        │   ├── app.ts         # Root component
        │   ├── components/    # Angular components
        │   ├── interfaces/    # Angular interfaces
        │   └── services/      # Angular services
        └── environments/
            └── environment.ts  # Environment configuration
```

## API Endpoints

- `GET /api/results/last` - Get last 10 game results
- `POST /api/results` - Save game result

Visit `http://localhost:5202/swagger` for complete API documentation.

## Environment Variables

### Backend Environment Variables

- `POSTGRES_CONNECTION_STRING` - PostgreSQL connection string
- `ASPNETCORE_ENVIRONMENT` - Environment (Development/Production)

## Troubleshooting

### Common Issues

1. **Database connection issues:**
   - **Docker:** Ensure Docker is running and container is up: `docker-compose ps`
   - **Manual setup:** Ensure PostgreSQL is running
   - Verify connection string in `launchSettings.json`
   - Check database and user permissions

2. **Frontend build issues:**
   - Ensure Node.js v20 is installed
   - Clear node_modules and reinstall: `rm -rf node_modules && npm install`

3. **Backend compilation issues:**
   - Ensure .NET 8 SDK is installed
   - Restore packages: `dotnet restore`

## Development

This project uses:

- Manual database schema setup (no Entity Framework migrations)
- Angular Standalone Components
- RESTful API design
- CORS enabled for development

## License

This project is for educational/demonstration purposes.
