# AstraEngine

A small game engine for learning and fun!

## API

You can find the API here: [LINK](https://gameenginedesign-s24.github.io/AstraEngine/)

## Contribution Guidelines

1. When possible, open an issue first to create a space for discussion
2. When creating a Pull Request reference the issue
3. Whenever possible provide unit tests showing use cases for new features
4. Whenever possible provide an example project in `AstraEngine.Examples`
5. Large PRs are discouraged, when possible break large PRs into smaller components

## Generating Test Coverage

This requires ReportGenerator: [LINK](https://github.com/danielpalme/ReportGenerator)

This can be installed globally using: `dotnet tool install -g dotnet-reportgenerator-globaltool`

```
dotnet test -p:CollectCoverage=true -p:CoverletOutputFormat=cobertura
reportgenerator -reports:AstraEngine.Tests/coverage.cobertura.xml  -targetdir:html-coverage-report/
```