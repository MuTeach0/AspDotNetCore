# M02.BuildingRESTFullApi

This project demonstrates a complete RESTful API implementation using ASP.NET Core controllers with proper architecture and best practices.

## Project Features

- Full CRUD operations for products
- Product reviews management
- Data persistence using CSV files
- Request/Response DTOs
- Pagination support
- Clean architecture with repository pattern

## Key Components

### Models
- Product: Core product entity
- ProductReview: Product review entity

### Data Layer
- ProductRepository: Handles data persistence using CSV files
- CSV-based storage implementation

### Controllers
- ProductController: RESTful endpoints for product management
- Complete CRUD operations
- Proper HTTP status codes
- Error handling

### DTOs
- Request DTOs: CreateProductRequest, UpdateProductRequest
- Response DTOs: ProductResponse, ProductReviewResponse
- PageResult: Pagination wrapper

## API Endpoints

- GET /api/products - Get all products (with pagination)
- GET /api/products/{id} - Get a specific product
- POST /api/products - Create a new product
- PUT /api/products/{id} - Update a product
- DELETE /api/products/{id} - Delete a product
- POST /api/products/{id}/reviews - Add a review to a product
- GET /api/products/{id}/reviews - Get product reviews

## How to Run

1. Open the solution in Visual Studio
2. Set M02.BuildingRESTFullApi as the startup project
3. Press F5 or click Run to start the application
4. Use the provided request.http file to test the API

## Learning Outcomes

- RESTful API design principles
- Repository pattern implementation
- DTO pattern usage
- Proper error handling
- Pagination implementation
- Related entity management