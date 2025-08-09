FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY BackEnd/*.csproj ./BackEnd/
RUN dotnet restore BackEnd/BackEnd.csproj

COPY . .
WORKDIR /src/BackEnd
RUN dotnet publish BackEndProyectoFinalIso610.sln -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://0.0.0.0:5000
EXPOSE 5000

ENTRYPOINT ["dotnet", "BackEnd.dll"]
