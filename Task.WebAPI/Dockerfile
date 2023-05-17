#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Task.WebAPI/TaskManage.WebAPI.csproj", "Task.WebAPI/"]
COPY ["Task.Entities/TaskManage.Entities.csproj", "Task.Entities/"]
COPY ["Task.Core/TaskManage.Core.csproj", "Task.Core/"]
COPY ["TaskManage.Base/TaskManage.Base.csproj", "TaskManage.Base/"]
COPY ["Task.ViewModels/TaskManage.ViewModels.csproj", "Task.ViewModels/"]
COPY ["Task.DTOs/TaskManage.DTOs.csproj", "Task.DTOs/"]
COPY ["Task.Validations/TaskManage.Validations.csproj", "Task.Validations/"]
COPY ["Task.Common/TaskManage.Common.csproj", "Task.Common/"]
COPY ["Task.Repositories/TaskManage.Repositories.csproj", "Task.Repositories/"]
COPY ["Task.Data/TaskManage.Data.csproj", "Task.Data/"]
COPY ["Task.Services/TaskManage.Services.csproj", "Task.Services/"]
RUN dotnet restore "Task.WebAPI/TaskManage.WebAPI.csproj"
COPY . .
WORKDIR "/src/Task.WebAPI"
RUN dotnet build "TaskManage.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TaskManage.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskManage.WebAPI.dll"]