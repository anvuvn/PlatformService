#Docker for .Net
# Use the latest image from Microsoft
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

COPY *.csproj ./
COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "PlatformService.dll"]
