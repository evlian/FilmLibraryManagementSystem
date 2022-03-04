FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY "Pixond/Pixond.App.csproj" .
RUN dotnet restore
COPY . .
RUN dotnet publish "Pixond/Pixond.App.csproj" -c release -o /app
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Pixond.App.dll"]