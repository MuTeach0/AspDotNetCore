# URL Query String Versioning (Controller-based)

This project demonstrates API versioning using query string parameters in ASP.NET Core with controller-based architecture.

## Overview

Query string versioning adds the version as a query parameter to the URL:
- V1: `/api/products?api-version=1.0`
- V2: `/api/products?api-version=2.0`

## Features

- Version specified as query parameter
- Single URL structure for all versions
- Optional version parameter with defaults
- Version specification doesn't affect route structure
- Easy integration with existing APIs

## Implementation Details

- Uses `Microsoft.AspNetCore.Mvc.Versioning`
- Version specified using [ApiVersion] attribute
- Default version configuration
- Version-specific response models
- Query parameter name configurable

## API Endpoints

All endpoints use the same base URL with different version parameters:

### V1
- GET `/api/products?api-version=1.0` - List all products (basic information)
- GET `/api/products/{id}?api-version=1.0` - Get product by ID (basic information)

### V2
- GET `/api/products?api-version=2.0` - List all products (includes reviews)
- GET `/api/products/{id}?api-version=2.0` - Get product by ID (includes reviews)

## Testing

Use the `request.http` file to test different versions of the API endpoints.
Make sure to include the proper api-version query parameter in each request.