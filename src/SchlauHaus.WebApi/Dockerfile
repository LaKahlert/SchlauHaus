#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/SchlauHaus.WebApi/SchlauHaus.WebApi.csproj", "src/SchlauHaus.WebApi/"]
COPY ["src/SchlauHaus.Abstractions/SchlauHaus.Abstractions.csproj", "src/SchlauHaus.Abstractions/"]
RUN dotnet restore "src/SchlauHaus.WebApi/SchlauHaus.WebApi.csproj"
COPY . .
WORKDIR "/src/src/SchlauHaus.WebApi"
RUN dotnet build "SchlauHaus.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SchlauHaus.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SchlauHaus.WebApi.dll"]