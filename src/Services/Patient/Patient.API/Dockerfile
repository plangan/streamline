FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/Services/Patient/Patient.API/Patient.API.csproj", "src/Services/Patient/Patient.API/"]
COPY ["src/DataModels/StreamLineModels/StreamLineModels.csproj", "src/DataModels/StreamLineModels/"]
RUN dotnet restore "src/Services/Patient/Patient.API/Patient.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Patient/Patient.API"
RUN dotnet build "Patient.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Patient.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Patient.API.dll"]