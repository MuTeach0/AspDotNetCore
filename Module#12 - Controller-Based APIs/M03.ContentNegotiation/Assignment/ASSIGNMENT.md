# M03.ContentNegotiation Assignment

## Objective
Create a Recipe API with multiple output format support through content negotiation.

## Requirements

### 1. Models
Create a Recipe model with:
- Id
- Name
- Description
- Ingredients (List<string>)
- Instructions (List<string>)
- PrepTime
- CookTime
- Servings
- Category
- Tags

### 2. Custom Formatters
Implement the following custom formatters:
- RecipeCardFormatter (text/recipe-card)
  - Formatted like a traditional recipe card
  - Ingredients in a bullet list
  - Numbered instructions
- RecipeMarkdownFormatter (text/markdown)
  - Output recipe in Markdown format
  - Proper markdown formatting for lists
  - Headers for sections

### 3. Controller Implementation
Create RecipeController with:
- GET /api/recipes (with content negotiation)
- GET /api/recipes/{id}
- POST /api/recipes
- GET /api/recipes/category/{category}
- GET /api/recipes/search?tag={tag}

### 4. Content Types
Support the following formats:
- application/json (default)
- application/xml
- text/recipe-card (custom)
- text/markdown (custom)
- text/plain (basic formatted text)

### 5. Features
- Implement format-specific validation
- Add format-specific metadata
- Implement proper error responses in all formats
- Add format documentation

### 6. Testing
- Create request.http file with format tests
- Test all supported content types
- Include error scenario tests
- Test search and filtering with different formats

## Evaluation Criteria
1. Custom formatter implementation
2. Content negotiation setup
3. Format-specific handling
4. Error handling across formats
5. Code organization
6. Testing coverage

## Submission
- Complete source code
- README.md with format documentation
- request.http with format-specific tests
- Sample output examples in each format