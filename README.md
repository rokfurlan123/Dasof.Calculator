This is an application, which was given to me as a part of a test for a .Net software developer job 

It consists of 3 parts:

1. API
2. Blazor (GUI)
3. Business logic

I use repository pattern, DI and services as a common practise of writing software in .Net C# environments. Web API and Blazor projects are not referenced directly and they communicate via Business logic, so we can achieve proper SOC.
This is half true in this case, cause I used the same model for frontend and backend (request, response)... in normal projects, I would have created or used a mapper.

The application was written in VS 2026 and .Net 10 framework
