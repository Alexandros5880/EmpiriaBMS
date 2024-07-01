# Define the base image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Define the build image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy projects
COPY ["EmpiriaBMS.Models/EmpiriaBMS.Models.csproj", "EmpiriaBMS.Models/"]
COPY ["EmpiriaBMS.Core/EmpiriaBMS.Core.csproj", "EmpiriaBMS.Core/"]
COPY ["Logging/Logging.csproj", "Logging/"]
COPY ["EmpiriaBMS.Front/EmpiriaBMS.Front.csproj", "EmpiriaBMS.Front/"]

# Clean NuGet cache
RUN dotnet nuget locals all --clear

## Clean Projects
RUN dotnet clean "Logging/Logging.csproj"
RUN dotnet clean "EmpiriaBMS.Models/EmpiriaBMS.Models.csproj"
RUN dotnet clean "EmpiriaBMS.Core/EmpiriaBMS.Core.csproj"
RUN dotnet clean "EmpiriaBMS.Front/EmpiriaBMS.Front.csproj"

## Restore Projects
RUN dotnet restore "Logging/Logging.csproj"
RUN dotnet restore "EmpiriaBMS.Models/EmpiriaBMS.Models.csproj"
RUN dotnet restore "EmpiriaBMS.Core/EmpiriaBMS.Core.csproj"
RUN dotnet restore "EmpiriaBMS.Front/EmpiriaBMS.Front.csproj"

RUN pwd
RUN ls

# Copy the entire solution
COPY . .

# Build all projects
WORKDIR "/src/Logging"
RUN dotnet build "Logging.csproj" -c Release -o /app/build

WORKDIR "/src/EmpiriaBMS.Models"
RUN dotnet build "EmpiriaBMS.Models.csproj" -c Release -o /app/build

WORKDIR "/src/EmpiriaBMS.Core"
RUN dotnet build "EmpiriaBMS.Core.csproj" -c Release -o /app/build

WORKDIR "/src/EmpiriaBMS.Front"
RUN dotnet build "EmpiriaBMS.Front.csproj" -c Release -o /app/build

# Define the publish image
FROM build AS publish
WORKDIR /src/EmpiriaBMS.Front
RUN dotnet publish "EmpiriaBMS.Front.csproj" -c Release -o /app/publish

# Define the final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmpiriaBMS.Front.dll"]
