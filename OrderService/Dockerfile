#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["ECommerce.sln", "WEBAPP/"]

COPY . WEBAPP/

WORKDIR "/src/WEBAPP"
RUN dotnet restore "ECommerce.sln"
COPY . .
RUN dotnet build "Net.API/Net.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Net.API/Net.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Net.API.dll"]

# For Test
# EXPOSE 80
# RUN dotnet build --configuration Release --no-restore
# ENTRYPOINT ["dotnet", "watch", "run", "--urls", "http://*:80"]
