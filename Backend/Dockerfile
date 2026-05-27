FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY . .
RUN dotnet build "KairoApi/KairoApi.App.csproj" -c Release

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /src/KairoApi/bin/Release/net10.0 .
EXPOSE 7171
ENTRYPOINT ["dotnet", "KairoApi.App.dll"]
