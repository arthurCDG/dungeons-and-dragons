## Why

The frontend is currently split between older Angular application patterns and newer standalone-style usage, which raises upgrade risk and makes state flow harder to reason about. Angular 19 also approaches the end of its support window, so moving to Angular 21 now reduces platform drift while creating a clear target architecture for future frontend work.

## What Changes

- Upgrade the frontend application from Angular 19 to Angular 21, aligning Angular core, CLI, CDK, Material, and related tooling on compatible versions.
- Modernize application bootstrap and routing patterns so the app uses Angular 21-supported conventions consistently instead of a mixed NgModule and standalone style.
- Introduce a standard NgRx Signal Store pattern for shared application state and feature-level state.
- Migrate priority flows away from ad hoc component subscriptions, event bus messaging, and duplicated service instances toward store-driven state and effects.
- Establish migration boundaries so thin HTTP services remain API adapters while stores own UI-facing state, derived data, and loading or error status.

## Capabilities

### New Capabilities
- `frontend-platform-upgrade`: Defines the supported Angular 21 frontend platform baseline, including aligned framework dependencies, bootstrap conventions, and routing integration.
- `frontend-signal-store-state`: Defines how shared and feature state are managed through NgRx Signal Store instead of scattered component-level subscriptions and event relays.

### Modified Capabilities

None.

## Impact

Affected areas include the Angular workspace configuration, package dependencies, application bootstrap, route configuration, auth and session handling, and feature flows such as adventure, players, campaigns, and authentication pages. This change also affects frontend developer conventions by standardizing state management around NgRx Signal Store and reducing reliance on local component service providers for shared state.