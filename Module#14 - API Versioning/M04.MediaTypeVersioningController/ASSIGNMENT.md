# Assignment: Media Type Versioning (Controller-based)

## Objective
Implement a media type versioned API for a Blog Content Management System.

## Requirements

### 1. Create API Endpoints

#### Version 1 (Accept: application/json;v=1.0)
Implement basic blog management endpoints:
- GET `/api/posts` - List all blog posts (basic content)
- GET `/api/posts/{id}` - Get post by ID
- GET `/api/categories` - List categories
- POST `/api/posts` - Create new post
- PUT `/api/posts/{id}` - Update post

#### Version 2 (Accept: application/json;v=2.0)
Enhance the API with rich content features:
- GET `/api/posts` - List posts with rich content
- GET `/api/posts/{id}` - Get post with comments
- GET `/api/posts/search` - Advanced search
- GET `/api/posts/{id}/comments` - Get post comments
- POST `/api/posts/{id}/comments` - Add comment
- GET `/api/tags` - Get all tags
- GET `/api/posts/by-tag/{tag}` - Get posts by tag

### 2. Implementation Requirements

1. Configure media type versioning
2. Implement content negotiation
3. Support multiple response formats
4. Add version-specific responses
5. Handle unsupported media types

### 3. Additional Features

1. Support for XML format versioning
2. Custom media type formatters
3. Version-specific serialization
4. Content type mapping
5. Format-specific validation

### 4. Testing Requirements

1. Create request.http test cases
2. Test content negotiation
3. Test format variations
4. Test error scenarios
5. Document expected responses

### 5. Questions to Answer

1. How does media type versioning affect API discoverability?
2. What are the benefits of using media type versioning?
3. How would you handle version negotiation failure?
4. What strategies would you use for supporting multiple formats?
5. How would you document media type versioning in API documentation?

## Submission

1. Complete implementation with both versions
2. Documentation of all endpoints
3. Test cases in request.http
4. Written answers to questions
5. Explanation of media type versioning strategy