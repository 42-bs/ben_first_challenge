FROM mcr.microsoft.com/dotnet/sdk:6.0

WORKDIR /api1

EXPOSE 5287

COPY *.csproj .

RUN dotnet restore && dotnet dev-certs https --trust

COPY . .

CMD [ "dotnet", "run" ]
