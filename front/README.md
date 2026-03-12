# DndFront

This frontend now targets Angular 21 and uses provider-based application bootstrap.

## Development server

Run `npm start` or `ng serve` for a dev server. Navigate to `http://localhost:4200/`.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `npm run build` to build the project. The build artifacts will be stored in the `dist/` directory.

## Running unit tests

Run `npm test -- --watch=false --browsers=ChromeHeadless` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Frontend conventions

- Application bootstrap lives in `src/app/app.config.ts` and `src/main.ts`. Do not reintroduce a root `AppModule`.
- Shared auth and session state belongs in the root `SessionStore` under `src/app/stores/session`.
- Feature routes with non-trivial UI state should use route-scoped Signal Stores under `src/app/stores/<feature>`.
- HTTP services remain thin transport adapters. Components should prefer reading signals from stores rather than subscribing directly to services.
- When a child component participates in a route-level flow, prefer injecting the route store from the page provider instead of adding local shared service providers.

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via a platform of your choice. To use this command, you need to first add a package that implements end-to-end testing capabilities.

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI Overview and Command Reference](https://angular.io/cli) page.
