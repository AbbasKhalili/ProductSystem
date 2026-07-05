\# Naming Conventions



\# Controller Naming



Controllers ending with:



QueryController



represent read-only APIs.



Controllers without Query:

represent write APIs.



\---



\# Interface Naming



Interfaces ending with:



FacadeQuery



represent read services.



Interfaces ending with:



FacadeService



represent write services.



\---



\# DTO Naming



DTO classes must end with:



Dto



Examples:



\* ProductDto

\* ProductDetailDto



\---



\# Request Model Naming



Request models should end with:



Model



Examples:



\* CreateProductModel

\* UpdateProductModel



\---



\# Repository Naming



Repositories should follow:



I<Entity>Repository



Examples:



\* IProductRepository

\* ICategoryRepository



\---



\# Folder Structure



Each entity contains:



\* Services

\* DTOs

\* Models



Example:



Product/

DTOs/

Models/

Services/



\---



\# API Naming



API routes must:



\* use kebab-case

\* be resource-oriented



Examples:



\* /api/products

\* /api/product-query/search



\---



\# Async Naming



All asynchronous methods must end with:



Async



Examples:



\* GetProductAsync

\* CreateOrderAsync



