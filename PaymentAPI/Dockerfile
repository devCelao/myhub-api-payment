ARG DOTNET_VERSION=9.0
ARG BUILD_CONFIGURATION=Release

######## RUNTIME ########
FROM mcr.microsoft.com/dotnet/aspnet:${DOTNET_VERSION} AS runtime
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

######## BUILD ########
FROM mcr.microsoft.com/dotnet/sdk:${DOTNET_VERSION} AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiar .csproj dos Componentes (repo myhub-api-all-components)
COPY myhub-api-all-components/DomainCore/DomainObjects.csproj                         myhub-api-all-components/DomainCore/


# Copiar .csproj do serviço Payment (repo myhub-api-payment)
COPY myhub-api-payment/PaymentAPI/PaymentAPI.csproj                     myhub-api-payment/PaymentAPI/
COPY myhub-api-payment/PaymentDomain/PaymentDomain.csproj              myhub-api-payment/PaymentDomain/

# Restore
RUN dotnet restore myhub-api-payment/PaymentAPI/PaymentAPI.csproj

# Copiar todo o código-fonte
COPY myhub-api-all-components/ ./myhub-api-all-components/
COPY myhub-api-payment/ ./myhub-api-payment/

# Build
WORKDIR /src/myhub-api-payment/PaymentAPI
RUN dotnet publish -c ${BUILD_CONFIGURATION} -o /app/publish /p:UseAppHost=false

######## FINAL ########
FROM runtime AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "PaymentAPI.dll"]
