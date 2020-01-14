FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/Services/Researcher/Researcher.API/Researcher.API.csproj", "src/Services/Researcher/Researcher.API/"]
COPY ["src/DataModels/StreamLineModels/StreamLineModels.csproj", "src/DataModels/StreamLineModels/"]
RUN dotnet restore "src/Services/Researcher/Researcher.API/Researcher.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Researcher/Researcher.API"
RUN dotnet build "Researcher.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Researcher.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Researcher.API.dll"]