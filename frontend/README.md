# Tic Tac Toe Frontend

Angular 20 frontend for the Tic Tac Toe game.

## Technology Stack

- **Angular 20** - Frontend Framework
- **Node.js v20** - Runtime Environment
- **TypeScript** - Programming Language
- **SASS** - Styling

## Prerequisites

- **Node.js v20** - [Download here](https://nodejs.org/)

## Setup and Installation

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

## Development Server

To start a local development server, run:

```bash
npm start
# or
ng serve
```

Once the server is running, open your browser and navigate to `http://localhost:4200/`. The application will automatically reload whenever you modify any of the source files.

## Available Scripts

- `npm start` - Start development server
- `npm run build` - Build for production
- `npm run watch` - Build in watch mode

## Building

To build the project run:

```bash
npm run build
```

This will compile your project and store the build artifacts in the `dist/` directory. By default, the production build optimizes your application for performance and speed.

## Code Scaffolding

Angular CLI includes powerful code scaffolding tools. To generate a new component, run:

```bash
ng generate component component-name
```

For a complete list of available schematics (such as `components`, `directives`, or `pipes`), run:

```bash
ng generate --help
```

## Additional Resources

For more information on using the Angular CLI, including detailed command references, visit the [Angular CLI Overview and Command Reference](https://angular.dev/tools/cli) page.
