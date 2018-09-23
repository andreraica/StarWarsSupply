FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 60544
EXPOSE 44351

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY StarWarsSupplyWebAPI/StarWarsSupplyWebAPI.csproj StarWarsSupplyWebAPI/
COPY Infrastructure.IoC/Infrastructure.IoC.csproj Infrastructure.IoC/
COPY Domain.Services/Domain.Services.csproj Domain.Services/
COPY Domain.Models/Domain.Models.csproj Domain.Models/
COPY Domain.Interfaces/Domain.Interfaces.csproj Domain.Interfaces/
COPY Infrastructure.Data/Infrastructure.Data.csproj Infrastructure.Data/
RUN dotnet restore StarWarsSupplyWebAPI/StarWarsSupplyWebAPI.csproj
COPY . .
WORKDIR /src/StarWarsSupplyWebAPI
RUN dotnet build StarWarsSupplyWebAPI.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish StarWarsSupplyWebAPI.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "StarWarsSupplyWebAPI.dll"]
