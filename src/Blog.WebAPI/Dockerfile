
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["src/Blog.WebAPI/Blog.WebAPI.csproj", "Blog.WebAPI/"]
COPY ["src/Blog.Application/Blog.Application.csproj", "Blog.Application/"]
COPY ["src/Blog.Infrastructure/Blog.Infrastructure.csproj", "Blog.Infrastructure/"]
COPY ["src/Blog.Core/Blog.Core.csproj", "Blog.Core/"]

RUN dotnet restore "Blog.WebAPI/Blog.WebAPI.csproj"

WORKDIR "/src/Blog.WebAPI"


COPY . .


RUN dotnet build "Blog.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Blog.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Blog.WebAPI.dll"]
