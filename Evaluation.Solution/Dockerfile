#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Evaluation.SAL/Evaluation.SAL.csproj", "Evaluation.SAL/"]
COPY ["Evaluation.BAL/Evaluation.BAL.csproj", "Evaluation.BAL/"]
COPY ["Evaluation.CAL/Evaluation.CAL.csproj", "Evaluation.CAL/"]
COPY ["Evaluation.DAL/Evaluation.DAL.csproj", "Evaluation.DAL/"]
RUN dotnet restore "./Evaluation.SAL/Evaluation.SAL.csproj"
COPY . .
WORKDIR "/src/Evaluation.SAL"
RUN dotnet build "./Evaluation.SAL.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Evaluation.SAL.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Evaluation.SAL.dll"]