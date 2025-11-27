using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddKeyedTransient<IDependency, DependencyV1>("V1");
builder.Services.AddKeyedTransient<IDependency, DependencyV2>("V2");

var app = builder.Build();

app.MapGet("/V1", ([FromKeyedServices("V1")] IDependency dependency) =>
{
    var response = dependency.DoSomething();
    return Results.Ok(response);
});


app.MapGet("/V2", ([FromKeyedServices("V2")] IDependency dependency) =>
{
    var response = dependency.DoSomething();
    return Results.Ok(response);
});

app.Run();


public interface IDependency
{
    string DoSomething();
}

public class DependencyV1 : IDependency
{
    public string DoSomething() => "Something done using V1 !!";
}
public class DependencyV2 : IDependency
{
    public string DoSomething() => "Something done using V2 !!";
}