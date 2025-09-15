dotnet tool run dotnet-ef migrations add Initial --project db.csproj
dotnet tool run dotnet-ef migrations script
dotnet tool run dotnet-ef migrations remove
dotnet new tool-manifest
dotnet tool install --local dotnet-ef