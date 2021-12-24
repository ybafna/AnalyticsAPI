# AnalyticsAPI

Install dependencies

dotnet build

If build is successful, run the following commands to initialize the database:

<li>dotnet ef migrations add InitialCreate</li>
<li>dotnet ef database update</li>


dotnet run

The server should be up and running.
Api documentation can be found at: https://www.localhost.com:5001/swagger/index.html


