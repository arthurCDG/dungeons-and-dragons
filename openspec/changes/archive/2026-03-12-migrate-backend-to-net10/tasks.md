## 1. Upgrade Target Frameworks and SDK

- [x] 1.1 Update `global.json` to target the .NET 10 SDK version.
- [x] 1.2 Update all backend `TargetFramework` properties to `net10.0` (in `Directory.Build.props` or individual `*csproj` files under `Application`, `Domain`, `Infra`, `Web`).

## 2. Update NuGet Dependencies

- [x] 2.1 Update Microsoft.* packages (EF Core, AspNetCore, etc.) to their .NET 10 compatible versions in `Directory.Packages.props` or `*csproj` files.
- [x] 2.2 Verify and update any third-party NuGet packages that require an update for .NET 10.

## 3. Resolve Compilation and Runtime Issues

- [x] 3.1 Run `dotnet build` on the backend solution and fix any compilation errors or warnings introduced by .NET 10.
- [x] 3.2 Run all integration and unit tests and ensure they pass on .NET 10.

## 4. Final Verification

- [x] 4.1 Update any Dockerfiles or CI/CD configuration files to use the .NET 10 SDK/Runtime images.
- [x] 4.2 Verify the backend runs locally using `.NET 10`.