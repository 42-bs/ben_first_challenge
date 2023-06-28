FROM mcr.microsoft.com/dotnet/sdk:6.0

WORKDIR /appcsharp

COPY *.csproj .

ENV PATH="$PATH:/root/.dotnet/tools"

RUN dotnet restore && dotnet tool install --global dotnet-ef

COPY . .

# RUN dotnet ef database update

# CMD [ "dotnet", "run" ]