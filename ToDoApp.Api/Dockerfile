FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

ARG BUILD_CONFIGURATION=Release
ARG DIR="ToDoApp.Api"
ARG PROJ="ToDoApp.Api.csproj"

WORKDIR /src

COPY ["$DIR/$PROJ", "$DIR/"]
RUN dotnet restore "$DIR/$PROJ"
COPY . .

WORKDIR "/src/ToDoApp.Api"
RUN dotnet build $PROJ -c $BUILD_CONFIGURATION -o /app/build --no-restore
RUN dotnet publish $PROJ -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false --no-restore --no-build

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToDoApp.Api.dll"]
