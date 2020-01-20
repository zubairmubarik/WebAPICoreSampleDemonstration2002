# WebAPICoreSampleDemonstration2002
REST Services to perform HTTPVerb operations for JSONPlaceHolder "https://jsonplaceholder.typicode.com"
Demonstrated HTTPClient vs HTTPClientFactory
# Dependency injection
DI is used for achieving Inversion of Control (IoC) between classes and their dependencies
DI is used in 3 ways in Startup.ConfigureServices
  services.AddScoped<IMyDependency, MyDependency>();
  services.AddTransient<IAsyncService<User>, ClientService>();  
  services.AddSingleton<IOperationSingleton, Operation>();
