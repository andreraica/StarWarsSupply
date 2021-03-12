
# StarWarsSupply WebApi

## How to run it

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