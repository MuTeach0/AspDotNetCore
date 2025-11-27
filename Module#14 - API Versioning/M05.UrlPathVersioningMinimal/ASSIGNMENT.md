# Assignment: URL Path-based Versioning (Minimal APIs)

## Objective
Implement a URL path-based versioned API for a Task Management System using Minimal APIs.

## Requirements

### 1. Create API Endpoints

#### Version 1 (V1)
Implement basic task management endpoints:
- GET `/v1/tasks` - List all tasks (basic info)
- GET `/v1/tasks/{id}` - Get task by ID
- POST `/v1/tasks` - Create new task
- PUT `/v1/tasks/{id}` - Update task
- DELETE `/v1/tasks/{id}` - Delete task

#### Version 2 (V2)
Enhance the API with additional features:
- GET `/v2/tasks` - List tasks with subtasks and comments
- GET `/v2/tasks/{id}` - Get task with full details
- POST `/v2/tasks` - Create task with subtasks
- GET `/v2/tasks/{id}/subtasks` - Get task subtasks
- POST `/v2/tasks/{id}/comments` - Add task comment
- GET `/v2/tasks/search` - Search tasks with filters

### 2. Implementation Requirements

1. Use minimal API syntax and patterns
2. Implement versioned endpoint groups
3. Use proper route grouping
4. Implement CRUD operations
5. Use appropriate response types

### 3. Additional Features

1. Implement proper error handling
2. Add request validation
3. Implement filtering and sorting
4. Add pagination support
5. Implement proper logging

### 4. Testing Requirements

1. Create request.http test cases
2. Test all CRUD operations
3. Test error scenarios
4. Test filtering and pagination
5. Document expected responses

### 5. Questions to Answer

1. How does minimal API syntax affect versioning implementation?
2. What are the benefits of using minimal APIs for versioned endpoints?
3. How would you handle cross-cutting concerns in minimal APIs?
4. What strategies would you use for organizing versioned endpoints?
5. How would you document minimal API endpoints effectively?

## Submission

1. Complete implementation with both versions
2. Documentation of all endpoints
3. Test cases in request.http
4. Written answers to questions
5. Explanation of minimal API versioning approach