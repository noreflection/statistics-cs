**Workout statistics application**

Frontend part: Blazor (WebAssembly) server-side hosted model \
Backend part: Asp.Net Core Web Api with Entity Framework Core

To build application need to install ".NET Core 3.0.0-preview8" and provide connection strings in appsettings.json

The application is somewhat slow (especially on a first cold start) since webassembly stuff is still not fully optimised, but it goes fine after initial load.

Running example filled with test data: http://blazor-app.azurewebsites.net/