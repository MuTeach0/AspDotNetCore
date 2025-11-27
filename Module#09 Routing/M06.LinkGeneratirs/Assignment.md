M06.LinkGeneratirs - Assignment / Check your understanding

1) What does `LinkGenerator.GetUriByName` return compared to `GetPathByName`? When would you use each?

Answer: 


2) Where is the route name `EditOrder` assigned in the project? Show the code snippet.

Answer: 


3) Task: Modify the GET `/order/{id}` to include another link named `self` using `GetPathByName` or by using `context.Request.Path` — implement and test.

4) Task: Change the `EditOrder` endpoint to require a header `X-Auth` and return 401 if missing (implementation).

5) Extra: Explain how link generation helps decouple consumers from hard-coded paths.

Paste answers and small code notes here after you test them.