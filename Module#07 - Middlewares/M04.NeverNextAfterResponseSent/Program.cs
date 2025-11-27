var builder = WebApplication.CreateBuilder(args);
// ← DI Container goes here (Configuring Dependency)

var app = builder.Build();

// ← Middleware setup goes here

// Case #1
// app.Use(async (context, next) =>
// {
// 	// must be Write 10 char if you don't
// 	// will be run time Exception -> (Response Content-Length mismatch: too few bytes written (7 of 10).)
// 	context.Response.ContentLength = 10;
// 	context.Response.Headers.Append("X-Hdr1", "val1");
// 	context.Response.StatusCode = StatusCodes.Status206PartialContent;
// 	// Response is stream, before it started we can change any thing
// 	// but if you do change any thing after started has been run time error
// 	await context.Response.WriteAsync("MW #1 \n"); // response has begun
// 	/*
// 		(The response has already started, the error page middleware will not be executed.)
// 		context.Response.StatusCode = StatusCodes.Status206PartialContent;

// 		(Headers are read-only, response has already started.)
// 		context.Response.Headers.Append("X-Hdr1", "val1");
// 	*/
// 	await next();
// });


// app.Use(async (context, next) =>
// {
// 	await context.Response.WriteAsync("ab\n"); // response has begun
// 	await next();
// });


// Case #2
app.Use(async (context, next) =>
{
	await context.Response.WriteAsync("MW #1 \n"); // response has begun
	await next();
});


app.Use(async (context, next) =>
{
	// run time exception StatusCode cannot be set because the response has already started.
	// context.Response.StatusCode = StatusCodes.Status206PartialContent;


	if (!context.Response.HasStarted)
		context.Response.StatusCode = StatusCodes.Status206PartialContent;

	await context.Response.WriteAsync("ab\n");
	await next();
});


app.Run();
