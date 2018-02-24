FROM microsoft/dotnet:latest
COPY . /app
WORKDIR /app
EXPOSE 5000/tcp
ENV ASPNETCORE_URLS http://*:5000
ENV ASPNETCORE_ENVIRONMENT development
 
ENTRYPOINT ["dotnet", "run"]