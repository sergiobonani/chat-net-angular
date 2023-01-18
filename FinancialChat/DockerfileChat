#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Financial.Chat.API/Financial.Chat.API.csproj", "Financial.Chat.API/"]
COPY ["Financial.Chat.Application/Financial.Chat.Application.csproj", "Financial.Chat.Application/"]
COPY ["Financial.Chat.Domain/Financial.Chat.Domain.csproj", "Financial.Chat.Domain/"]
COPY ["Financial.Chat.Infra.IoC/Financial.Chat.Infra.IoC.csproj", "Financial.Chat.Infra.IoC/"]
COPY ["Financial.Chat.Infra/Financial.Chat.Infra.csproj", "Financial.Chat.Infra/"]
COPY ["Financial.Core/Financial.Core.csproj", "Financial.Core/"]
RUN dotnet restore "Financial.Chat.API/Financial.Chat.API.csproj"
COPY . .
WORKDIR "/src/Financial.Chat.API"
RUN dotnet build "Financial.Chat.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Financial.Chat.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Financial.Chat.API.dll"]