FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /APP

COPY LearnFrame.sln ./LearnFrame.sln
COPY LF.Data/LF.Data.csproj ./LF.Data/LF.Data.csproj
COPY LF.Data.Tests/LF.Data.Tests.csproj ./LF.Data.Tests/LF.Data.Tests.csproj
RUN dotnet restore

COPY . ./
RUN dotnet test -v n