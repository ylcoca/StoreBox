#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["StoreBox/StoreBox.csproj", "StoreBox/"]
COPY ["StoreBox.Controller/StoreBox.Controller.csproj", "StoreBox.Controller/"]
COPY ["StoreBox.Service/StoreBox.Service.csproj", "StoreBox.Service/"]
COPY ["StoreBox.Repository/StoreBox.Repository.csproj", "StoreBox.Repository/"]
COPY ["StoreBox.Entities/StoreBox.Entities.csproj", "StoreBox.Entities/"]
COPY ["StoreBox.Config/StoreBox.Config.csproj", "StoreBox.Config/"]
RUN dotnet restore "StoreBox/StoreBox.csproj"
COPY . .
WORKDIR "/src/StoreBox"
RUN dotnet build "StoreBox.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StoreBox.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StoreBox.dll"]