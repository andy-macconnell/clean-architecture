# What

# Getting started

Lets start from scratch and build as we go (full source code link here in my repo?)

1. Create a new solution

    `dotnet new sln clean-architecture`

2. Create Domain project

    `dotnet new classlib -n Domain`
    
3. Create application layer

    `dotnet new classlib -n Application`

4. link to domain

    `dotnet add reference ..\Domain\Domain.csproj`

5. Create REST API presentation layer

    `dotnet new webapi -n Rest.Api`

6. link to application layer
    `dotnet add reference ..\Application\Rest.Api.csproj`

*Note: to reduce some complexity, HTTPS redirect and authorisation were removed from the template created above*

7. and run!
    `dotnet run`

Out the box (minus note above) upon run, what we should get in the output of our console is the host logs stating what port the application is listening on. Grab the URL (in my case this is http://localhost:5295/) and append /swagger to the end (At time of writing, Swashbuckle comes pre-referenced as part of the webapi template used during dotnet new)