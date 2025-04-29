# pretend that this base image has lots of files needed for build but not to run
FROM devreg.azurecr.io/devops-core/dotnet/aspnet:8.0-alpine AS base

WORKDIR /app

FROM devreg.azurecr.io/devops-core/dotnet/sdk:8.0-alpine AS build

WORKDIR /src
COPY ./src .
RUN dotnet build --configfile:nuget.config UrlHitter.Api.csproj -c Release -o /app/compiled


# pretend that this base image has only the files needed to run the app
FROM devreg.azurecr.io/devops-core/dotnet/sdk:8.0-alpine AS runtime

COPY --from=build /app/compiled /app/compiled

WORKDIR /app/compiled

EXPOSE 6000

ENV ASPNETCORE_URLS=http://+:6000

ENTRYPOINT ["dotnet", "UrlHitter.Api.dll"]