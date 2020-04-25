# UserAPIChallenge
This is a project created in ASP.Net C# using MVC and Web API.
What I have implemented is based on Web API only, no Frontend involved. 

# Getting Started
I have provided Postman Collection as a sample on how to run each request. 
Path to User Challenge Api Postman Collection:  {share link here}

Please 'Set as a StartUp Project' on UsersAPI project and run the project on IIS Express

## Path to run each request: 
## 1. Get all users
```diff
+ [GET] {localhost}/api/users
```
- Example: http://localhost:55870/api/users

## 2. Find user(s) by their first name or last 
```diff
+ [GET] {localhost}/api/users/get?firstName={firstName}&lastName={lastName}
```
Example: http://localhost:55870/api/users/get?firstName=Brad&lastName=Gibson

Note: {firstName} and {lastName} does not have to be the exact match (do not need to provide both)

## 3. Create a new user
```diff
+ [POST] {localhost}/api/users 
```
Note: id will be automatically created when a user is created.


## 4. Update a user 
```diff
+ [PUT] {localhost}/api/users/{id}
```
Note: {id} is the id of the user you would like to update (please have the old value in the body as well).

## 5. Delete a user 
```diff
- [DELETE] {localhost}/api/users/{id}
```
Note:  {id} is the id of the user you would like to delete.

# UserAPI code file
Controllers/API/UsersController.cs


