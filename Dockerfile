# --- FAZA 1: Build Stage ---
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app
COPY *.csproj ./
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /app/publish

# --- FAZA 2: Final Stage ---
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "StudySphere.API.dll"]