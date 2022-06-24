#FROM mcr.microsoft.com/dotnet/sdk:6.0
#COPY . /SmartHomeWebApi
#WORKDIR /SmartHomeWebApi
#RUN ["dotnet", "restore"]
#RUN ["dotnet", "build"]
#RUN dotnet tool install --global dotnet-ef
#RUN ls
#RUN dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 6.0.6
#RUN dotnet add package Swashbuckle.AspNetCore --version 6.2.3
#ENV PATH $PATH:/root/.dotnet/tools
#RUN dotnet ef
#EXPOSE 80/tcp
#RUN chmod +x ./entrypoint.sh
#RUN cd /SmartHomeWebApi
#CMD /bin/bash ./entrypoint.sh

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /SmartHomeWebApi

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /SmartHomeWebApi
COPY --from=build-env /SmartHomeWebApi/out .
ENTRYPOINT ["dotnet", "SmartHomeWebApi.dll"]
#RUN chmod +x ./entrypoint.sh
#CMD /bin/bash ./entrypoint.sh
