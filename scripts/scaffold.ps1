mkdir ..\src
Set-Location ..\src

dotnet new classlib -n Domain -o .\Domain

dotnet new classlib -n Application -o .\Application
dotnet add .\Application reference .\Domain
dotnet add .\Application package MediatR
dotnet add .\Application package Microsoft.Extensions.DependencyInjection.Abstractions

dotnet new classlib -n Infrastructure -o .\Infrastructure
dotnet add .\Infrastructure reference .\Application
dotnet add .\Application package Microsoft.Extensions.DependencyInjection.Abstractions

dotnet new classlib -n Persistence -o .\Persistence
dotnet add .\Persistence reference .\Application
dotnet add .\Application package Microsoft.Extensions.DependencyInjection.Abstractions

dotnet new webapi -n Api -o .\Api
dotnet add .\Api reference .\Application
dotnet add .\Api reference .\Infrastructure
dotnet add .\Api reference .\Domain

dotnet new sln -n clean-architecture -o .
dotnet sln . add .\Api
dotnet sln . add .\Application
dotnet sln . add .\Domain
dotnet sln . add .\Infrastructure
dotnet sln . add .\Persistence

Set-Location ..\scripts