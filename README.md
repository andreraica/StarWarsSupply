# StarWarsSupply

This simple console application calculate how many stops for resupply are required to cover a given distance in mega lights (MGLT).

### Requeriments

* [Visual Studio] - Microsoft Visual Studio!
* [.NET Core 2.1] - SDK/RunTime Microsoft .NET Core 2.1 [https://www.microsoft.com/net/download/dotnet-core/2.1]

### Run Steps

```sh
Open solution file [StarWarsSupplyCalculator.sln] in your Visual Studio
Set the project Console/StarWarsSupplyConsole as StartUp Project
Press play button
Input MGLT in console and wait
```

### Test Steps
```sh
Open solution file [StarWarsSupplyCalculator.sln] in your Visual Studio
Choose Menu Test/Run All Tests
```

# About Project!

### Calculation

> To calcule how many stops for resupply were required
> This formula has applied: 
> consumableHours = Consumable per hour
> distanceMGLT = Input distance in MGLT
> MGLT = MGLT per Starship
> Absolute value for: distanceMGLT / (consumableHours * MGLT)

### Data API

> Every data have consumed using the free API: https://swapi.co

### Next Steps Todo

 - Add IoC and DI 
 - Add middleware Swagger
 - Refactor

License
----

Free by Andre Raiça Silva®

**Free Software**