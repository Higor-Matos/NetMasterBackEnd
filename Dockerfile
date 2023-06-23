# Define a imagem base
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copia os projetos
COPY NetMaster.Common ./NetMaster.Common
COPY NetMaster.Domain ./NetMaster.Domain
COPY NetMaster.Infrastructure ./NetMaster.Infrastructure
COPY NetMaster.Repository ./NetMaster.Repository
COPY NetMaster.Services ./NetMaster.Services
COPY NetMaster.Presentation ./NetMaster.Presentation

# Cria o diretório de uploads
RUN mkdir -p /app/Uploads

# Restaura as dependências e compila o projeto
RUN dotnet restore NetMaster.Presentation/NetMaster.Presentation.csproj
RUN dotnet publish NetMaster.Presentation/NetMaster.Presentation.csproj -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/out .

# Configura a porta que o contêiner deve expor
EXPOSE 5018

# Define o comando a ser executado quando o contêiner iniciar
ENTRYPOINT ["dotnet", "NetMaster.Presentation.dll"]
