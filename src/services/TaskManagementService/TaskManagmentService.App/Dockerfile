# См. статью по ссылке https://aka.ms/customizecontainer, чтобы узнать как настроить контейнер отладки и как Visual Studio использует этот Dockerfile для создания образов для ускорения отладки.

# Этот этап используется при запуске из VS в быстром режиме (по умолчанию для конфигурации отладки)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app

# Этот этап используется для сборки проекта службы
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/services/TaskManagementService/TaskManagmentService.App/TaskManagmentService.App.csproj", "src/services/TaskManagementService/TaskManagmentService.App/"]
COPY ["src/services/Contracts/Contracts/Contracts.csproj", "src/services/Contracts/Contracts/"]
RUN dotnet restore "src/services/TaskManagementService/TaskManagmentService.App/TaskManagmentService.App.csproj"
COPY . .
WORKDIR "/src/src/services/TaskManagementService/TaskManagmentService.App"
RUN dotnet build "./TaskManagmentService.App.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Этот этап используется для публикации проекта службы, который будет скопирован на последний этап
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TaskManagmentService.App.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Этот этап используется в рабочей среде или при запуске из VS в обычном режиме (по умолчанию, когда конфигурация отладки не используется)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskManagmentService.App.dll"]