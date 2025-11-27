M01.RoutingBasics

Purpose
- Demonstrates basic routing in minimal APIs + MVC controllers.
- Shows controller routing using [Route] and attribute routes, and minimal endpoints via `Program.cs`.

Key files
- `Program.cs` - registers endpoints and maps controllers.
- `Controllers/ProductsController.cs` - controller with `[Route("[controller]")]` and an `all` action.

How to run
1. Open a terminal in the project folder `M01.RoutingBasics`.
2. Run:
   dotnet run
3. By default the app will host on the configured URL (see `launchSettings.json` when running from IDE).

Useful endpoints
- GET /products/all  -> returns product list from the `ProductsController`.
- GET /products      -> if present as mapped in `Program.cs` (minimal endpoint example).
- GET /rout-table    -> lists registered endpoints.

Testing quickly
- Use the included `request.http` or run:
  curl http://localhost:5000/products/all

Notes
- This project mixes minimal API endpoints and an MVC controller to illustrate differences.
