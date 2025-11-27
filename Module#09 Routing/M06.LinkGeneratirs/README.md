M06.LinkGeneratirs

Purpose
- Demonstrates use of `LinkGenerator` to create named links (URIs) for HATEOAS-style responses.
- Shows how to register and use named endpoints for link generation.

Key files
- `Program.cs` - maps `GET /order/{id:int}` and `PUT /order/{id:int}`. The PUT endpoint is named `EditOrder`.

How to run
1. Open a terminal in `M06.LinkGeneratirs`.
2. Run:
   dotnet run
3. Call the GET endpoint to receive a response that includes generated links.

Useful endpoints
- GET /order/{id}  -> returns an order representation with self and edit links.
- PUT /order/{id}  -> updates an order (named "EditOrder").

Testing
- Use `curl` or the included `request.http` file. Example:
  curl http://localhost:5000/order/5

Notes
- The project demonstrates how `LinkGenerator.GetUriByName` and `GetPathByName` produce fully qualified or path-only URLs by name.
