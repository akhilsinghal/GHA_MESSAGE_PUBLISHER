FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Ebay.Message.Publisher/Ebay.Message.Publisher.csproj", "Ebay.Message.Publisher/"]
RUN dotnet restore "Ebay.Message.Publisher/Ebay.Message.Publisher.csproj"
COPY . .
WORKDIR "/src/Ebay.Message.Publisher"
RUN dotnet build "Ebay.Message.Publisher.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Ebay.Message.Publisher.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Ebay.Message.Publisher.dll"]