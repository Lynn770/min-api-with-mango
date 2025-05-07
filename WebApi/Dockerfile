FROM mrc.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /build
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /build/out .
ENV ASPNETCORE_URLS=http://localhost:5001

EXPOSE 5001

ENTRYPOINT [ "dotnet","WebApi.dll" ]