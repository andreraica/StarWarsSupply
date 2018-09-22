# StarWarsSupply

This simple console application calculate how many stops for resupply are required to cover a given distance in mega lights (MGLT).

### Requeriments

* [Visual Studio] - Microsoft Visual Studio!
* [.NET Core 2.1] - SDK/RunTime Microsoft .NET Core 2.1 [https://www.microsoft.com/net/download/dotnet-core/2.1]

### Run Steps
#### >>> Visual Studio Solution
1) Open solution file [StarWarsSupplyCalculator.sln] in your Visual Studio
2) Set the project Console/StarWarsSupplyConsole as StartUp Project
3) Press play button (This action should restore the Nuget Packages)
4) Input MGLT in console and wait (example 1000000)

#### >>> Docker Hub Image
```sh
docker run -a stdin -a stdout -i -t andreraica/starwarssupplycalculator
```

##### *How this image was built / published
File dockerfile was created inside Console Application folder
Inside the Console Application:

**Building**
```sh
dotnet publish -c Release -o publish
docker build -t andreraica/starwarssupplycalculator .
````
**Publishing**
```sh
docker login
docker push andreraica/starwarssupplycalculator
````

### Test Steps

1) Open solution file [StarWarsSupplyCalculator.sln] in your Visual Studio
2) Choose Menu Test/Run All Tests

# About Project!

### Calculation

To calcule how many stops for resupply were required this formula has applied: 

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
* Using Moq & Stubs to emulate injections and isolating the tests

**Packages:**
* Moq
* xUnit
* Newtonsoft.Json
* SimpleInjector
* Others .net Core Packages...


### Next Steps Todo

 - Intercept exceptions 
 - Think about change to Async Methods when consuming multiple SWAPI paged result
 - Add middleware Swagger
 - Adjust to read AppSettings.json
 - Add coverage tests remaining Tiers

License
----

**Free by Andre Raiça Silva**