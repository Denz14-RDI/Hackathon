# Use .NET SDK 10 image for compiling
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build-env
WORKDIR /App

# Copy csproj and restore NuGet dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy source and publish release build
COPY . ./
RUN dotnet publish -c Release -o out

# Build final runtime container
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /App
COPY --from=build-env /App/out .

# Expose port and start MVC application
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "DenzelDev.dll"]
