# Clean Architecture
Overview

Clean Architecture is a software design approach that separates concerns into layers, making systems independent of frameworks, UI, databases, and external services.

## Key rules
### 1. Dependencies point inward
- Outer layers depend on inner layers
- Inner layers know nothing about outer layers
### 2. Business logic is isolated
- Frameworks, databases, UI are replaceable
### 3. High-level policies do not depend on low-level details


## Architecture Layers

### 1. Domain (Core Business)
Purpose

The Domain layer contains pure business logic and rules.
It is the most stable layer and should almost never change.

What goes here
- Entities
- Value Objects
- Domain Events
- Domain Exceptions
- Interfaces (only if they are domain-related)

What must NOT be here
- ❌ Entity Framework
- ❌ ASP.NET Core
- ❌ Logging
- ❌ HTTP
- ❌ Any external libraries (as much as possible)

### 2. Application (Use Cases)
Purpose

The Application layer orchestrates what the system does, not how it does it.
What goes here

- Use cases (Commands & Queries)
- DTOs
- Interfaces for persistence & services
- Business workflows
- Validation logic (business-level)

What must NOT be here

- ❌ EF Core implementations
- ❌ HTTP concerns
- ❌ Controllers
- ❌ Database details

### 3. Infrastructure (Details & Implementations)
Purpose

The Infrastructure layer contains all technical details.

This is where you put:
- Database access
- EF Core
- File system
- Email services
- External APIs
- Logging implementations

What goes here
- Repository implementations
- DbContext
- External service clients
- Configurations

Dependency Direction
- Infrastructure depends on Application
- Infrastructure implements Application interfaces

### 4. Api (Presentation)
Purpose

The API layer handles communication with the outside world.

Responsibilities
- HTTP requests & responses
- Model binding
- Authentication & authorization
- Status codes
- Mapping DTOs

What must NOT be here
- ❌ Business logic
- ❌ Database access
- ❌ EF Core

### Mental Model to Remember
- Domain → What is true in the business
- Application → What the system does
- Infrastructure → How it is done
- API → How users talk to it

## ⭐ All Clean Architecture variants use the same 4 conceptual layers, but different authors rename them.

Below is the definitive mapping so you can see why everything looks different but is actually the same.

### ✅ The 4 Real Clean Architecture Layers (Conceptual)

These NEVER change:

- **1. Entities**
- **2. Use Cases**
- **3. Interface Adapters**
- **4. Frameworks & Drivers**

Everything else you see online is just renaming these.

### 🎯 Why so many names?

Because:

- Some authors prefer DDD terms
- Some prefer web architecture terms
- Some prefer enterprise terms
- Some write for beginners and simplify
- Some combine layers (e.g., “Application” is sometimes two layers merged)

### 📚 The Ultimate Clean Architecture Name Mapping Table

This will help you see how the same architecture is renamed in different sources.

| Conceptual Layer (Canonical) | Uncle Bob's Terms    | DDD Terms            | Web Dev Terms  | Practical C# Project Terms | Some Tutorials | What They Really Mean                            |
| ---------------------------- | -------------------- | -------------------- | -------------- | -------------------------- | -------------- | ------------------------------------------------ |
| **1. Entities**              | Entities             | Domain Model         | Domain         | Domain                     | Core           | Business rules that never depend on anything     |
| **2. Use Cases**             | Use Cases            | Application Services | Application    | Application                | Services       | Application workflows, orchestrators             |
| **3. Interface Adapters**    | Interface Adapters   | Ports/Adapters       | Presentation   | API / Controllers / DTOs   | Web Layer      | Converts external input/output to/from use cases |
| **4. Frameworks & Drivers**  | Frameworks & Drivers | Infrastructure       | Infrastructure | Infrastructure             | Data Layer     | EF Core, DB, APIs, Email, External systems       |


# Onion Architecture
Overview

