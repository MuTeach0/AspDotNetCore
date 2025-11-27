# M02.BuildingRESTFullApi Assignment

## Objective
Create a complete Blog API with proper REST architecture and related entities.

## Requirements

### 1. Models Implementation
Create the following models:
- BlogPost
  - Id
  - Title
  - Content
  - Author
  - PublishDate
  - Tags (List<string>)
- Comment
  - Id
  - BlogPostId
  - Content
  - Author
  - CommentDate

### 2. Repository Layer
- Implement IBlogRepository interface
- Create CSV-based repository implementation
- Handle proper data persistence
- Implement efficient querying

### 3. DTOs
Create the following DTOs:
- Request DTOs
  - CreateBlogPostRequest
  - UpdateBlogPostRequest
  - CreateCommentRequest
- Response DTOs
  - BlogPostResponse
  - CommentResponse
  - PageResult<T>

### 4. Controller Implementation
Implement BlogController with:
- GET /api/posts (with pagination)
- GET /api/posts/{id}
- POST /api/posts
- PUT /api/posts/{id}
- DELETE /api/posts/{id}
- GET /api/posts/{id}/comments
- POST /api/posts/{id}/comments
- GET /api/posts/bytag/{tag}

### 5. Features
- Implement pagination for blog posts
- Add tag-based filtering
- Implement proper error handling
- Add basic validation
- Implement proper HTTP status codes

### 6. Testing
- Create comprehensive request.http file
- Test all endpoints
- Include error scenarios
- Test pagination
- Test filtering

## Evaluation Criteria
1. REST architecture implementation
2. Code organization
3. Error handling
4. DTO usage
5. Repository pattern implementation
6. Testing coverage

## Submission
- Complete source code
- README.md with setup and testing instructions
- request.http file with all test cases
- Brief documentation of your design decisions