## ADDED Requirements

### Requirement: Root session state uses Signal Store
The frontend application SHALL manage shared session state through a root-provided NgRx Signal Store that owns authentication status, current user identity, and auth-driven UI state.

#### Scenario: Reading session state in shared UI
- **WHEN** shared UI elements such as the header need authentication or user identity state
- **THEN** they read that state from the root session store instead of coordinating through an event bus or duplicated auth service providers

#### Scenario: Logging in or out
- **WHEN** a user logs in or logs out
- **THEN** the root session store updates the shared authentication state and the UI reacts from that single source of truth

### Requirement: Feature routes use feature-level Signal Stores
Feature routes with non-trivial UI state SHALL use NgRx Signal Store instances to own route-level state, derived values, loading status, and mutations that are currently distributed across multiple components.

#### Scenario: Loading a feature route
- **WHEN** a user opens a feature route such as the adventure page
- **THEN** the route can initialize its data, loading state, and derived selections through a dedicated feature store

#### Scenario: Coordinating child interactions
- **WHEN** child components trigger route-level mutations such as selecting a square, ending a turn, or refreshing player state
- **THEN** those mutations are coordinated through the feature store rather than through sibling component subscriptions or duplicated local services

### Requirement: Services and stores have distinct responsibilities
The frontend architecture SHALL preserve a separation in which HTTP services remain transport adapters and Signal Stores own UI-facing state, derived values, and mutation workflows.

#### Scenario: Fetching backend data for a page
- **WHEN** a page needs backend data
- **THEN** the store obtains the data through an injected service and exposes the resulting UI state through signals

#### Scenario: Representing loading and error state
- **WHEN** a request is pending or fails
- **THEN** the store exposes loading and error state to components without requiring each component to maintain its own duplicate request bookkeeping