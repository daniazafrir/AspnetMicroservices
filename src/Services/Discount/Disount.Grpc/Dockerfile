#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Discount/Disount.Grpc/Discount.Grpc.csproj", "Services/Discount/Disount.Grpc/"]
RUN dotnet restore "Services/Discount/Disount.Grpc/Discount.Grpc.csproj"
COPY . .
WORKDIR "/src/Services/Discount/Disount.Grpc"
RUN dotnet build "Discount.Grpc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Discount.Grpc.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Discount.Grpc.dll"]