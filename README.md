# AnalyticsAPI

Install dotnet 5.0(https://dotnet.microsoft.com/en-us/download/dotnet/5.0)<br>

Clone this repository.<br>
Run "dotnet build" in AnalyticsAPI folder<br>
The build should be successful if dotnet was succesfully installed and added to the PATH variable.

Install the following dependencies:
EntityFramework: dotnet tool install --global dotnet-ef

After successful installation, run the following commands to initialize the database:
<li>dotnet ef migrations add InitialCreate</li>
<li>dotnet ef database update</li>

Use "dotnet run" command to host the application on https://localhost:5001

The server should be up and running.
Api documentation can be found at: https://localhost:5001/swagger/index.html
