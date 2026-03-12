## ADDED Requirements

### Requirement: Angular 21 platform baseline
The frontend application SHALL use an Angular 21-compatible dependency set in which Angular core packages, Angular CLI, Angular Material, Angular CDK, and required build tooling are aligned on mutually supported versions.

#### Scenario: Installing frontend dependencies
- **WHEN** a developer installs frontend dependencies for the workspace
- **THEN** the dependency graph resolves without Angular major-version mismatches across Angular core, CLI, Material, and CDK packages

#### Scenario: Running the frontend build
- **WHEN** a developer runs the configured frontend build command
- **THEN** the application builds successfully on the Angular 21 dependency baseline

### Requirement: Provider-based application bootstrap
The frontend application SHALL bootstrap through Angular 21 provider-based application configuration rather than relying on a root NgModule as the primary composition boundary.

#### Scenario: Starting the frontend application
- **WHEN** the frontend application starts
- **THEN** routes, HTTP client configuration, locale configuration, and root providers are registered through the Angular application bootstrap configuration

### Requirement: Supported routing composition
The frontend application SHALL expose a routing configuration that remains compatible with the Angular 21 bootstrap model and allows route protection to be applied through shared root-provided auth state.

#### Scenario: Navigating to an authenticated route
- **WHEN** an unauthenticated user navigates to a protected application route
- **THEN** the routing configuration can enforce access control without requiring page-local auth service instances