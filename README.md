# SilverTest
Question:
  * Build a .NET WebApi application using Visual Studio or Visual Studio Code.

It will act as an API server providing a set of CRUD endpoints as well as an aggregation one. Use https://jsonplaceholder.typicode.com/ as a datasource and more specifically the following 3 resources.

/posts
/users
/albums

All endpoints must be behind an /api/ prefix.

The CRUD routes are only applicable to the posts resource while the aggregated one, which should be called /collection, is a simple GET method.

Every endpoint must be protected by an Auth layer and only reply 200 when the 'Authorization' header is present in every request. The value of the header should be a token of 'Bearer af24353tdsfw' and if it's missing or invalid the server response must be a 501.  The /collection route is aggregating all 3 resources returning a collection of only 30 items each of which should contain random items from each resource, finally looking something like this [{"post": {...},"album": {...}"user": {...}},...] 

We do not care about the extra items remaining from each resource.

You will have 24h to complete this test. If you finish earlier, make sure you test your code and go for the bonus points. Submit your test by sending us your github repo where you uploaded your code to.  

Some tips:·
Use WebApi frameworkand C# .NET.
Provide instructions on how to install and test The easier it is to test the more we will like it. ·
Focus on future proofing your code
You get bonus points for:·
Providing good documentation·
Having a solid code structure 


===============================================================================

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
