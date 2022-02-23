FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY "FilmLibraryManagementSystem/FilmLibraryManagementSystem.App.csproj" .
RUN dotnet restore
COPY . .
RUN dotnet publish "FilmLibraryManagementSystem/FilmLibraryManagementSystem.App.csproj" -c release -o /app
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "FilmLibraryManagementSystem.App.dll"]