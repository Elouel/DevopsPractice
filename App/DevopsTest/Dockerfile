#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY [".", "DevopsTest/"]

RUN dotnet restore "DevopsTest/DevopsTest.csproj"

COPY . .
WORKDIR "/src/DevopsTest"
RUN dotnet publish "DevopsTest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app

EXPOSE 80
EXPOSE 443

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "DevopsTest.dll"]