## Context

The frontend currently mixes multiple Angular generations and state-management styles. The workspace is on Angular 19 for core packages, but Angular Material and CDK remain on 18.x, which increases upgrade friction and leaves the application close to the end of Angular 19 support. The application also mixes `AppModule` bootstrap with standalone component imports, direct component subscriptions, component-scoped service providers, and an event bus service for auth state changes.

That mixed model creates three concrete problems:
- platform upgrades require more manual reconciliation because framework, bootstrap, and library patterns are not aligned;
- shared state is easy to split accidentally across multiple service instances;
- page behavior is spread across components instead of being concentrated in a predictable store boundary.

This change introduces a consistent Angular 21 platform baseline and standardizes UI-facing state around NgRx Signal Store. Thin HTTP services remain responsible for backend communication, while stores become the place where components read state, derived values, loading state, and mutation methods.

## Goals / Non-Goals

**Goals:**
- Align Angular CLI, core packages, Material, CDK, and workspace configuration on an Angular 21-compatible baseline.
- Move application bootstrap toward Angular 21 provider-based conventions and remove the mixed bootstrap model.
- Standardize shared state and feature state on NgRx Signal Store.
- Replace ad hoc shared state patterns such as event relays and duplicated component providers in the highest-value frontend flows.
- Define a phased migration path so feature work can continue while older pages are progressively moved to stores.

**Non-Goals:**
- Rebuild every page in a single change.
- Replace all RxJS usage with signals.
- Redesign backend APIs or change backend contracts unless the Angular upgrade exposes a hard compatibility issue.
- Introduce a global store for every concern regardless of scope.

## Decisions

### Decision: Target Angular 21 as the new frontend baseline

The frontend will target Angular 21 rather than stopping on Angular 20. Angular 21 is the active major in March 2026, while Angular 19 is close to the end of support. Targeting 21 avoids doing two large architectural migrations in quick succession.

Alternatives considered:
- Stop on Angular 20 LTS. Rejected because it reduces immediate upgrade risk slightly but leaves another major upgrade still pending after the store migration work.
- Stay on Angular 19 while only introducing stores. Rejected because the project would keep platform drift and postpone dependency reconciliation.

### Decision: Use NgRx Signal Store as the standard UI-facing store pattern

NgRx Signal Store will be the standard abstraction for application session state and route-level feature state. This provides a consistent model for writable state, computed state, effects, and testable mutation methods without forcing the project into a larger classic NgRx reducer and action architecture.

Alternatives considered:
- Plain Angular signal services. Rejected because they would work technically, but they leave more room for inconsistent store shape and conventions across features.
- Classic NgRx Store. Rejected because it adds more boilerplate than this project currently needs.

### Decision: Keep HTTP services as thin observable-based API adapters

Existing data services will remain responsible for HTTP communication and will continue returning observables. Stores will compose those services, convert API responses into signal state, and expose synchronous read models to components.

Alternatives considered:
- Move HTTP directly into stores. Rejected because it couples transport concerns with store structure and makes reuse harder.
- Convert all services to signals. Rejected because observables remain the most natural fit for Angular HTTP APIs and route streams.

### Decision: Migrate state by boundary, starting with session/auth and one feature-heavy route

The migration will proceed in phases. The first phase establishes the Angular 21 baseline and root application shell. The second phase introduces a root session store for auth state, route protection, and header state. The third phase migrates a feature-heavy route, starting with the adventure flow, where state is currently fragmented across the page, action bar, square components, and local services. Simpler pages can then follow the same pattern.

Alternatives considered:
- Big-bang page rewrite. Rejected because it creates excessive review size and rollback risk.
- Migrate only trivial pages first. Rejected because it would validate the pattern on low-complexity code while leaving the hardest architectural problem unresolved.

### Decision: Favor provider-based standalone application composition

The application bootstrap will move toward provider-based configuration using Angular 21-supported standalone composition. Routes, HTTP configuration, locale configuration, and guards should be registered through application providers rather than centered on a root NgModule.

Alternatives considered:
- Retain AppModule and only update package versions. Rejected because the mixed composition style is part of the current maintenance problem.

## Risks / Trade-offs

- [Angular 21 upgrade surfaces breaking changes in Material, router, or test tooling] → Mitigation: update one major version at a time in execution, keep dependency alignment explicit, and validate build plus test commands after each step.
- [Store migration changes component contracts and introduces regressions in navigation or state refresh] → Mitigation: migrate by feature boundary, preserve existing service contracts initially, and verify route flows after each migrated feature.
- [Too much state is centralized in stores, creating unnecessary global coupling] → Mitigation: keep stores scoped by concern, with root-level stores only for session or application shell state and feature-level stores for route-specific behavior.
- [Observable and signal interop becomes inconsistent across the codebase] → Mitigation: document a clear rule that services expose observables while stores expose signals and imperative methods.
- [Shared state bugs persist because component-level providers still shadow root state] → Mitigation: remove local providers for shared concerns as part of each migrated slice and explicitly define provider scope in the implementation tasks.

## Migration Plan

1. Upgrade framework and tooling dependencies to an Angular 21-compatible set, including Material and CDK alignment.
2. Move bootstrap and root provider registration to the Angular 21 standalone application model.
3. Introduce a root session store that owns logged-in state, current user identity, and auth-driven navigation concerns.
4. Wire route guards and header behavior to the session store, removing event-bus style auth relays.
5. Introduce an adventure feature store that owns page loading state, selected square state, current player state, and mutation workflows currently spread across the page and child components.
6. Migrate additional pages such as players and campaigns using the same store boundary rules.
7. Remove obsolete component-level shared providers and dead state-management patterns once equivalent store-backed flows are in place.

Rollback strategy during implementation should remain incremental. Each migration phase must preserve a working application state before the next phase begins so that a problematic slice can be reverted without discarding the full upgrade.

## Open Questions

- Whether all pages should move to standalone routes in the same change or whether some lower-value routes can remain temporarily on the old shape after the Angular 21 baseline is established.
- Whether the first implementation slice after session state should include only the adventure page or also the adventure log and action bar child interactions in the same store rollout.
- Whether any existing frontend tests need to be restructured to better support store-driven state assertions after the migration.