# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory inside the container
WORKDIR /app

# Copy the .csproj files and restore any dependencies (via dotnet restore)
COPY PerfTest.Api/PerfTest.Api.csproj ./PerfTest.Api/
RUN dotnet restore PerfTest.Api/PerfTest.Api.csproj

# Copy the entire source code into the container
COPY . .

# Expose port 5001 for the API service
EXPOSE 5000

RUN dotnet publish PerfTest.Api/PerfTest.Api.csproj -c Release -o /app/out

# Set the entry point for the API and GRPC services (you may choose which one to start)
ENTRYPOINT ["dotnet", "/app/out/PerfTest.Api.dll"]
