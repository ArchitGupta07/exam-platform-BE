FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

COPY . .
RUN dotnet restore ExamPlatformBE.sln

RUN dotnet publish ExamPlatformBE.sln -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .

EXPOSE 8080
EXPOSE 8081

ENTRYPOINT ["dotnet", "ExamPlatformBE.dll"]
