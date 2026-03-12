## Why

Migrating the backend application from .NET 8 to the newly released .NET 10 is necessary to stay current with Microsoft's support lifecycle, take advantage of the latest performance improvements, C# language features, and runtime enhancements.

## What Changes

- Update `global.json` to target .NET 10 SDK.
- Update `Directory.Build.props` or all `.csproj` files to target `net10.0`.
- Update any Microsoft and third-party NuGet packages to their .NET 10 compatible versions in `Directory.Packages.props` or project files.
- Fix any breaking changes introduced in .NET 9 and .NET 10 as needed.

## Capabilities

### New Capabilities
None. This is a purely technical platform upgrade.

### Modified Capabilities
None.

## Impact

- All backend C# projects (`Application`, `Domain`, `Infra`, `Web`) will be rebuilt and re-tested against .NET 10.
- CI/CD pipelines relying on .NET SDK will need the newer version.
- Any Dockerfiles used for building/running the backend will need to base their images off .NET 10 images.
