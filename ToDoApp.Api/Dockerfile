FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

ARG PROJ="ToDoApp.Api.csproj"

COPY . .
RUN dotnet restore $PROJ 
RUN dotnet build -c Release $PROJ --no-restore
RUN dotnet publish -c Release -o /app $PROJ --no-build --no-restore

FROM base AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "ToDoApp.Api.dll"]
