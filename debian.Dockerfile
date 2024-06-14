################################################################################

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine3.19-amd64 AS build-env
WORKDIR /app

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0.3-bookworm-slim-amd64

WORKDIR /app
COPY --from=build-env /app/out .

CMD dotnet dns-test.dll