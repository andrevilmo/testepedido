FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app

#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
FROM mcr.microsoft.com/dotnet/sdk:9.0-alpine AS build
WORKDIR /src

COPY ["back/back.csproj", "back/"]
COPY ["db/db.csproj", "db/"]
COPY ["service/service.csproj", "service/"]
RUN dotnet restore "back/back.csproj"
COPY . .
WORKDIR "/src/back"
RUN dotnet build "back.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "back.csproj" -c Release -o /app/publish /p:UseAppHost=true /p:PublishReadyToRun=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "back.dll"]
