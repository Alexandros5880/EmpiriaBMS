# Define the base image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Define the build image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy and restore all projects
COPY ["EmpiriaBMS.Models/EmpiriaBMS.Models.csproj", "EmpiriaBMS.Models/"]
COPY ["EmpiriaBMS.Core/EmpiriaBMS.Core.csproj", "EmpiriaBMS.Core/"]
COPY ["EmpiriaBMS.Front/EmpiriaBMS.Front.csproj", "EmpiriaBMS.Front/"]

RUN dotnet restore "EmpiriaBMS.Models/EmpiriaBMS.Models.csproj"
RUN dotnet restore "EmpiriaBMS.Core/EmpiriaBMS.Core.csproj"
RUN dotnet restore "EmpiriaBMS.Front/EmpiriaBMS.Front.csproj"



# Copy the entire solution
COPY . .


# Build all projects
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