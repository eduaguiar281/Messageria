FROM mcr.microsoft.com/dotnet/core/runtime:2.2-stretch-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Aguiar.Mensageria.Console/Aguiar.Mensageria.ConsoleApp.csproj", "Aguiar.Mensageria.Console/"]
COPY ["Aguiar.Mensageria.Services/Aguiar.Mensageria.Services.csproj", "Aguiar.Mensageria.Services/"]
COPY ["Aguiar.Mensageria.Core/Aguiar.Mensageria.Core.csproj", "Aguiar.Mensageria.Core/"]
RUN dotnet restore "Aguiar.Mensageria.Console/Aguiar.Mensageria.ConsoleApp.csproj"
COPY . .
WORKDIR "/src/Aguiar.Mensageria.Console"
RUN dotnet build "Aguiar.Mensageria.ConsoleApp.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Aguiar.Mensageria.ConsoleApp.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Aguiar.Mensageria.ConsoleApp.dll"]