## 1. Angular 21 platform alignment

- [ ] 1.1 Align Angular core, CLI, Material, CDK, and related frontend tooling on Angular 21-compatible versions
- [ ] 1.2 Update workspace bootstrap and configuration files to the Angular 21 standalone application model
- [ ] 1.3 Verify the frontend installs, builds, and starts successfully on the upgraded platform baseline

## 2. Root application composition

- [ ] 2.1 Replace root NgModule-centered composition with provider-based application bootstrap and routing registration
- [ ] 2.2 Rework route protection to use shared root-provided auth state instead of page-local auth service instances
- [ ] 2.3 Remove obsolete root composition code that is no longer needed after the standalone bootstrap migration

## 3. Session state store

- [ ] 3.1 Add NgRx Signal Store dependencies and establish a project convention for root and feature store structure
- [ ] 3.2 Implement a root session store for authentication status, current user identity, and auth-driven navigation state
- [ ] 3.3 Refactor login, logout, header, and related auth flows to consume the root session store instead of the event bus pattern

## 4. First feature-store migration

- [ ] 4.1 Implement an adventure feature store that owns page loading, selected square, current player, and refresh workflows
- [ ] 4.2 Refactor the adventure page, action bar, and square interactions to use the adventure feature store as the route-level state boundary
- [ ] 4.3 Migrate the adventure log flow to a store-backed shared state model and remove duplicate shared provider instances

## 5. Follow-on feature migrations

- [ ] 5.1 Refactor the players flow to expose page state through a feature store while keeping HTTP services as transport adapters
- [ ] 5.2 Refactor the campaigns and campaign creation flows to move derived UI state and request status into feature stores
- [ ] 5.3 Remove remaining shared-state anti-patterns such as duplicated component providers or scattered route subscriptions in migrated pages

## 6. Verification and cleanup

- [ ] 6.1 Verify that migrated routes preserve existing navigation, loading, and auth behaviors after the store migration
- [ ] 6.2 Update or add frontend tests where needed to cover session store and feature-store driven flows
- [ ] 6.3 Document the Angular 21 and NgRx Signal Store frontend conventions for future implementation work