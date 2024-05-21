# AstraEngine

## Generating Test Coverage

This requires ReportGenerator: [LINK](https://github.com/danielpalme/ReportGenerator)

This can be installed globally using: `dotnet tool install -g dotnet-reportgenerator-globaltool`

```
dotnet test -p:CollectCoverage=true -p:CoverletOutputFormat=cobertura
reportgenerator -reports:AstraEngine.Tests/coverage.cobertura.xml  -targetdir:html-coverage-report/
```