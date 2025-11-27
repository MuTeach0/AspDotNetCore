# Assignment: Header-based Versioning (Controller-based)

## Objective
Implement a header-versioned API for a Movie Management System.

## Requirements

### 1. Create API Endpoints

#### Version 1 (Header: X-Version: 1.0)
Implement basic movie management endpoints:
- GET `/api/movies` - List all movies (basic info)
- GET `/api/movies/{id}` - Get movie by ID
- POST `/api/movies` - Add new movie
- PUT `/api/movies/{id}` - Update movie
- DELETE `/api/movies/{id}` - Delete movie

#### Version 2 (Header: X-Version: 2.0)
Enhance the API with additional features:
- GET `/api/movies` - List all movies (with ratings, cast, reviews)
- GET `/api/movies/{id}` - Get movie with full details
- GET `/api/movies/search` - Search movies with filters
- GET `/api/movies/{id}/reviews` - Get movie reviews
- POST `/api/movies/{id}/reviews` - Add movie review
- GET `/api/movies/recommendations` - Get personalized recommendations

### 2. Implementation Requirements

1. Configure custom version headers
2. Implement version fallback mechanism
3. Support multiple header names
4. Add version deprecation warnings
5. Implement proper error responses with versioning

### 3. Additional Features

1. Support for accept-version header
2. Version-specific response formatting
3. Custom media type versioning
4. Version negotiation rules
5. API documentation per version

### 4. Testing Requirements

1. Create comprehensive request.http tests
2. Test with different header combinations
3. Test version fallback scenarios
4. Test error conditions
5. Document expected responses

### 5. Questions to Answer

1. How does header versioning affect API caching?
2. What are the benefits of header versioning over URL-based approaches?
3. How would you handle version negotiation in a microservices architecture?
4. What strategies would you use for version deprecation notices?
5. How would you document header versioning in API documentation?

## Submission

1. Complete implementation with both versions
2. Documentation of all endpoints
3. Test cases in request.http
4. Written answers to questions
5. Explanation of header versioning strategy