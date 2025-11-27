# Assignment: URL Query String Versioning (Controller-based)

## Objective
Implement a query string-based versioned API for a Weather Forecast System.

## Requirements

### 1. Create API Endpoints

#### Version 1 (V1)
Implement basic weather forecast endpoints:
- GET `/api/weather?api-version=1.0` - Get current weather (basic info: temperature, conditions)
- GET `/api/weather/forecast?api-version=1.0` - Get 5-day forecast (basic info)
- GET `/api/weather/location/{cityId}?api-version=1.0` - Get weather by city

#### Version 2 (V2)
Enhance the API with additional features:
- GET `/api/weather?api-version=2.0` - Get current weather (detailed: humidity, wind, pressure)
- GET `/api/weather/forecast?api-version=2.0` - Get 7-day detailed forecast
- GET `/api/weather/location/{cityId}?api-version=2.0` - Get detailed weather by city
- GET `/api/weather/alerts?api-version=2.0` - Get weather alerts
- GET `/api/weather/historical/{date}?api-version=2.0` - Get historical weather data

### 2. Implementation Requirements

1. Use query string versioning with proper configuration
2. Implement version fallback mechanism
3. Configure default version
4. Handle invalid version numbers
5. Implement API version deprecation notices

### 3. Additional Features

1. Implement version negotiation
2. Add support for multiple version formats (1.0, 1, 1.0.0)
3. Configure version reader options
4. Add version information in response headers
5. Implement version-specific validation

### 4. Testing

1. Create test cases in request.http
2. Test version fallback scenarios
3. Test invalid version handling
4. Test with and without version parameters
5. Test deprecated version handling

### 5. Questions to Answer

1. How does query string versioning affect URL structure and caching?
2. What are the benefits of using query string versioning over URL path versioning?
3. How would you handle versioning of error responses?
4. What strategies would you use for version deprecation?
5. How would you document different versions in Swagger/OpenAPI?

## Submission

1. Complete implementation with both versions
2. Documentation of all endpoints
3. Test cases in request.http
4. Written answers to questions
5. Explanation of version handling strategy