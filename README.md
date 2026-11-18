# Book Recommendations System

A C# console application that recommends books based on user ratings and reading preferences. Users can create accounts, manage a book catalog, rate books, and receive personalized recommendations based on members with similar interests.

This project demonstrates object-oriented programming (OOP), interface-based design, and separation of concerns using a layered architecture.

## Features

- **Member Management:** Create member accounts and log in using an account number.
- **Book Management:** Add books to the catalog with a title, author, and publication year.
- **Book Ratings:** Rate books, update existing ratings, and view previously rated books.
- **Personalized Recommendations:** Receive book recommendations based on ratings from members with similar preferences.
- **Data Import:** Load books and member ratings from text files.
- **Console Interface:** Interact with the system through a menu-driven interface.

## Technologies Used

- C#
- .NET 10
- Object-Oriented Programming (OOP)
- Interfaces and Dependency Injection
- Repository and Service Layer Architecture

## Project Structure

```text
Book-Recommendations-System/
├── Contracts/           # Repository and service interfaces
├── Domain/              # Book, Member, and Rating models
├── Repositories/        # Data storage and retrieval
├── Services/            # Application and recommendation logic
├── Program.cs           # Application entry point and menus
└── BookRecommendationsSystem.csproj
```

## Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/jbotticc/Book-Recommendations-System.git
   ```

2. Navigate to the project directory:

   ```bash
   cd Book-Recommendations-System
   ```

3. Run the application:

   ```bash
   dotnet run
   ```

## Usage

When the application starts, users are prompted to provide the absolute paths to two text files containing book information and member ratings.

### Book Data Format

Each line contains a book's author, title, and publication year, separated by commas.

```text
Jane Austen,Pride and Prejudice,1813
George Orwell,1984,1949
Mary Shelley,Frankenstein,1818
```

### Member Ratings Format

Each member's name is followed by a line of space-separated ratings corresponding to the books in the catalog.

```text
Alice
5 3 0
Bob
5 0 3
Charlie
3 5 5
```

Supported rating values are `-5`, `-3`, `0`, `1`, `3`, and `5`, where `0` represents an unrated book.

After loading the data, users can create accounts, log in, add books, submit ratings, and request recommendations.

## Recommendation Algorithm

The recommendation system identifies members with similar reading preferences and recommends books based on their ratings.

1. Compare the logged-in member's ratings with other members.
2. Calculate a similarity score using the sum of the products of their ratings.
3. Identify the member with the highest positive similarity score.
4. Find books that the similar member rated positively (`3` or `5`).
5. Recommend those books if the logged-in member has not rated them.

If no suitable match is found, the application encourages the user to rate more books.

## Application Architecture

The project follows a layered architecture to separate responsibilities and improve maintainability.

- **Domain Layer:** Defines the application's core data models.
- **Contracts Layer:** Provides interfaces for repositories and services.
- **Repository Layer:** Manages storage and retrieval of application data.
- **Service Layer:** Handles business logic, authentication, ratings, and recommendations.
- **Presentation Layer:** Provides the console-based interface for user interaction.

The use of interfaces and constructor-based dependency injection allows components to remain loosely coupled and easier to maintain.

## Author

[JJ Botticchio](https://github.com/jbotticc)
