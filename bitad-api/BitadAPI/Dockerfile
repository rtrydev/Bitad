# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./bitad-api/BitadAPI/*.csproj ./

RUN dotnet restore

# Copy everything else and build
COPY ./bitad-api/BitadAPI/ ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
EXPOSE 80
#EXPOSE 443

COPY --from=build-env /app/out .
COPY --from=build-env /app/bitad-email-template bitad-email-template
#COPY ./certificat/bitad_ath_bielsko_pl.pfx /https/aspnetapp.pfx
ENTRYPOINT ["dotnet", "BitadAPI.dll"]