Onion Architecture is a software design approach that places business logic at the center of the application and forces all external concerns to depend on it.

The architecture is organized in concentric layers, where dependencies always point inward, making the system maintainable, testable, and independent of frameworks, databases, and UI technologies.

## Key rule
### 1. Dependencies point inward
- Outer layers depend on inner layers
- Inner layers know nothing about outer layers
### 2. Business logic is isolated
- Frameworks, databases, UI, and external services are replaceable
- Core logic is protected from technical changes
### 3. High-level policies do not depend on low-level details
- Business rules define interfaces
- Infrastructure provides implementations

## Architecture Layers
### 1. Domain (Core Business)
Purpose

The Domain layer represents the heart of the system.
It contains pure business rules and concepts and is the most stable layer.

What goes here
- Entities
- Value Objects
- Domain Services
- Domain Events
- Domain Exceptions
- Interfaces (repository or domain-specific abstractions)

What must NOT be here
- ❌ Entity Framework
- ❌ ASP.NET Core
- ❌ HTTP
- ❌ Logging
- ❌ File system
- ❌ External services
- ❌ Infrastructure concerns

### 2. Services (Application Layer)
Purpose

The Services layer (often called the Application layer) defines use cases and application workflows.

It coordinates domain objects to fulfill business operations but does not contain technical details.

What goes here
- Application services
- Use cases
- Commands & Queries
- DTOs
- Interfaces for repositories and external services
- Business-level validation

What must NOT be here
- ❌ EF Core implementations
- ❌ Database access
- ❌ HTTP concerns
- ❌ Controllers
- ❌ Framework-specific code


### 3. Infrastructure (Technical Details)
Purpose

The Infrastructure layer contains all technical implementations required by the application.

It is the most volatile layer and can change without affecting business logic.

This is where you put
- Database access
- EF Core
- External APIs
- Email services
- File system access
- Logging implementations
- Caching
- Messaging systems

What goes here
- Repository implementations
- DbContext
- External service clients
- Configuration classes

Dependency Direction
- Infrastructure depends on Services
- Infrastructure implements interfaces defined in Services or Domain

### 4. Web (Presentation Layer)
Purpose

The Web layer is the entry point of the system.
It handles communication with the outside world (HTTP, UI, etc.).

Responsibilities
- HTTP requests & responses
- Controllers
- Authentication & authorization
- Input validation (UI-level)
- Mapping DTOs
- Dependency Injection
- Filters
- Middleware

What must NOT be here
- ❌ Business logic
- ❌ Domain rules
- ❌ Database access
- ❌ EF Core
- ❌ Infrastructure logic

# Clean Architecture Project Structure

Domain
- Entities
  - Order
  - User
- ValueObjects
  - Money

Application
- DTOs
  - CreateOrderRequest
  - RegisterUserRequest
- Interfaces
  - IOrderRepository
  - IUserRepository
- UseCases
  - CreateOrderUseCase
  - GetOrderUseCase
  - RegisterUserHandler
  - ShipOrderHandler

Infrastructure
- Persistence
  - Configurations
    - OrderConfiguration
  - AppDbContext
- Repositories
  - OrderRepository
  - UserRepository

Api
- Controllers
  - OrdersController
  - UsersController
- Middlewares
  - ExceptionMiddleware
  - RequestLoggingMiddleware

 # Onion Architecture Project Structure

Domain
- Entities
  - Order
  - User
- ValueObjects
  - Money
- Interfaces
  - IOrderRepository
  - IUserRepository

Services
- Requests
  - CreateOrderRequest
  - RegisterUserRequest
- OrderService
- UserService

Infrastructure
- Persistence
  - Configurations
    - OrderConfiguration
  - AppDbContext
- Repositories
  - OrderRepository
  - UserRepository

Web
- Controllers
  - OrdersController
  - UsersController
- Middlewares
  - ExceptionMiddleware
  - RequestLoggingMiddleware
