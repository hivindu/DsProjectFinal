#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Src/Users/Admin/AdminUser.API/AdminUser.API.csproj", "Src/Users/Admin/AdminUser.API/"]
RUN dotnet restore "Src/Users/Admin/AdminUser.API/AdminUser.API.csproj"
COPY . .
WORKDIR "/src/Src/Users/Admin/AdminUser.API"
RUN dotnet build "AdminUser.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AdminUser.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdminUser.API.dll"]