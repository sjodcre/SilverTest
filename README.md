# SilverTest
Utilized :
* .Net Core 2.2.402
* Visual Studio Code
* Postman
* DB Browser for SQLite

<br />
Installation :

* As it is not something new that .Net breaks easily with different versions, to ensure that the project can be replicated, make sure to use the same versions mentioned here.
* [.Net Core 2.2 SDK (I used the installer for Windows)](https://dotnet.microsoft.com/download/dotnet-core/2.2)
* Insde Visual Code, the extensions used:
  * C#
  * C# Extension
  * NuGet Package Manager
* Self-Removal Code:
  * https URL from "applicationUrl"
  * Commented app.UseHsts() from Startup.cs
* Settings for Postman:
  * File -> Settings -> Disable SSL certificate verification
  * Run as Admin



<br />
Implementations :

* Due to the data source being used will not be able to reflect the CRUD operations made, I have decided to store the /posts into a DB file to demonstrate the operations. However, only the /posts are being stored into the db. If needed, replication can be easily done too.
* Auth layer is done using ActionFilter, as the conditions are easy. By right, the Authorization filter should be used, as it is the first in the pipeline. However, it is more concerned with policies, and since the authorize condition is quite easy, an action filter would suffice.

<br />
Caveats :

* CRUD is only implemented for /posts. However, if required, they can easily be replicated for other routes.
* DB ID is not reused after deletion, meaning new entires will not reuse the deleted ID. Depending on the scenario, changes might be needed.
* Randomizer for /collections will have repetition. If seek non-repetition, changes might be needed.
<br />
Future Work :

* using Data Transfer Objects (DTOs) to map and control the models' throughput, producing simpler objects.
* implement repository pattern to decouple application from persistence framework, promoting testability.

## Author
* **Samuel John Omamalin**
