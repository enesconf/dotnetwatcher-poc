FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app
COPY ./YourWatcherApp /app
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /app
COPY --from=build-env /app/out .
VOLUME ["/proj"]
ENTRYPOINT ["dotnet", "YourWatcherApp.dll"]

