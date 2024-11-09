## Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
## For more information, please see https://aka.ms/containercompat
#
#FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8-windowsservercore-ltsc2019
#ARG source
#WORKDIR /inetpub/wwwroot
#COPY ${source:-obj/Docker/publish} .
#
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HealthCare/HealthCare.csproj", "HealthCare/"]
RUN dotnet restore "HealthCare/HealthCare.csproj"
COPY . .
WORKDIR "/src/HealthCare"
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "HealthCare.dll"]
