M07.ParameterTransformers

Purpose
- Demonstrates routing parameter transformation by registering an outbound parameter transformer (`SlugifyTransformer`).
- Shows how to generate route URLs using `LinkGenerator` and named routes.

Key files
- `Program.cs` - registers the transformer in `options.ConstraintMap["slugify"]` and maps a book route.
- `Transformers/SlugifyTransformer.cs` - implements `IOutboundParameterTransformer` to produce slug strings.

How to run
1. Open a terminal in `M07.ParameterTransformers`.
2. Run:
   dotnet run
3. Test endpoints:
- GET /book/{title} where the URL part is already slugified by the transformer for outbound generation.
- GET /GENERATE to see an example generated URL for a long book title.

Testing
- Visit `/GENERATE` to get the generated route that uses the transformer.

Notes
- The `SlugifyTransformer` example demonstrates cleaning a title and creating URL-friendly slugs.
