# dotnet publish -c Release -o publish

FROM microsoft/dotnet:2.1-sdk
EXPOSE 44351

COPY ./publish /publish
WORKDIR /publish

ENTRYPOINT ["dotnet", "StarWarsSupply.Presentation.WebAPI.dll"]

# docker build -t andreraica/starwarssupplycalculator_webapi .
