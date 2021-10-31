FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["SchoolProject/SchoolProject.API.csproj", "SchoolProject/"]
COPY ["SchoolProject.Infrastructure/SchoolProject.Infrastructure.csproj", "SchoolProject.Infrastructure/"]
COPY ["SchoolProject.Domain/SchoolProject.Domain.csproj", "SchoolProject.Domain/"]
COPY ["SchoolProject.Common/SchoolProject.Common.csproj", "SchoolProject.Common/"]
RUN dotnet restore "SchoolProject/SchoolProject.API.csproj"
COPY . .
WORKDIR "/src/SchoolProject"
RUN dotnet build "SchoolProject.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SchoolProject.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SchoolProject.API.dll"]
