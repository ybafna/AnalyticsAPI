# AnalyticsAPI

Install dotnet 5.0
Run "dotnet build"
The build should be successful.

Install the following dependencies:
EntityFramework: dotnet tool install --global dotnet-ef

If successful installation, run the following commands to initialize the database:
<li>dotnet ef migrations add InitialCreate</li>
<li>dotnet ef database update</li>

Use "dotnet run" command to host the application on https://localhost:5001

The server should be up and running.
Api documentation can be found at: https://www.localhost.com:5001/swagger/index.html


