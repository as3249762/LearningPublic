try
{
    Console.WriteLine("Application is started up 😶‍🌫️");

    var builder = WebApplication.CreateBuilder(args);

    var app = builder.Build();

    var configString = (app.Configuration as IConfigurationRoot).GetDebugView();
    Console.WriteLine(configString);

    app.MapGet("/helloworld", () => "Hello World");
    app.MapGet("/hello/{something}", (string something) => "Hello " + something);
    app.MapGet("/", () => "Hello World");

    app.MapGet("/liveness", () => Results.Ok());
    app.MapGet("/readiness", () => Results.Ok());

    //app.UseHttpsRedirection();
    app.Run();

}
catch (Exception ex)
{
    Console.WriteLine($"The exception was {ex.Message}");
    throw;
}

