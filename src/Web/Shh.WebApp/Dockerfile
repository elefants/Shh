FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 53739
EXPOSE 44371

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["src/Web/Shh.WebApp/Shh.WebApp.csproj", "src/Web/Shh.WebApp/"]
RUN dotnet restore "src/Web/Shh.WebApp/Shh.WebApp.csproj"
COPY . .
WORKDIR "/src/src/Web/Shh.WebApp"
RUN dotnet build "Shh.WebApp.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Shh.WebApp.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Shh.WebApp.dll"]