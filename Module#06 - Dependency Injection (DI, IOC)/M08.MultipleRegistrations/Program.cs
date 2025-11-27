using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddTransient<IDependency, DependencyV1>();
// builder.Services.AddTransient<IDependency, DependencyV2>();
// builder.Services.AddTransient<IDependency, DependencyV1>();

builder.Services.TryAddTransient<IDependency, DependencyV1>();
builder.Services.AddTransient<IDependency, DependencyV2>();
builder.Services.TryAddTransient<IDependency, DependencyV1>();

var app = builder.Build();

app.MapGet("/single", (IDependency dependency) =>
{
	var response = dependency.DoSomething();
	return Results.Ok(response);
});

app.MapGet("/multiple", (IEnumerable<IDependency> dependencies) =>
{
	var response = "";
	foreach (var dependency in dependencies)
	{
		response += dependency.DoSomething();
	}
	return Results.Ok(response);
});

app.MapGet("/idependency-registration", (IServiceProvider sp) =>
{
	var servicesRegistration = sp.GetServices<IDependency>();

	return Results.Ok(servicesRegistration.Count());
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
	public string DoSomething() => " Something done using V2 !!";
}