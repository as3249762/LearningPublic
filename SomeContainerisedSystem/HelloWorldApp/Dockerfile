# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app

EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["HelloWorldApp.csproj", "nuget.config", "."]
RUN dotnet restore --configfile:nuget.config "./HelloWorldApp.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build --configfile:nuget.config "./HelloWorldApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish --configfile:nuget.config "./HelloWorldApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HelloWorldApp.dll"]