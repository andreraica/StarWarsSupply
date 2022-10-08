# StarWarsSupply

## Summary

Let's think that a starship needs to complete a mission in the universe.

The commander needs to plain the trip, covering the total distance for a successfull mission, resuppling things like food, energy, tools, or just to give some rest to his crew.

So, keeping it in mind, this is a simple application that calculates how many resupply stops are required for each kind of Star Wars starship needs to cover a given distance in mega lights (MGLT).

<sup>
    * The reason for this project is to aggregate knowledge about new technologies.
</sup>

## Nice to have

* [.NET Core 6] - SDK/RunTime Microsoft .NET 6 <https://dotnet.microsoft.com/en-us/download/dotnet/6.0>

* (Optional) [Visual Studio] - Microsoft Visual Studio or another tool.

* (Optional) Docker (Docker for Windows or Mac) - If you prefer just to run the project with Docker locally :smile:
<https://www.docker.com/get-started>

## Solution Compose

There are two kind of applications that work independently
1. Console Application (Console/Prompt)
2. Web Application (Api + Front)

- - - -

### 1. CONSOLE APPLICATION - Steps

#### **Using Visual Studio Solution**

1) Open solution file [...src\StarWarsSupplyCalculator.sln] in your Visual Studio
2) Set the project [Presentation/Presentation.Console] as StartUp Project
3) Press play button (This action should restore the Nuget Packages during the first build)
4) Type the MGLT in the console and wait (example 1000000)

#### **Using Docker Hub Image**

1) Make sure that your Docker client is running locally
2) Open your prompt and execute this code below:

    ```sh
    docker run -a stdin -a stdout -i -t andreraica/starwarssupplycalculator_console --name "SWSC"
    ```

3) Type the MGLT in the console and wait (example 1000000)

#### **How was this image was built & published?**

1) The file "dockerfile" was created inside a Console Application folder [...\src\StarWarsSupplyConsole].
2) Using your console, go to this folder and execute:

##### **Building (Local)**

```sh
dotnet publish -c Release -o publish

docker build -t andreraica/starwarssupplycalculator_console .
````

##### **Publishing (DockerHub)**

```sh
docker login

docker push andreraica/starwarssupplycalculator_console
````

- - - -

### 2. WEB APPLICATION - Steps

#### STEP 1 - BACKEND - (WebApi)

##### **Source Code Solution**

> [How Run it using the source code - Readme](https://github.com/andreraica/StarWarsSupply/tree/master/src/StarWarsSupplyWebAPI)

##### **Docker Hub Image**

1) Make sure that your Docker is running
2) Open your prompt and execute this code below:

    ```sh
    docker run -p 44351:44351 andreraica/starwarssupplycalculator_webapi
    ```

3) try it: <http://localhost:44351/api/Starship/1000000>

Swagger: <http://localhost:8082/swagger>

##### **How was this image built & published?**

One file named "dockerfile" was created in the WebApi Application folder [src\StarWarsSupplyWebAPI].
Go to your prompt and execute the following command in this folder:

##### **Building**

```sh
dotnet publish -c Release -o publish

docker build -t andreraica/starwarssupplycalculator_webapi .
````

##### **Publishing**

```sh
docker login

docker push andreraica/starwarssupplycalculator_webapi
````

#### STEP 2 - FRONTEND (WebSite)

##### **Source Code Project**

> [How Run it using the source code - Readme](https://github.com/andreraica/StarWarsSupply/tree/master/src/WebApp)

- - - -

## About Project

- - - -

### **How the calculation works?**

To calcule how many stops for resupply were required, the follow formula has applied:

* consumableHours = Consumable per hour
* distanceMGLT = Input distance in MGLT
* MGLT = MGLT per Starship

> Absolute value for: distanceMGLT / (consumableHours * MGLT)

### **Where is it getting the data?**

> Every data are coming from the free web API: <https://swapi.dev>

### **What is the base tech involved?**

* User Terminal 1: Console Application
* User Interface 2: Angular Application / WebAPI
* Project Tiers: Class Library
* Project Test: xUnit
* This project uses the SOLID concepts *
* Angular - TypeScript

**Base Design Code:**
>Domain

* Model & Services: Domain is a global tier used by all tiers providing the main entities and services

>Infrastructure

* Data: This tier consumes the WebAPI. It has your own model to manipulate the JSON and response to Services 
* IoC: This tier just Inject all dependencies (DI) - using Native Injector from Microsoft

>Tests

* This project implements all the mensurable tests in the scope
* Using Moq & Stubs to emulate injections and isolating the tests

**Packages:**

* Polly
* Moq
* xUnit
* Newtonsoft.Json
* Microsoft Native Injector
* Swagger
* Others .net Core Packages...

**My Docker HUB images :**
<https://hub.docker.com/search?q=andreraica&type=image>

- - - -

**TODO (BackEnd):**

* Change httpclient for httpfactory
* Intercept exceptions corretly
* To set configuration based on AppSettings.json
* Add coverage tests remaining Tiers
* Use Queue if available

**TODO (FrontEnd):**

* Intercept excceptions
* Improve interface

- - - -

License

** Free by Andre Raiça Silva :sunglasses:
