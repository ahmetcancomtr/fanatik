FROM mcr.microsoft.com/dotnet/aspnet
WORKDIR /APP
ADD bin/Debug/net5.0 .

ENTRYPOINT ["dotnet","/APP/fanatik.dll","--urls","http://0.0.0.0:5000"]


