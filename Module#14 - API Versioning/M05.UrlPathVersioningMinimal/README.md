# URL Path-based Versioning (Minimal APIs)

This project demonstrates URL path-based API versioning in ASP.NET Core using the minimal API approach.

## Overview

URL path-based versioning embeds the version number directly in the URL path:
- V1: `/v1/products`
- V2: `/v2/products`

## Features

- Version specified directly in URL path
- Minimal API implementation
- Clean and concise endpoint definitions
- Easy to understand and maintain
- Built-in swagger support

## Implementation Details

- Uses `Microsoft.AspNetCore.Mvc.Versioning`
- Separate endpoint groups for each version
- Version-specific response models
- Configured using minimal API conventions

## API Endpoints

### V1
- GET `/v1/products` - List all products (basic information)
- GET `/v1/products/{id}` - Get product by ID (basic information)

### V2
- GET `/v2/products` - List all products (includes reviews)
- GET `/v2/products/{id}` - Get product by ID (includes reviews)

## Testing

Use the `request.http` file to test different versions of the API endpoints.