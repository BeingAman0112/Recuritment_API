# ===========================
# Base runtime image
# ===========================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Expose standard ports for local development
EXPOSE 8080
EXPOSE 8081

# Render expects to listen on PORT env variable
ENV ASPNETCORE_URLS=http://+:${PORT:-8080}

# ===========================
# Build image
# ===========================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy all projects and restore
COPY ["Recruitment_01/Recruitment_01.csproj", "Recruitment_01/"]
COPY ["Recruitment.Application/Recruitment.Application.csproj", "Recruitment.Application/"]
COPY ["Recuritment.Infrastructure/Recuritment.Infrastructure.csproj", "Recuritment.Infrastructure/"]
COPY ["Recuritment.Core/Recuritment.Core.csproj", "Recuritment.Core/"]

RUN dotnet restore "./Recruitment_01/Recruitment_01.csproj"

# Copy everything else and build
COPY . .
WORKDIR "/src/Recruitment_01"
RUN dotnet build "./Recruitment_01.csproj" -c $BUILD_CONFIGURATION -o /app/build

# ===========================
# Publish image
# ===========================
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Recruitment_01.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# ===========================
# Final runtime image
# ===========================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV ASPNETCORE_URLS=http://+:${PORT:-8080}
ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["dotnet", "Recruitment_01.dll"]
