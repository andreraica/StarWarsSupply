# StarWarsSupply

This is a simple application that calculate how many stops for resupply are required to cover a given distance in mega lights (MGLT).

**Both works independentily**
*Console Application (Console/Prompt)
*Web Application (WebApi + Angular)

### Requeriments

* [Visual Studio] - Microsoft Visual Studio!
* [.NET Core 2.1] - SDK/RunTime Microsoft .NET Core 2.1 [https://www.microsoft.com/net/download/dotnet-core/2.1]
* (Optional) Docker Tools (Docker for Windows or Mac) - If you want to run the project with Docker :)

### CONSOLE APPLICATION - Run Steps
****
#### >>> Visual Studio Solution
1) Open solution file [StarWarsSupplyCalculator.sln] in your Visual Studio
2) Set the project Console/StarWarsSupplyConsole as StartUp Project
3) Press play button (This action should restore the Nuget Packages)
4) Input MGLT in console and wait (example 1000000)

#### >>> Docker Hub Image
1) Make sure that your Docker is running
2) Open your prompt and execute this code bellow:
```sh
docker run -a stdin -a stdout -i -t andreraica/starwarssupplycalculator
```
3) Input MGLT in console and wait (example 1000000)

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

### WEB APPLICATION - Run Steps
****
**You Can decide if Step1 must run on IISExpress or Docker**
#### >>> Visual Studio Solution 

### STEP 1 - Backend
#### IIS Express - WebApi (Step1)
1) Open solution file [StarWarsSupplyCalculator.sln] in your Visual Studio
2) Set the project Presentation/StarWarsSupplyWebAPI as StartUp Project
3) Press play button 'IISExpress' (This action should restore the Nuget Packages - Make sure that all your Docker containers are stopped, avoiding ports conflicts)
4) Just Test your API running: - ex. https://localhost:44351/api/Starship/1000000 (wait for the Json result)

#### Docker Compose - WebApi (Step1) - UNDER CONSTRUCTION (compose file hidded, if you want to try just add to the solution)
**Make sure that your Docker is running in your machine**
1) Open solution file [StarWarsSupplyCalculator.sln] in your Visual Studio as **Administrator**
2) Set the project 'docker-compose' as StartUp Project
3) Press play button 'Docker Compose'
4) Just Test you API - ex. https://localhost:44351/api/Starship/1000000


### STEP 2 - Frontend
#### >>> PowerShell (Use your favorite Prompt) - Angular Front (Step2)
1) Go to the 'StarWarsSupply\WebApp' folder
2) run command:
```sh
ng serve
````
3) Acess your WebApp - ex. http://localhost:4200
3) Input MGLT in console and wait (example 1000000)
4) Wait some seconds and you will see the return calculated list :)


### Test Steps

1) Open solution file [StarWarsSupplyCalculator.sln] in your Visual Studio
2) Choose Menu Test/Run All Tests

# About Project!
****
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

* User Input 1: Console Application
* User Input 2: Angular Application / WebAPI
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

**General**

 - Intercept exceptions 
 - Think about change to Async Methods when consuming multiple SWAPI paged result
 - Add middleware Swagger
 - Adjust to read AppSettings.json
 - Ajust Docker Compose to start Angular together WebApi (same container) 
 - Add coverage tests remaining Tiers

**FrontEnd**

 - Add Configuration File
 
License
----

**Free by Andre Raiça Silva**