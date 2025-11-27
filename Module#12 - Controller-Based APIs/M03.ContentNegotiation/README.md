# M03.ContentNegotiation

This project demonstrates advanced API features focusing on content negotiation and custom formatters in ASP.NET Core.

## Project Features

- Content negotiation implementation
- Custom plain text formatter
- Support for multiple output formats
- Advanced response formatting
- HTTP content type handling

## Key Components

### Formatters
- PlainTextTableOutputFormatter: Custom formatter for table-like text output
- Built-in formatters (JSON, XML)

### Controllers
- ProductController with content negotiation support
- Format-specific response handling

### Models and DTOs
- Product and ProductReview models
- Response DTOs with format-specific configurations

## Content Types Supported

- application/json (default)
- application/xml
- text/plain (custom table format)

## How to Run

1. Open the solution in Visual Studio
2. Set M03.ContentNegotiation as the startup project
3. Press F5 or click Run to start the application
4. Use the provided request.http file to test different content types

## Testing Content Negotiation

- Use Accept header to request different formats
- Test the custom plain text formatter
- Verify format-specific responses

## Learning Outcomes

- Content negotiation implementation
- Custom formatter creation
- Media type handling
- Response format configuration
- Advanced HTTP header usage