# StarWarsSupply

## Summary

Thinking that a starship needs to cover a specific distance, for complete its mission it needs to resupply things like food, energy, tools, or just give some rest to its crew.

So, keeping it in mind, this is a simple application that calculates how many resupply stops are required for each starship to cover a given distance in mega lights (MGLT).

<sup>
    * The real reason for this project is to aggregate knowledge about new technologies.
</sup>

## Requeriments

* [.NET Core 3.1] - SDK/RunTime Microsoft .NET Core 3.1 <https://dotnet.microsoft.com/download/dotnet-core/3.1>

* (Optional) [Visual Studio] - Microsoft Visual Studio or another tool.

* (Optional) Docker (Docker for Windows or Mac) - If you prefer just to run the project with Docker locally :smile:
<https://www.docker.com/get-started>

** There are two applications that work independently

1. Console Application (Console/Prompt)
2. Web Application (WebApi + Angular)

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

#### **Visual Studio Approach**

##### *You can choose to run it using IISExpress or Docker*

### STEP 1 - BACKEND - (WebApi)

#### **IIS Express**

1) Open solution file [...src\StarWarsSupplyCalculator.sln] in your Visual Studio
2) Set the project [Presentation/Presentation.WebAPI] as StartUp Project
3) Press the VS play button 'IISExpress' (This action should restore the Nuget Packages)

    :warning: *Make sure that you are running nothing on Docker using the port 44351, avoiding port conflict*.

4) Just Test your API typing this url in a browser: <http://localhost:44351/api/Starship/1000000> (It is a GET, just wait for the Json result)

Swagger: <http://localhost:44351/swagger>

##### **Test Steps**

1) Open solution file [StarWarsSupplyCalculator.sln] in your Visual Studio
2) Choose Menu Test/Run All Tests

#### **Docker Compose**

:warning: *Make sure that Docker is running in your machine*

1) On the command prompt [...\src\] run:

    ```sh
    docker-compose up --build
    ```

OR:

1) Open solution file [...\src\StarWarsSupplyCalculator.sln] in your Visual Studio as **Administrator**
2) Set the project 'docker-compose' as StartUp Project (*wait one moment, because the VS will pull all needed images to run under docker*)
3) Press play button 'Docker Compose'
4) Just Test your API - <http://localhost:44351/api/Starship/1000000>

Swagger: <http://localhost:8082/swagger>

#### **Docker Hub Image**

1) Make sure that your Docker is running
2) Open your prompt and execute this code below:

    ```sh
    docker run -p 44351:44351 andreraica/starwarssupplycalculator_webapi
    ```

3) try it: <http://localhost:44351/api/Starship/1000000>

Swagger: <http://localhost:8082/swagger>

#### **How was this image built & published?**

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

### STEP 2 - FRONTEND (WebSite)

> On your prompt (PowerShell, DOS or your favorite Prompt) - Angular Front

Current Api url is setted on Configuration file [src\environments\environments.ts]
> <http://localhost:44351/api>

Angular Cli needed to run the **NG** command

```sh
npm install -g @angular/cli
```

1) Go to the [StarWarsSupply\WebApp\src] folder
2) run command:

    ```sh
    npm install

    ng serve --open
    ````

3) Access your WebApp - ex. <http://localhost:4200>
4) Type the MGLT int the console and wait (example 1000000)
5) Wait some seconds and you will see the return json calculated list :)

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
