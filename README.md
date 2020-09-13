# StarWarsSupply

This is a simple application that calculates how many resupply stops are required to cover a given distance in mega lights (MGLT).

**Both works independentily**
*Console Application (Console/Prompt)
*Web Application (Public WebApi + Angular)

### Requeriments

* [Visual Studio] - Microsoft Visual Studio!
* [.NET Core 2.1] - SDK/RunTime Microsoft .NET Core 2.1 [https://www.microsoft.com/net/download/dotnet-core/2.1]
* (Optional) Docker (Docker for Windows or Mac) - If you intend to run the project with Docker localy :smile:
    
### CONSOLE APPLICATION - How to RUN Steps
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
docker run -a stdin -a stdout -i -t andreraica/starwarssupplycalculator_console
```
3) Input MGLT in console and wait (example 1000000)

##### *How this image was built / published
The file "dockerfile" was created inside Console Application folder
Inside the Console Application folder was executed:

**Building**
```sh
dotnet publish -c Release -o publish
docker build -t andreraica/starwarssupplycalculator_console .
````
**Publishing**
```sh
docker login
docker build --tag andreraica/starwarssupplycalculator_console .
docker push andreraica/starwarssupplycalculator_console
````

### WEB APPLICATION - How to RUN Steps
****
**You can choode between run in IISExpress or Docker on Step1**
#### >>> Visual Studio Solution 

### STEP 1 - BACKEND - (WebApi)
#### IIS Express - WebApi (Step1)
1) Open solution file [StarWarsSupplyCalculator.sln] in your Visual Studio
2) Set the project Presentation/StarWarsSupplyWebAPI as StartUp Project
3) Press play button 'IISExpress' (This action should restore the Nuget Packages - Make sure that all your Docker containers are stopped, avoiding ports conflicts)
4) Just Test your API running putting this url in a browser url: - ex. https://localhost:44351/api/Starship/1000000 (wait for the Json result)

#### Docker Compose - WebApi (Step1)
**Make sure that Docker is running in your machine**
1) Open solution file [StarWarsSupplyCalculator.sln] in your Visual Studio as **Administrator**
2) Set the project 'docker-compose' as StartUp Project
3) Press play button 'Docker Compose'
4) Just Test you API - ex. https://localhost:44351/api/Starship/1000000


#### >>> Docker Hub Image
1) Make sure that your Docker is running
2) Open your prompt and execute this code bellow:
```sh
docker run -p 44351:44351 andreraica/starwarssupplycalculator_webapi
```
3) try it: https://localhost:44351/api/Starship/1000000

##### *How this image was built / published
The file "dockerfile" was created inside WebApi Application folder
Inside the WebApi Application folder was executed:

**Building**
```sh3
dotnet publish -c Release -o publish
docker build -t andreraica/starwarssupplycalculator_webapi .
````
**Publishing**
```sh
docker login
docker build --tag andreraica/starwarssupplycalculator_webapi .
docker push andreraica/starwarssupplycalculator_webapi
````


### STEP 2 - FRONTEND (WebSite)
#### >>> Command (PowerShell, DOS or your favorite Prompt) - Angular Front (Step2)
* Currently Configuration Info - src\app\startship.service.ts
```sh
https://localhost:44351/api/Starship/${mGLT}
```


1) Go to the 'StarWarsSupply\WebApp\src' folder
2) run command:
```sh
npm install
ng serve --open
````
3) Acess your WebApp - ex. http://localhost:4200
3) Input MGLT in console and wait (example 1000000)
4) Wait some seconds and you will see the return calculated list :)


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

> Every data have consumed using the free API: https://swapi.dev

### Basic Tech

**This project is using SOLID concepts**

* User Input 1: Console Application
* User Input 2: Angular Application / WebAPI
* Project Tiers: Class Library
* Project Test: xUnit

**Design Code:**
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

 - Migration .Net Core 2.1 to  3.1
 - Migration SimpleInjector Package to .Net Native Injector
 - Add a Swagger middleware 
 - Ajust Docker Compose to start Angular together WebApi (same container) 
 - Intercept exceptions 
 - Adjust to read AppSettings.json
 - Add coverage tests remaining Tiers

**FrontEnd**

 - Add Configuration File instead of fixed WebApi url
 
License

** Free by Andre Raiça Silva :sunglasses: