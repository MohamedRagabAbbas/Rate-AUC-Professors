# API Documentation

This document provides detailed information about the endpoints available in the API.

## Response Messages
 public string Id { get; set; } = string.Empty;
 public string Role { get; set; } = string.Empty;
 public bool IsAuthenticated { get; set; } = false;
 public string Token { get; set; } = string.Empty;
 public string Message { get; set; } = string.Empty;

### Response for Authentication Request  (LogIn & SignUp)

```json
{
 "id": "user Id 'String'",
 "role": "role",
 "isAuthenticated": false,
 "token": "string token",
 "message": "string"
}
```

### Response for Comment Request

```json
{
 "Message": "Response message from the server",
 "Status": true,
 "Data": {
   "Id": "number",
   "Content": "string",
   "Timestamp": "datetime",
   "UserId": "string",
   "Student": "object or null",
   "FeedId": "number",
   "Feed": "object or null",
   "ReviewId": "number",
   "Review": "object or null",
   "Reactions": "array of objects"
 }
}
```
### Response for Course Request
``` json
{
 "Message": "Response message from the server.",
 "Status": true,
 "Data": {
   "Id": "number",
   "Name": "string",
   "Description": "string",
   "Code": "string",
   "Credit_Hours": "number",
   "DepartmentId": "number",
   "Department": "object or null",
   "Documents": "array of objects",
   "Reviews": "array of objects",
   "Professors": "array of objects"
 }
}
```

### Response for Department Request
``` json
{
 "Message": "Response message from the server.",
 "Status": true,
 "Data": {
   "Id": "number",
   "Name": "string",
   "Description": "string",
   "Majors": "array of objects",
   "Professors": "array of objects",
   "Courses": "array of objects"
 }
}
```

### Response for Document Request
``` json
{
 "Message": "Response message from the server.",
 "Status": true,
 "Data": {
   "Id": "number",
   "Document_type": "string",
   "Content": "string",
   "UploadDate": "datetime",
   "DocumentUrl": "string",
   "UserId": "string",
   "Student": "object or null",
   "ProfessorId": "number",
   "Professor": "object or null",
   "CourseId": "number",
   "Course": "object or null"
 }
}
```

### Response for Feed Request
``` json
{
 "Message": "Response message from the server.",
 "Status": true,
 "Data": {
   "Id": "number",
   "Content": "string",
   "Timestamp": "datetime",
   "UserId": "string",
   "Student": "object or null",
   "Comments": "array of objects",
   "Reactions": "array of objects"
 }
}
```

### Response for Major Request
``` json
{
 "Message": "Response message from the server.",
 "Status": true,
 "Data": {
   "Id": "number",
   "Name": "string",
   "Description": "string",
   "DepartmentId": "number",
   "Department": "object or null",
   "Students": "array of objects"
 }
}
```

### Response for Professor Request
``` json
{
 "Message": "Response message from the server.",
 "Status": true,
 "Data": {
   "Id": "number",
   "Name": "string",
   "Email": "string",
   "Bio": "string",
   "DepartmentId": "number",
   "Department": "object or null",
   "Courses": "array of objects",
   "Reviews": "array of objects",
   "Documents": "array of objects"
 }
}
```

### Response for Reaction Request
``` json
{
 "Message": "Response message from the server.",
 "Status": true,
 "Data": {
   "Id": "number",
   "IsLike": "boolean",
   "Timestamp": "datetime",
   "UserId": "string",
   "Student": "object or null",
   "CommentId": "number",
   "Comment": "object or null",
   "ReviewId": "number",
   "Review": "object or null",
   "FeedId": "number",
   "Feed": "object or null",
   "ReplyId": "number",
   "Reply": "object or null"
 }
}
```

### Response for Reply Request
``` json
{
 "Message": "Response message from the server.",
 "Status": true,
 "Data": {
   "Id": "number",
   "Content": "string",
   "Timestamp": "datetime",
   "CommentId": "number",
   "Comment": "object or null",
   "Reactions": "array of objects",
   "UserId": "string",
   "Student": "object or null"
 }
}
```

### Response for Review Request
``` json
{
 "Message": "Response message from the server.",
 "Status": true,
 "Data": {
   "Id": "number",
   "Content": "string",
   "Timestamp": "datetime",
   "Value": "number",
   "Comments": "array of objects",
   "Reactions": "array of objects",
   "UserId": "string",
   "Student": "object or null",
   "ProfessorId": "number",
   "Professor": "object or null",
   "CourseId": "number",
   "Course": "object or null"
 }
}
```

### Response for Student Request
``` json
{
 "Message": "Response message from the server.",
 "Status": true,
 "Data": {
   "Id": "string",
   "FirstName": "string",
   "LastName": "string",
   "Student_Id": "string",
   "Gender": "boolean",
   "Standing": "string",
   "GraduationYear": "string",
   "Color" : "string",
   "Feeds": "array of objects",
   "Majors": "array of objects",
   "Documents": "array of objects",
   "Reactions": "array of objects",
   "Reviews": "array of objects",
   "Replys": "array of objects",
   "Comments": "array of objects"
 }
}
```

# Schemas (data to be sent to the server)

## Comment

- `content`: string, nullable: true
- `timestamp`: string ($date-time)
- `feedId`: integer ($int32)
- `reviewId`: integer ($int32)

## Course

- `name`: string, nullable: true
- `description`: string, nullable: true
- `code`: string, nullable: true
- `credit_Hours`: integer ($int32)
- `departmentId`: integer ($int32)

## Department

- `name`: string, nullable: true
- `description`: string, nullable: true

## Feed

- `content`: string, nullable: true
- `timestamp`: string ($date-time)

## LoginRequest

- `email`: string
- `password`: string

## Professor

- `name`: string, nullable: true
- `email`: string, nullable: true
- `bio`: string, nullable: true
- `departmentId`: integer ($int32)

## Reaction

- `isLike`: boolean
- `timestamp`: string ($date-time)
- `feedId`: integer ($int32)
- `commentId`: integer ($int32)
- `replyId`: integer ($int32)
- `reviewId`: integer ($int32)

## Reply

- `content`: string, nullable: true
- `timestamp`: string ($date-time)
- `commentId`: integer ($int32)

## Review

- `content`: string, nullable: true
- `timestamp`: string ($date-time)
- `value`: integer ($int32), minimum: 1, maximum: 5
- `professorId`: integer ($int32)
- `courseId`: integer ($int32)

## Student

- `firstName`: string, nullable: true
- `lastName`: string, nullable: true
- `email`: string, nullable: true
- `password`: string, nullable: true
- `phoneNumber`: string, nullable: true
- `standing`: string, nullable: true
- `graduationYear`: string, nullable: true
- `student_Id`: string, nullable: true
- `color`: string, nullable: true


## Base URL
The base URL for all API endpoints is: `http://rateaucprofessor-001-site1.ftempurl.com/`

## Example

### Get All Documents
To retrieve all documents:

- **URL:** `/api/Document/get-all`
- **Method:** GET
- **Description:** Retrieves all documents available.
- **Example Request:**
  http ```
	GET http://rateaucprofessor-001-site1.ftempurl.com/api/Document/get-all
```


### Document

<details>
<summary>Get All Document</summary>

## Retrieves all documents.

- **URL:** `/api/Document/get-all`
- **Method:** GET
</details>

<details>
<summary>Get Document by ID</summary>

## Retrieves a specific document by its ID.

- **URL:** `/api/Document/get-by-id/{id}`
- **Method:** GET
- **Parameters:**
  - `id`: ID of the document
</details>

<details>
<summary>Add Document</summary>

## Adds a new document.

- **URL:** `/api/Document/add`
- **Method:** POST
</details>

<details>
<summary>Update Document</summary>

## Updates an existing document.

- **URL:** `/api/Document/update`
- **Method:** PUT
</details>

<details>
<summary>Delete Document</summary>

## Deletes a document by its ID.

- **URL:** `/api/Document/delete/{id}`
- **Method:** DELETE
- **Parameters:**
  - `id`: ID of the document
</details>

### Authentication

<details>
<summary>Authenticate User</summary>

## Authenticates a user.

- **URL:** `/api/Authentication/authenticate`
- **Method:** POST
</details>

<details>
<summary>Sign Up User</summary>

## Registers a new user.

- **URL:** `/api/Authentication/signup`
- **Method:** POST
</details>


<details>
<summary>Get user by Id</summary>

## Get user(Student) by Id.

- **URL:** `/api/Authentication/get-by-id/{userId}`
- **Method:** Get
</details>

<details>
<summary>Update user by Id</summary>

## Update user(Student) by Id.

- **URL:** `/api/Authentication/update/{userId}`
- **Method:** Put 
</details>

### Comment

<details>
<summary>Get All Comments</summary>

## Retrieves all comments.

- **URL:** `/api/Comment/get-all`
- **Method:** GET
</details>

<details>

## Retrieves all comments of a certain feed.

- **URL:** `/api/Comment/get-all-comments-by-feedId/{feedId}`
- **Method:** GET
</details>

<details>


<summary>Get Comment by ID</summary>

## Retrieves a specific comment by its ID.

- **URL:** `/api/Comment/get-by-id/{id}`
- **Method:** GET
- **Parameters:**
  - `id`: ID of the comment
</details>

<details>
<summary>Add Comment</summary>

## Adds a new comment.

- **URL:** `/api/Comment/add`
- **Method:** POST
</details>

<details>
<summary>Update Comment</summary>

## Updates an existing comment.

- **URL:** `/api/Comment/update`
- **Method:** PUT
</details>

<details>
<summary>Delete Comment</summary>

## Deletes a comment by its ID.

- **URL:** `/api/Comment/delete/{id}`
- **Method:** DELETE
- **Parameters:**
  - `id`: ID of the comment
</details>

### Course

<details>
<summary>Get All Courses</summary>

## Retrieves all courses.

- **URL:** `/api/Course/get-all`
- **Method:** GET
</details>

<details>
<summary>Get Course by ID</summary>

## Retrieves a specific course by its ID.

- **URL:** `/api/Course/get-by-id/{id}`
- **Method:** GET
- **Parameters:**
  - `id`: ID of the course
</details>

<details>
<summary>Add Course</summary>

## Adds a new course.

- **URL:** `/api/Course/add`
- **Method:** POST
</details>

<details>
<summary>Update Course</summary>

## Updates an existing course.

- **URL:** `/api/Course/update`
- **Method:** PUT
</details>

<details>
<summary>Delete Course</summary>

## Deletes a course by its ID.

- **URL:** `/api/Course/delete/{id}`
- **Method:** DELETE
- **Parameters:**
  - `id`: ID of the course
</details>

### Department

<details>
<summary>Get All Departments</summary>

## Retrieves all departments.

- **URL:** `/api/Department/get-all`
- **Method:** GET
</details>

<details>
<summary>Get Department by ID</summary>

## Retrieves a specific department by its ID.

- **URL:** `/api/Department/get-by-id/{id}`
- **Method:** GET
- **Parameters:**
  - `id`: ID of the department
</details>

<details>
<summary>Add Department</summary>

## Adds a new department.

- **URL:** `/api/Department/add`
- **Method:** POST
</details>

<details>
<summary>Update Department</summary>

## Updates an existing department.

- **URL:** `/api/Department/update`
- **Method:** PUT
</details>

<details>
<summary>Delete Department</summary>

## Deletes a department by its ID.

- **URL:** `/api/Department/delete/{id}`
- **Method:** DELETE
- **Parameters:**
  - `id`: ID of the department
</details>

### Feed

<details>
<summary>Get All Feeds</summary>

## Retrieves all feeds.

- **URL:** `/api/Feed/get-all`
- **Method:** GET
</details>

<details>
<summary>Get Feed by ID</summary>

## Retrieves a specific feed by its ID.

- **URL:** `/api/Feed/get-by-id/{id}`
- **Method:** GET
- **Parameters:**
  - `id`: ID of the feed
</details>

<details>
<summary>Add Feed</summary>

## Adds a new feed.

- **URL:** `/api/Feed/add`
- **Method:** POST
</details>

<details>
<summary>Update Feed</summary>

## Updates an existing feed.

- **URL:** `/api/Feed/update`
- **Method:** PUT
</details>

<details>
<summary>Delete Feed</summary>

## Deletes a feed by its ID.

- **URL:** `/api/Feed/delete/{id}`
- **Method:** DELETE
- **Parameters:**
  - `id`: ID of the feed
</details>


### Professor

<details>
<summary>Get All Professors</summary>

## Retrieves all professors.

- **URL:** `/api/Professor/get-all`
- **Method:** GET
</details>

<details>
<summary>Get Professor by ID</summary>

## Retrieves a specific professor by its ID.

- **URL:** `/api/Professor/get-by-id/{id}`
- **Method:** GET
- **Parameters:**
  - `id`: ID of the professor
</details>

<details>
<summary>Add Professor</summary>

## Adds a new professor.

- **URL:** `/api/Professor/add`
- **Method:** POST
</details>

<details>
<summary>Update Professor</summary>

## Updates an existing professor.

- **URL:** `/api/Professor/update`
- **Method:** PUT
</details>

<details>
<summary>Delete Professor</summary>

## Deletes a professor by its ID.

- **URL:** `/api/Professor/delete/{id}`
- **Method:** DELETE
- **Parameters:**
  - `id`: ID of the professor
</details>

### Review

<details>
<summary>Get All Reviews</summary>

## Retrieves all reviews.

- **URL:** `/api/Review/get-all`
- **Method:** GET
</details>

<details>
<summary>Get Review by ID</summary>

## Retrieves a specific Review by its ID.

- **URL:** `/api/Review/get-by-id/{id}`
- **Method:** GET
- **Parameters:**
  - `id`: ID of the Review
</details>

<details>
<summary>Get Reviews by professorId</summary>
## Retrieves a specific Reviews by professorId.

- **URL:** `/api/Review/get-all-reviews-by-professorId/{professorId}`
- **Method:** GET
- **Parameters:**
  - `id`: ID of the Professor
</details>


api/Review/get-all-reviews-by-professorId
<details>
<summary>Add Review</summary>

## Adds a new Review.

- **URL:** `/api/Review/add`
- **Method:** POST
</details>

<details>
<summary>Update Review</summary>

##  Updates an existing Review.

- **URL:** `/api/Review/update`
- **Method:** PUT
</details>

<details>
<summary>Delete Review</summary>

## Deletes a Review by its ID.

- **URL:** `/api/Review/delete/{id}`
- **Method:** DELETE
- **Parameters:**
  - `id`: ID of the Review
</details>

### Reaction

<details>
<summary>Get All Reactions</summary>

## Retrieves all reactions.

- **URL:** `/api/Reaction/get-all`
- **Method:** GET
</details>

<details>

## Retrieves all reactions for a certain feed.

- **URL:** `/api/Reaction/get-all-reactions-by-feedId/{feedId}`
- **Method:** GET
</details>

<details>

## Retrieves all reactions for a certain relpy.

- **URL:** `/api/Reaction/get-all-reactions-by-replyId/{replyId}`
- **Method:** GET
</details>

<details>

## Retrieves all reactions for a certain comment.

- **URL:** `/api/Reaction/get-all-reactions-by-commentId/{commentId}`
- **Method:** GET
</details>

<details>
<summary>Get Reaction by ID</summary>

## Retrieves a specific reaction by its ID.

- **URL:** `/api/Reaction/get-by-id/{id}`
- **Method:** GET
- **Parameters:**
  - `id`: ID of the reaction
</details>

<details>
<summary>Add Reaction</summary>

## Adds a new reaction.

- **URL:** `/api/Reaction/add`
- **Method:** POST
</details>

<details>
<summary>Update Reaction</summary>

## Updates an existing reaction.

- **URL:** `/api/Reaction/update`
- **Method:** PUT
</details>

<details>
<summary>Delete Reaction</summary>

## Deletes a reaction by its ID.

- **URL:** `/api/Reaction/delete/{id}`
- **Method:** DELETE
- **Parameters:**
  - `id`: ID of the reaction
</details>

### Reply

<details>
<summary>Get All Replies</summary>

## Retrieves all replies.

- **URL:** `/api/Reply/get-all`
- **Method:** GET
</details>

<details>

## Retrieves all replies for a certain comment.

- **URL:** `/api/Reply/get-all-replys-by-commentId/{commentId}`
- **Method:** GET
</details>

<details>

<summary>Get Reply by ID</summary>

## Retrieves a specific reply by its ID.

- **URL:** `/api/Reply/get-by-id/{id}`
- **Method:** GET
- **Parameters:**
  - `id`: ID of the reply
</details>

<details>
<summary>Add Reply</summary>

## Adds a new reply.

- **URL:** `/api/Reply/add`
- **Method:** POST
</details>

<details>
<summary>Update Reply</summary>

Updates an existing reply.

- **URL:** `/api/Reply/update`
- **Method:** PUT
</details>

<details>
<summary>Delete Reply</summary>

## Deletes a reply by its ID.

- **URL:** `/api/Reply/delete/{id}`
- **Method:** DELETE
- **Parameters:**
  - `id`: ID of the reply
</details>

### Student

<details>
<summary>Get All Students</summary>

## Retrieves all students.

- **URL:** `/api/Student/get-all`
- **Method:** GET
</details>

<details>
<summary>Get Student by ID</summary>

## Retrieves a specific student by its ID.

- **URL:** `/api/Student/get-by-id/{id}`
- **Method:** GET
- **Parameters:**
  - `id`: ID of the student
</details>

<details>
<summary>Add Student</summary>

## Adds a new student.

- **URL:** `/api/Student/add`
- **Method:** POST
</details>

<details>
<summary>Update Student</summary>

## Updates an existing student.

- **URL:** `/api/Student/update`
- **Method:** PUT
</details>

<details>
<summary>Delete Student</summary>

## Deletes a student by its ID.

- **URL:** `/api/Student/delete/{id}`
- **Method:** DELETE
- **Parameters:**
  - `id`: ID of the student
</details>


### Example: Retrieving All Feeds Using React

This example demonstrates how to retrieve all feeds from the API using React.
```jsx
import React, { useState, useEffect } from 'react';

const AllFeeds = () => {
  const [feeds, setFeeds] = useState([]);

  const fetchFeeds = async () => {
    try {
      const response = await fetch('http://rateaucprofessor-001-site1.ftempurl.com/api/Feed/get-all');
      if (!response.ok) {
        throw new Error('Failed to fetch feeds');
      }
      const data = await response.json();
      setFeeds(data.Data);
    } catch (error) {
      console.error('Error fetching feeds:', error.message);
    }
  };

  useEffect(() => {
    fetchFeeds();
  }, []);

  return (
    <div>
      <h1>All Feeds</h1>
      <ul>
        {feeds.map(feed => (
          <li key={feed.Id}>
            <p>{feed.Content}</p>
            <p>Timestamp: {feed.Timestamp}</p>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default AllFeeds;
```
