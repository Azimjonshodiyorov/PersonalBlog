FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Blog.WebAPI loyihasi uchun nisbiy yo'l to'g'ri
COPY ["Blog.WebAPI/Blog.WebAPI.csproj", "Blog.WebAPI/"]

# Boshqa loyihalar uchun yo'llar to'g'ri bo'lishi kerak
COPY ["../Blog.Application/Blog.Application.csproj", "../Blog.Application/"]
COPY ["../Blog.Infrastructure/Blog.Infrastructure.csproj", "../Blog.Infrastructure/"]
COPY ["../Blog.Core/Blog.Core.csproj", "../Blog.Core/"]

RUN dotnet restore "Blog.WebAPI/Blog.WebAPI.csproj"
COPY . .
WORKDIR "/src/Blog.WebAPI"
RUN dotnet build "Blog.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Blog.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Blog.WebAPI.dll"]
