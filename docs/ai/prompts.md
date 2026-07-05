\# Reusable AI Prompts



\# Generate Query API



Create a Query API based on existing architecture.



Requirements:



\* follow CQRS

\* use DTOs

\* create FacadeQuery interface

\* implementation must exist in ReadModel

\* use async/await

\* return JsonResponse<T>



\---



\# Generate Command API



Create a write API based on existing architecture.



Requirements:



\* follow CQRS

\* use request models

\* create FacadeService interface

\* implementation must exist in WriteModel

\* use FluentValidation

\* return standardized JsonResponse



\---



\# Refactor Controller



Refactor this controller.



Requirements:



\* remove business logic

\* follow thin controller pattern

\* move business logic to services

\* preserve API contract

\* preserve routes



\---



\# Generate DTO



Generate DTOs for this entity.



Requirements:



\* no business logic

\* use meaningful naming

\* follow existing DTO conventions



\---



\# Analyze Architecture



Analyze this feature implementation.



Requirements:



\* identify CQRS violations

\* identify Clean Architecture violations

\* identify code smells

\* suggest improvements



\---



\# Generate Unit Test



Generate unit tests.



Requirements:



\* use xUnit

\* use Moq

\* follow Arrange / Act / Assert

\* test happy path

\* test validation failures

\* test exception scenarios



\---



\# Optimize Query



Optimize this query.



Requirements:



\* avoid unnecessary includes

\* use projection

\* improve performance

\* preserve functionality



\---



\# Add New Entity



Create a new entity module.



Requirements:



\* create DTOs

\* create Models

\* create Services

\* create Query and Command handlers

\* follow folder conventions

\* follow naming conventions



