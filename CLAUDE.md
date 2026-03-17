# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

**MarcusMedina.Fluent.Text.Core** - A C# NuGet package providing fluent extensions and a builder API for string manipulation, casing, counting, extraction, validation, and more.

- **Language:** C# 14.0
- **Framework:** .NET 10.0+
- **Pattern:** Fluent Builder API + Extension Methods
- **License:** MIT

## Quick Commands

### Development
```bash
# Restore and build
cd csharp
dotnet restore
dotnet build --configuration Release

# Run tests
dotnet test --configuration Release

# Pack NuGet package
dotnet pack src/MarcusMedina.Fluent.Text.Core/MarcusMedina.Fluent.Text.Core.csproj --configuration Release

# Run single test
dotnet test --filter ClassName.MethodName
```

### Release & Publishing
```bash
# Create version tag (triggers GitHub Actions)
git tag -a v2.0.0 -m "Release v2.0.0"
git push origin v2.0.0

# The multi-stage GitHub Actions pipeline will:
# 1. Build and test
# 2. Run CodeQL security analysis
# 3. Sign packages with certificate
# 4. Publish to NuGet.org
```

## Architecture

### Core Components

**Builder** (`Builders/`)
- `FluentTextBuilder` - Main fluent builder for composing text operations

**Extensions** (`Extensions/`)
- `StringCasingExtensions` - Case transformations (PascalCase, camelCase, kebab-case, etc.)
- `StringCountingExtensions` - Character/word/line counting operations
- `StringDataFormatExtensions` - Data format detection and conversion
- `StringExtractionExtensions` - Substring and pattern extraction
- `StringLineEndingExtensions` - Line ending normalisation and conversion
- `StringManipulationExtensions` - General string manipulation (trim, pad, reverse, etc.)
- `StringPatternExtensions` - Pattern matching and regex helpers
- `StringValidationExtensions` - Input validation (email, URL, numeric, etc.)

### File Structure
```
csharp/
├── MarcusMedina.Fluent.Text.Core.slnx
├── src/MarcusMedina.Fluent.Text.Core/
│   ├── Builders/              # Fluent builder implementation
│   └── Extensions/            # Extension method categories
│       ├── Casing/
│       ├── Counting/
│       ├── DataFormat/
│       ├── Extraction/
│       ├── LineEndings/
│       ├── Manipulation/
│       ├── Pattern/
│       └── Validation/
└── tests/MarcusMedina.Fluent.Text.Core.Tests/
    ├── Builders/              # Builder tests
    └── Extensions/            # Extension method tests
```

## Testing Strategy

- **Framework:** xUnit with FluentAssertions
- **Coverage:** Target 80%+
- **Approach:** Unit tests per extension category and builder

## GitHub Actions Workflow

**Release Pipeline** (`.github/workflows/release.yml`)

Triggers on: `git push` with `v*` tags or to `main`/`release` branches

4-stage pipeline:
1. **Build & Test** - Restore, build, test, pack (produces unsigned packages)
2. **Quality Gate** - CodeQL analysis, vulnerability scanning
3. **Package Signing** - Sign packages, verify signatures, generate SHA256 checksums
4. **Publish to NuGet** - Only runs on version tags (refs/tags/v*)

**Required Secrets:**
- `NUGET_API_KEY` - NuGet.org API key
- `NUGET_SIGNING_CERT` - Base64-encoded signing certificate (.pfx)
- `NUGET_SIGNING_CERT_PASSWORD` - Certificate password

## NuGet Package Configuration

Key settings in `.csproj`:
- **Package ID:** `MarcusMedina.Fluent.Text.Core`
- **Version:** 2.0.0 (breaking change: PackageId corrected from `MarcusMedina.Fluent.Text.Core.Core`)
- **License:** MIT
- **Repository:** GitHub repository URL

## Breaking Changes (v2.0.0)

- **PackageId renamed** from `MarcusMedina.Fluent.Text.Core.Core` to `MarcusMedina.Fluent.Text.Core`
- **Target framework** upgraded from .NET 8.0 to .NET 10.0

## Common Issues & Solutions

**Build Fails on Test Project:**
- Verify path in test .csproj: `../../src/MarcusMedina.Fluent.Text.Core/MarcusMedina.Fluent.Text.Core.csproj`

**GitHub Actions Workflow Fails:**
- Check that `csharp/` folder structure matches workflow paths
- Verify secrets are configured in repository settings
- Ensure .NET 10.0.x is available in ubuntu-latest
