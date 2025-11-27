# Header-based Versioning (Controller-based)

This project demonstrates API versioning using custom HTTP headers in ASP.NET Core with controller-based architecture.

## Overview

Header-based versioning uses custom HTTP headers to specify the API version:
- V1: `X-Version: 1.0` or `api-version: 1.0`
- V2: `X-Version: 2.0` or `api-version: 2.0`

## Features

- Version specified in HTTP headers
- Clean URLs without version information
- Flexible version header naming
- Multiple header options
- Support for content negotiation

## Implementation Details

- Uses `Microsoft.AspNetCore.Mvc.Versioning`
- Custom header name configuration
- Version specified using [ApiVersion] attribute
- Multiple version header support
- Default version fallback

## API Endpoints

All endpoints use the same URL structure with version specified in headers:

### V1 (Header: X-Version: 1.0)
- GET `/api/products` - List all products (basic information)
- GET `/api/products/{id}` - Get product by ID (basic information)

### V2 (Header: X-Version: 2.0)
- GET `/api/products` - List all products (includes reviews)
- GET `/api/products/{id}` - Get product by ID (includes reviews)

## Testing

Use the `request.http` file to test different versions of the API endpoints.
Make sure to include the proper version header in each request.