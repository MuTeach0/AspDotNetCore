# Media Type Versioning (Controller-based)

This project demonstrates API versioning using media types in ASP.NET Core with controller-based architecture.

## Overview

Media type versioning uses content negotiation through Accept headers:
- V1: `Accept: application/json;v=1.0`
- V2: `Accept: application/json;v=2.0`

## Features

- Version specified in Accept header
- Content negotiation support
- Clean URLs without version information
- Flexible content type versioning
- Standard HTTP content negotiation

## Implementation Details

- Uses `Microsoft.AspNetCore.Mvc.Versioning`
- Custom media type version configuration
- Content negotiation setup
- Version-specific response formatting
- Default version fallback

## API Endpoints

All endpoints use the same URL structure with version specified in Accept header:

### V1 (Accept: application/json;v=1.0)
- GET `/api/products` - List all products (basic information)
- GET `/api/products/{id}` - Get product by ID (basic information)

### V2 (Accept: application/json;v=2.0)
- GET `/api/products` - List all products (includes reviews)
- GET `/api/products/{id}` - Get product by ID (includes reviews)

## Testing

Use the `request.http` file to test different versions of the API endpoints.
Make sure to include the proper Accept header in each request.