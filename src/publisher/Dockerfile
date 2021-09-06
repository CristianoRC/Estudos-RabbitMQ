FROM mcr.microsoft.com/dotnet/sdk:5.0 as Compiler
WORKDIR /build
COPY ./publisher.csproj /build/
RUN dotnet restore
COPY ./ /build/
RUN dotnet publish -c Release -o app 

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=Compiler /build/app /app/
ENTRYPOINT [ "dotnet", "publisher.dll" ]