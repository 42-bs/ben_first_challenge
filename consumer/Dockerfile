FROM mcr.microsoft.com/dotnet/sdk:6.0

WORKDIR /appcsharp

COPY *.csproj .
#RUN dotnet restore

COPY . .

CMD [ "dotnet", "run", "--project", "teste_dotnetproject.csproj" ]