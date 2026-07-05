\# Coding Rules



\# General Rules



RULE:

All methods interacting with database must be asynchronous.



RULE:

All async methods must end with Async.



RULE:

Use constructor dependency injection only.



\---



\# API Rules



RULE:

All APIs must return:



\* JsonResponse<T>

\* JsonResponsePagination<T>



RULE:

API responses must never expose domain entities directly.



RULE:

Validation errors must use standardized response format.



\---



\# CQRS Rules



RULE:

Queries must not update database state.



RULE:

Commands must contain business modifications only.



RULE:

Queries return DTOs only.



RULE:

Commands return operation result objects only.



\---



\# Repository Rules



RULE:

Repositories are responsible only for persistence.



RULE:

Repositories must not contain business logic.



RULE:

Repositories must not return API models.



\---



\# Service Rules



RULE:

Business logic belongs only inside services or handlers.



RULE:

FacadeQuery services are read-only.



RULE:

FacadeService services are write-only.



\---



\# Mapping Rules



RULE:

Entity-to-DTO mapping must happen inside application layer.



RULE:

Controllers must never manually map entities.



\---



\# Validation Rules



RULE:

Input validation must use FluentValidation.



RULE:

Controllers must not contain validation logic.



\---



\# Logging Rules



RULE:

Errors must be logged.



RULE:

Sensitive information must never be logged.



\---



\# Exception Rules



RULE:

Do not swallow exceptions silently.



RULE:

Use centralized exception handling.



\---



\# Performance Rules



RULE:

Avoid loading unnecessary navigation properties.



RULE:

Use pagination for large collections.



RULE:

Use projection for query operations.



\---



\# Forbidden Patterns



Forbidden:



\* static service classes

\* service locator pattern

\* business logic in controllers

\* direct DbContext usage inside controllers

\* duplicated DTOs

\* synchronous database calls



