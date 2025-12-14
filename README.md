# Clean Architecture

## Overview
Clean Architecture is a software design approach that separates concerns into layers, making systems independent of frameworks, UI, databases, and external services.

## Principles
- Independent of frameworks
- Testable
- Independent of UI
- Independent of database
- Independent of external agencies
- Dependency rule: source code dependencies point inward

## Architecture Layers

### 1. Domain
- Core business rules
- Enterprise-wide logic
- No dependencies on other layers

### 2. Application
- Application-specific business rules
- Orchestrates data flow between entities and interfaces
- Depends only on Entities

### 3. Infrastructure
- Converts data between Use Cases and external layers
- Includes controllers, presenters, gateways
- Depends on Use Cases and Entities

### 4. Api
- External tools and technologies
- UI, databases, web frameworks, messaging
- Depends on Interface Adapters


## Clean Architecture Map
- Domain
- Entities
- ValueObjects

### Application
- DTOs
- Interfaces
- UseCases

### Infrastructure
- Persistence
- Repositories

### Api
- Controllers
- Middlewares



## ⭐ All Clean Architecture variants use the same 4 conceptual layers, but different authors rename them.

Below is the definitive mapping so you can see why everything looks different but is actually the same.

### ✅ The 4 Real Clean Architecture Layers (Conceptual)

These NEVER change:

- 1. Entities
- 2. Use Cases
- 3. Interface Adapters
- 4. Frameworks & Drivers

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
