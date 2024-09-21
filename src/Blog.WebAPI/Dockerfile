# Base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

# Build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy project files
COPY ["src/Blog.WebAPI/Blog.WebAPI.csproj", "Blog.WebAPI/"]
COPY ["src/Blog.Application/Blog.Application.csproj", "Blog.Application/"]
COPY ["src/Blog.Infrastructure/Blog.Infrastructure.csproj", "Blog.Infrastructure/"]
COPY ["src/Blog.Core/Blog.Core.csproj", "Blog.Core/"]

# Restore dependencies
RUN dotnet restore "Blog.WebAPI/Blog.WebAPI.csproj"
# Set the working directory for building
WORKDIR "/src/Blog.WebAPI"

# Copy the remaining files
COPY . .


# Build the application
RUN dotnet build "Blog.WebAPI.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Blog.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Blog.WebAPI.dll"]
