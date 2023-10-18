Lets start from scratch and build as we go (full source code link here in my repo?)
Create a new solution
Create Domain project (dotnet command for new proj)
dotnet new classlib -n Domain
Create application layer
dotnet new classlib -n Application
link to domain
dotnet add reference ..\Domain\Domain.csproj
Create REST API layer
dotnet new webapi -n Rest.Api
link to application layer
Note: to reduce some complexity, HTTPS redirect and authorisation were removed from the template created above
dotnet add reference ..\Application\Application.csproj
and run!
dotnet run
Out the box (minus note above) upon run, what we should get in the output of our console is the host logs stating what port the application is listening on. Grab the URL (in my case this is http://localhost:5295/) and append /swagger to the end (At time of writing, Swashbuckle comes pre-referenced as part of the webapi template used during dotnet new)
You should now see in your browser of choice:

*< insert image of swagger landing page here >*

Figure 1 WebApi template running