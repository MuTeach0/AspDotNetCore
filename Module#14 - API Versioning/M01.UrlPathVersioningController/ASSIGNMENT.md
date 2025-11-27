# Assignment: URL Path-based Versioning (Controller-based)

## Objective
Implement a URL path-based versioned API for a Book Management System.

## Requirements

### 1. Create API Endpoints

#### Version 1 (V1)
Implement basic book management endpoints:
- GET `/api/v1/books` - List all books (basic info: ID, Title, Author)
- GET `/api/v1/books/{id}` - Get book by ID (basic info)
- POST `/api/v1/books` - Add new book
- PUT `/api/v1/books/{id}` - Update book
- DELETE `/api/v1/books/{id}` - Delete book

#### Version 2 (V2)
Enhance the API with additional features:
- GET `/api/v2/books` - List all books (including reviews, ratings, publication date)
- GET `/api/v2/books/{id}` - Get book by ID (including reviews, ratings)
- POST `/api/v2/books` - Add new book with extended information
- PUT `/api/v2/books/{id}` - Update book with extended information
- GET `/api/v2/books/{id}/reviews` - Get book reviews
- POST `/api/v2/books/{id}/reviews` - Add book review

### 2. Implementation Requirements

1. Use separate controllers for each version
2. Implement proper model classes for each version
3. Use a repository pattern for data access
4. Include appropriate DTO classes for responses
5. Implement proper error handling

### 3. Testing

1. Create a complete request.http file with test cases for all endpoints
2. Test version compatibility
3. Test error scenarios
4. Document expected responses

### 4. Questions to Answer

1. How does URL path-based versioning affect API discoverability?
2. What are the benefits and drawbacks of having separate controllers for each version?
3. How would you handle common functionality between versions?
4. How would you implement authentication across different versions?
5. How would you deprecate V1 in favor of V2?

## Submission

1. Complete implementation of both API versions
2. Documentation of endpoints
3. Test cases in request.http
4. Written answers to questions
5. Explanation of your implementation choices