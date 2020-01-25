# WebAPICoreSampleDemonstration2002
REST Services to perform HTTPVerb operations for JSONPlaceHolder "https://jsonplaceholder.typicode.com"
Demonstrated HTTPClient vs HTTPClientFactory
# Dependency injection
DI is used for achieving Inversion of Control (IoC) between classes and their dependencies
DI is used in 3 ways in Startup.ConfigureServices
  services.AddScoped<IMyDependency, MyDependency>();
  services.AddTransient<IAsyncService<User>, ClientService>();  
  services.AddSingleton<IOperationSingleton, Operation>();
# Logger
  ILoggerFactory Serilog for Microsoft.Extensions.Logging

# Async programing


# IHTTPClientFactory vs ClientService
Idea to use HttpClientFactory was to make use of the functionality available for Retry and Fault Handling.

# Aspnet-Core-Middleware
https://www.tutorialsteacher.com/core/aspnet-core-middleware

# Cookie Based Web API Authentication.
