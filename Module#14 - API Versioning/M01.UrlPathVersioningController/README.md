# URL Path-based Versioning (Controller-based)

This project demonstrates URL path-based API versioning in ASP.NET Core using the traditional controller-based approach.

## Overview

URL path-based versioning embeds the version number directly in the URL path, making it explicit and easily visible:
- V1: `/api/v1/products`
- V2: `/api/v2/products`

## Features

- Version specified directly in URL path
- Separate controllers for each version
- Clear separation of concerns between versions
- Easy to understand and debug
- Built-in swagger support

## Implementation Details

- Uses `Microsoft.AspNetCore.Mvc.Versioning`
- Separate controller folders for each version (V1, V2)
- Version-specific response models
- Configured in Program.cs using `AddApiVersioning`

## API Endpoints

### V1
- GET `/api/v1/products` - List all products (basic information)
- GET `/api/v1/products/{id}` - Get product by ID (basic information)

### V2
- GET `/api/v2/products` - List all products (includes reviews)
- GET `/api/v2/products/{id}` - Get product by ID (includes reviews)

## Testing

Use the `request.http` file to test different versions of the API endpoints.