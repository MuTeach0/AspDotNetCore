# M01.BasicSetup Assignment

## Objective
Create a basic Weather Forecast API using ASP.NET Core controllers.

## Requirements

### 1. Project Setup
- Create a new ASP.NET Core Web API project
- Set up a WeatherForecastController
- Configure proper routing

### 2. Model Implementation
Create a WeatherForecast model with:
- Date
- Temperature (Celsius)
- Summary (Clear, Rainy, etc.)
- Humidity Percentage
- Wind Speed

### 3. Controller Implementation
Implement the following endpoints:
- GET /api/weatherforecast - Get all forecasts
- GET /api/weatherforecast/today - Get today's forecast
- GET /api/weatherforecast/{date} - Get forecast for a specific date

### 4. Data Generation
- Create a method to generate random weather data
- Ensure data is somewhat realistic
- Generate forecasts for the next 5 days

### 5. Testing
- Create a request.http file
- Include test cases for all endpoints
- Add comments explaining each test case

## Evaluation Criteria
1. Proper controller implementation
2. Correct HTTP method usage
3. Proper routing setup
4. Code organization
5. Testing file completeness

## Submission
- Complete source code
- README.md with setup instructions
- request.http file with test cases
- Brief explanation of your implementation choices