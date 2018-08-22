# StarWarsSupply

This simple console application calculate how many stops for resupply are required to cover a given distance in mega lights (MGLT).

### Requeriments

* [Visual Studio] - Microsoft Visual Studio!
* [.NET Core 2.1] - SDK/RunTime Microsoft .NET Core 2.1 [https://www.microsoft.com/net/download/dotnet-core/2.1]

### Run Steps

```sh
Open solution file [StarWarsSupplyCalculator.sln] in your Visual Studio
Set the project Console/StarWarsSupplyConsole as StartUp Project
Press play button (This action should restore the Nuget Packages)
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

### Basic Tech

**This project is using SOLID concepts**

* User Input: Console Application
* Project Tiers: Class Library
* Project Test: xUnit

**Tiers:**
>Domain 
* Model & Services: Domain is a global tier used by all tiers providing the main entities and services

>Infrastructure
* Data: This tier consumes the WebAPI. It has your own model to manipulate the JSON and response to Services 
* IoC: This tier just Inject all dependencies (DI) - using package SimpleInjector

>Tests
* This project implements all the mensurable tests in the scope

### Next Steps Todo

 - Intercep exception & http_errors on HttpClient 
 - Add Tests to HttpClient Interface
 - Think about change to Async Methods when consuming multiple SWAPI paged result
 - Add API resources and middleware Swagger
 - Add coverage tests remaining Tiers

License
----

**Free by Andre Raiça Silva**