# Module 12 - Controller-Based APIs Assignment

## Objective
Create a complete RESTful API for managing a Library System using the concepts learned in this module.

## Requirements

### 1. Basic API Setup (Based on M01)
- Create a new ASP.NET Core Web API project
- Implement a basic BooksController with preliminary endpoints
- Set up proper routing and HTTP method attributes

### 2. Complete RESTful Implementation (Based on M02)
- Create the following models:
  - Book (Id, Title, Author, ISBN, PublishDate, Genre)
  - BookReview (Id, BookId, Rating, ReviewText, ReviewerName)
  - BorrowRecord (Id, BookId, BorrowerName, BorrowDate, ReturnDate)
- Implement a Repository pattern for data storage
- Create CRUD operations for all entities
- Implement pagination for book listing
- Add filtering capabilities (by genre, author)
- Include proper request/response models

### 3. Advanced Features (Based on M03)
- Implement content negotiation to support:
  - JSON (default)
  - XML
  - Custom plain text format showing books in a table structure
- Add a custom formatter for exporting book records in a library-card format
- Implement proper error handling and status codes

## Evaluation Criteria
1. Proper implementation of REST principles
2. Code organization and clean architecture
3. Proper use of HTTP methods and status codes
4. Implementation of all required features
5. Proper error handling
6. Code documentation and API testing file (request.http)

## Submission
- Complete source code
- README.md with setup instructions
- request.http file with API test cases
- Documentation of your custom formatter implementation