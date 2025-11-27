# API Versioning in ASP.NET Core

This module demonstrates different approaches to implement API versioning in ASP.NET Core applications, using both controller-based and minimal API architectures.

## Projects Overview

### Controller-based API Versioning
1. **M01.UrlPathVersioningController**: Demonstrates URL path-based versioning (e.g., `/api/v1/products`, `/api/v2/products`)
2. **M02.UrlQueryStringVersioningController**: Shows query string-based versioning (e.g., `/api/products?api-version=1.0`)
3. **M03.HeaderVersioningController**: Implements versioning using custom headers
4. **M04.MediaTypeVersioningController**: Uses content negotiation and media types for versioning

### Minimal API Versioning
5. **M05.UrlPathVersioningMinimal**: Minimal API implementation of URL path-based versioning
6. **M06.UrlQueryStringVersioninginimal**: Minimal API with query string versioning
7. **M07.HeaderVersioningMinimal**: Minimal API using header-based versioning
8. **M08.MediaVersioningMinimal**: Minimal API with media type versioning

## Key Concepts

- API versioning strategies
- Version selection and default version configuration
- API deprecation and sunset policies
- Version negotiation
- Response format versioning
- Controller vs Minimal API approaches

## Getting Started

Each project can be run independently and includes:
- Complete implementation of the versioning strategy
- Sample API endpoints
- Request examples in `request.http` files
- Documentation in project-specific README.md files

## Prerequisites

- .NET 7.0 or later
- Visual Studio 2022 or VS Code
- REST Client extension (for testing with `.http` files)