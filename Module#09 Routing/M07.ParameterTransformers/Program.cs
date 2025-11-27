using M07.ParameterTransformers.Transformers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options =>
    options.ConstraintMap["slugify"] = typeof(SlugifyTransformer)
);

var app = builder.Build();


// Clean Code A Handbook of Agile Software Craftsmanship
// Robert C. Martin
// clean-code-a-handbook-of-agile-software-craftsmanship
app.MapGet("/book/{title:slugify}", (string title) => Results.Ok
(new { title = $"{title}" })).WithName("BookByTitle");

app.MapGet("/GENERATE", (LinkGenerator link, HttpContext context) =>
{
    var url = link.GetPathByName("BookByTitle",
        new { title = "Clean Code A Handbook of Agile Software Craftsmanship" });
    return Results.Ok(new { generatedUrl = url });
});

// SlugifyTransformer
// https://learn.microsoft.com/en-us/aspnet/core/fundamentals/routing

app.Run();
