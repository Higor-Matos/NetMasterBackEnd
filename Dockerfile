FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY NetMaster.Presentation/*.csproj ./NetMaster.Presentation/
COPY NetMaster.Common/*.csproj ./NetMaster.Common/
COPY NetMaster.Repository/*.csproj ./NetMaster.Repository/
COPY NetMaster.Services/*.csproj ./NetMaster.Services/
RUN dotnet restore

# Copy everything else and build
COPY . .
WORKDIR "/src/NetMaster.Presentation"
RUN dotnet build "NetMaster.Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NetMaster.Presentation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetMaster.Presentation.dll"]
