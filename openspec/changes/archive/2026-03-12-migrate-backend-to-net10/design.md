## Context

The backend is currently targeting .NET 8. The objective is to migrate all backend projects to target the .NET 10 SDK and runtime. This requires updating MSBuild settings, global tools, SDK versions, and managing any potential NuGet package updates that are strictly required for compatibility with .NET 10.

## Goals / Non-Goals

**Goals:**
- Successfully upgrade `global.json` and all `.csproj` / `Directory.Build.props` to `net10.0`.
- Update Microsoft and 3rd-party dependencies to .NET 10 compatible versions, specifically those that fail or cause runtime issues on older versions.
- Fix all compilation errors and unit test failures arising from the .NET 10 upgrade.

**Non-Goals:**
- Refactoring the entire codebase to use the absolute latest C# 14/15 features across the board. (Only fixing things if they are broken or deprecated).
- Upgrading unrelated NuGet packages unless forced by compatibility.
- Changing the overall architecture or introducing new functional capabilities.

## Decisions

- **Target Framework**: We will update `TargetFramework` to `net10.0` in `back/Directory.Build.props` (or corresponding project files if they define it explicitly). This ensures all projects share the same target framework.
- **SDK Update**: Update `back/global.json` to the latest available `.NET 10` SDK.
- **Package Updates**: Central Package Management (`Directory.Packages.props`) or individual `.csproj` files will be updated to fetch `.NET 10` versions of core libraries such as `Microsoft.EntityFrameworkCore`, `Microsoft.AspNetCore.*`, etc.

## Risks / Trade-offs

- **Risk**: Some third-party NuGet packages might not yet support .NET 10 natively or could be incompatible.
  **Mitigation**: Most .NET 8/9 libraries will run fine on .NET 10 due to backward compatibility. If any library explicitly fails, look for prerelease versions or alternative packages, or temporarily defer the upgrade if it's a blocker.
- **Risk**: CI/CD pipeline breaks if the hosted agent does not have the .NET 10 SDK installed.
  **Mitigation**: Use `UseDotNet` task in Azure DevOps, or `actions/setup-dotnet` in GitHub Actions referencing `.NET 10.0.x`, or ensure the environment or Docker image is updated.
