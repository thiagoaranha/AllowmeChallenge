#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["AllowmeChallenge.WebApi/AllowmeChallenge.WebApi.csproj", "AllowmeChallenge.WebApi/"]
RUN dotnet restore "AllowmeChallenge.WebApi/AllowmeChallenge.WebApi.csproj"
COPY . .
WORKDIR "/src/AllowmeChallenge.WebApi"
RUN dotnet build "AllowmeChallenge.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AllowmeChallenge.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AllowmeChallenge.WebApi.dll"]