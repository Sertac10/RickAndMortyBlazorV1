
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src


COPY Domain/Domain.csproj Domain/
COPY Application/Application.csproj Application/
COPY RickAndMortyBlazorV1/RickAndMortyBlazorV1.csproj RickAndMortyBlazorV1/
RUN dotnet restore RickAndMortyBlazorV1/RickAndMortyBlazorV1.csproj

COPY . ./


RUN dotnet publish RickAndMortyBlazorV1/RickAndMortyBlazorV1.csproj -c Release -o /app/publish


FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=build /app/publish/wwwroot .

EXPOSE 80


CMD ["nginx", "-g", "daemon off;"]